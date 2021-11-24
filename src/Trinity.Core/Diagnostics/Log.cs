// Graph Engine
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Trinity;
using Trinity.Utilities;
using Trinity.Core.Lib;
using Trinity.Daemon;
using Trinity.Configuration;

namespace Trinity.Diagnostics
{
    /// <summary>
    /// Specifies a set of available logging levels.
    /// </summary>
    public enum LogLevel : int
    {
        /// <summary>
        /// No message is logged
        /// </summary>
        Off     = 0,

        /// <summary>
        /// Only unrecoverable system errors are logged
        /// </summary>
        Fatal   = 1,

        /// <summary>
        /// Unrecoverable system errors and application logLevel errors are logged
        /// </summary>
        Error   = 2,

        /// <summary>
        /// Fatal system error, application error and application warning are logged
        /// </summary>
        Warning = 3,

        /// <summary>
        /// All errors, warnings and notable application messages are logged
        /// </summary>
        Info    = 4,

        /// <summary>
        /// All errors, warnings, application messages and debugging messages are logged
        /// </summary>
        Debug   = 5,

        /// <summary>
        /// All messages are logged
        /// </summary>
        Verbose = 6,
    }

    /// <summary>
    /// Represents a log entry.
    /// </summary>
    public struct LOG_ENTRY
    {
        /// <summary>
        /// The log message string.
        /// </summary>
        public string   logMessage;
        /// <summary>
        /// The Unix timestamp of the log. 
        /// Note, this is not compatible with DateTime.FromBinary(long).
        /// </summary>
        public long     logTimestamp;
        /// <summary>
        /// The log level.
        /// </summary>
        public LogLevel logLevel;
        private static DateTime UnixEpoch = new DateTime(1970, 1, 1);
        /// <summary>
        /// The DateTime representation of the timestamp.
        /// </summary>
        public DateTime logTime => UnixEpoch.AddSeconds(logTimestamp);
    }

    /// <summary>
    /// A utility class for logging. 
    /// </summary>
    public unsafe class Log
    {
        #region Fields
        private static IFormatProvider s_InternalFormatProvider;
        private const  int             c_LogEntryCollectorIdleInterval = 3000;
        private const  int             c_LogEntryCollectorBusyInterval = 50;
        private static object          s_init_lock = new object();
        private static bool            s_initialized = false;
        private static bool            s_logtofile = false;
        private static BackgroundTask  s_bgtask;
        private static readonly char[] s_linebreaks = "\r\n".ToCharArray();
        #endregion

        static Log()
        {
            TrinityC.Init();
            Initialize();
        }

        internal static void Initialize()
        {
            lock (s_init_lock)
            {
                if (s_initialized) return;
                TrinityConfig.EnsureConfig();
                LoggingConfig.Instance.LogEchoOnConsole = LoggingConfig.Instance.LogEchoOnConsole; //force sync the lazy value
                CLogInitialize();
                s_bgtask = new BackgroundTask(CollectLogEntries, c_LogEntryCollectorIdleInterval);
                BackgroundThread.AddBackgroundTask(s_bgtask);
                s_initialized = true;
                s_logtofile = LoggingConfig.Instance.LogToFile;
                SetLogDirectory(LoggingConfig.Instance.LogDirectory);
            }
        }

        internal static void Uninitialize()
        {
            lock (s_init_lock)
            {
                if (!s_initialized) return;
                BackgroundThread.RemoveBackgroundTask(s_bgtask);
                s_bgtask = null;
                CLogUninitialize();
                s_initialized = false;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct LOG_ENTRY_PINVOKE
        {
            public IntPtr   logMessage;
            public long     logTimestamp;
            public LogLevel logLevel;
        }

        private static int CollectLogEntries()
        {
            ulong entry_count;
            IntPtr p_entry;
            TrinityErrorCode eResult = CLogCollectEntries(out entry_count, out p_entry);
            if (TrinityErrorCode.E_SUCCESS == eResult)
            {
                Debug.Assert(entry_count < Int32.MaxValue, "CollectLogEntries: too many log entries");
                LOG_ENTRY_PINVOKE *p       = (LOG_ENTRY_PINVOKE*)p_entry;
                LOG_ENTRY_PINVOKE *pend    = p + entry_count;
                List<LOG_ENTRY>    entries = new List<LOG_ENTRY>((int)entry_count);

                while (p != pend)
                {
                    entries.Add(new LOG_ENTRY
                    {
                        logLevel = p->logLevel,
                        logMessage = new string((char*)p->logMessage),
                        logTimestamp = p->logTimestamp
                    });
                    Memory.free(p->logMessage.ToPointer());
                    ++p;
                }
                Memory.free(p_entry.ToPointer());

                LogsWritten(entries);
            }
            return (TrinityErrorCode.E_SUCCESS == eResult) ? 
                c_LogEntryCollectorBusyInterval : 
                c_LogEntryCollectorIdleInterval;
        }

        /// <summary>
        /// The event fires when new log entries are written.
        /// </summary>
        public static event Action<IList<LOG_ENTRY>> LogsWritten = delegate { };

        /// <summary>
        /// Flushes the log content to the disk immediately. Note that for
        /// messages with LogLevel equal to LogLevel.Info or higher, the log
        /// will be automatically flushed immediately. Lower priority logs
        /// (LogLevel.Debug and LogLevel.Verbose) will be flushed periodically.
        /// </summary>
        public static void Flush()
        {
            CLogFlush();
        }

        /// <summary>
        /// Gets of sets a value indicating whether the logged messages are echoed to the Console.
        /// </summary>
        [Obsolete]
        public static bool EchoOnConsole
        {
            get { return LoggingConfig.Instance.LogEchoOnConsole; }
            set { LoggingConfig.Instance.LogEchoOnConsole = value; }
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects, followed by the current line terminator, to the log using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">An array of objects to write using format.</param>
        public static void WriteLine(string format = "", params object[] arg)
        {
            WriteLine(LogLevel.Info, format, arg);
        }

        /// <summary>
        /// Breaks the text into lines, and log the lines sequentially.
        /// </summary>
        /// <param name="lines">Represents the text to be split into lines</param>
        public static void WriteLines(string lines)
        {
            lines.Split(s_linebreaks, StringSplitOptions.RemoveEmptyEntries)
                 .ToList()
                 .ForEach(_ => WriteLine("{0}", _));
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects, followed by the current line terminator, to the log using the specified format information at the specified logging level.
        /// </summary>
        /// <param name="logLevel">The logging level at which the message is written.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">An array of objects to write using format.</param>
        public static unsafe void WriteLine(LogLevel logLevel, string format = "", params object[] arg)
        {
            string log = (arg == null || arg.Length == 0) ? format : string.Format(FormatProvider, format, arg);
            CLogWriteLine((int)logLevel, log);
        }

        // called by logging config
        internal static void SetLogDirectory(string dir)
        {
            lock (s_init_lock)
            {
                if (!s_initialized) return;
                if (!s_logtofile) return;
                WriteLine(LogLevel.Info, $"{nameof(Log)}: changing logging directory to {dir}.");
                // only notify c-logger when it's already initialized
                // and we have to close the current log file
                CLogOpenFile(dir);
            }
        }

        internal static void SetLogToFile(bool value)
        {
            lock (s_init_lock)
            {
                s_logtofile = value;
                if (!value) CLogCloseFile();
            }
        }

        private static IFormatProvider FormatProvider
        {
            get
            {
                if (s_InternalFormatProvider == null)
                {
                    // XXX use CurrentCulture or InvariantCulture for logging?
                    s_InternalFormatProvider = Thread.CurrentThread.CurrentCulture;
                }
                return s_InternalFormatProvider;
            }
        }

        [DllImport(TrinityC.AssemblyName, CharSet = CharSet.Unicode)]
        private static extern unsafe void CLogWriteLine(int level, string p_buf);

        [DllImport(TrinityC.AssemblyName)]
        private static extern void CLogFlush();

        [DllImport(TrinityC.AssemblyName)]
        private static extern unsafe void CLogInitialize();

        [DllImport(TrinityC.AssemblyName)]
        private static extern unsafe void CLogUninitialize();

        [DllImport(TrinityC.AssemblyName, CharSet = CharSet.Unicode)]
        private static extern unsafe void CLogOpenFile(string logdir);

        [DllImport(TrinityC.AssemblyName)]
        private static extern unsafe void CLogCloseFile();

        [DllImport(TrinityC.AssemblyName, CharSet = CharSet.Unicode)]
        private static extern TrinityErrorCode CLogCollectEntries(
            [Out] out ulong arr_size,
            [Out] out IntPtr entries);
    }
}
