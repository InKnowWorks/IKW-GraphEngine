// Graph Engine
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

using Trinity;
using Trinity.Core.Lib;
using Trinity.Network.Messaging;
using Trinity.Network;
using Trinity.Utilities;
using Trinity.Diagnostics;
using Trinity.Daemon;

namespace Trinity.Storage
{
    public unsafe partial class FixedMemoryCloud
    {
        internal unsafe string EchoPing(int serverId, string msg)
        {
            TrinityMessage trinity_msg = new TrinityMessage(TrinityMessageType.PRESERVED_SYNC_WITH_RSP, (ushort)RequestType.EchoPing, msg.Length << 1);
            BitHelper.WriteString(msg, trinity_msg.Buffer + TrinityMessage.Offset);

            TrinityResponse response;
            StorageTable[serverId].SendMessage(trinity_msg.Buffer, trinity_msg.Size, out response);

            return BitHelper.GetString(response.Buffer + response.Offset, response.Size);

        }

        /// <summary>
        /// Shutdown the server with the specified serverId.
        /// </summary>
        /// <param name="serverId">The id of the server.</param>
        public unsafe void ShutDown(int serverId)
        {
            byte[] message_bytes = new byte[TrinityProtocol.MsgHeader];

            fixed (byte* byte_p = message_bytes)
            {
                byte* p = byte_p;
                *(int*)p = TrinityProtocol.TrinityMsgHeader;

                *(TrinityMessageType*)(p + TrinityProtocol.MsgTypeOffset) = TrinityMessageType.PRESERVED_ASYNC;
                *(RequestType*)(p + TrinityProtocol.MsgIdOffset) = RequestType.Shutdown;
                StorageTable[serverId].SendMessage(byte_p, message_bytes.Length);
            }

        }

        internal unsafe void ShutDownProxy(RemoteStorage proxy)
        {
            TrinityMessage msg = new TrinityMessage(TrinityMessageType.PRESERVED_ASYNC, (ushort)RequestType.Shutdown, 0);
            proxy.SendMessage(msg.Buffer, msg.Size);
        }

        /// <summary>
        /// Shutdown all running Trinity servers. This only works in the Client mode.
        /// </summary>
        public unsafe void ShutDown()
        {
            //TODO should be IDisposable, not ShutDown
            //TODO move this to base implementation;
            if (TrinityConfig.CurrentRunningMode == RunningMode.Client)
            {
                try
                {
                    // Trigger the initialization if not initialized yet
                    var proxies = ProxyList;

                    BackgroundThread.ClearAllTasks(); // To disable heartbeat
                    Parallel.For(0, PartitionCount, i =>
                        {
                            ShutDown(i);
                        }
                        );
                    Parallel.ForEach<RemoteStorage>(proxies, proxy =>
                        {
                            ShutDownProxy(proxy);
                            proxy.Dispose();
                        });
                    Dispose();
                    Thread.MemoryBarrier();
                }
                catch (Exception ex)
                {
                    Log.WriteLine(LogLevel.Error, "Errors occurred during shutdown the Trinity servers.");
                    Log.WriteLine(LogLevel.Error, ex.ToString());
                }
            }
        }

        public override long GetTotalMemoryUsage()
        {
            TrinityMessage tm = new TrinityMessage(TrinityMessageType.PRESERVED_SYNC_WITH_RSP, (ushort)RequestType.QueryMemoryWorkingSet, 0);
            long[] memUsage = new long[PartitionCount];
            Parallel.For(0, PartitionCount, sid =>
                {
                    TrinityResponse response;
                    StorageTable[sid].SendMessage(tm.Buffer, tm.Size, out response);
                    memUsage[sid] = *(long*)(response.Buffer + response.Offset);
                });
            return memUsage.Sum();
        }
    }
}
