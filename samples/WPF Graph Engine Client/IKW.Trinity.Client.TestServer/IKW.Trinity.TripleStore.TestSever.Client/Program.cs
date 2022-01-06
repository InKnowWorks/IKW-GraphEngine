using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Trinity.Network;

namespace Trinity.TripleStore.TestSever.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
using System.Net;
using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Diagnostics;
    using Trinity;
    using Trinity.Client;
    using Trinity.Client.TestProtocols;
    using Trinity.Client.TestProtocols.TripleServer;

    class Program
    {
        private static TrinityClient TrinityTripleModuleClient { get; set; } = null;
        private static TripleModule TripleClientSideModule { get; set; } = null;

        static async Task Main(string[] args)
        {
            //TrinityConfig.LoadConfig();

            //TrinityConfig.CurrentRunningMode = RunningMode.Client;
            //TrinityConfig.LogEchoOnConsole = false;
            TrinityConfig.LoggingLevel = LogLevel.Info;

            //TrinityConfig.SaveConfig();

            //Log.LogsWritten += Log_LogsWritten;

            //TrinityTripleModuleClient = new TrinityClient("testcluster100.southcentralus.cloudapp.azure.com:8800");

            TrinityTripleModuleClient = new TrinityClient("GenNexusPrime.inknowworksdev.net:5304");

            //TrinityTripleModuleClient = new TrinityClient("truesparksf01.inknowworks.dev.net:9278");   // truesparksf03.inknowworks.dev.net:8808

            TrinityTripleModuleClient.UnhandledException += TrinityTripleModuleClient_UnhandledException;
            TrinityTripleModuleClient.Started += TrinityTripleModuleClientOnStarted;

            TrinityTripleModuleClient.RegisterCommunicationModule<TripleModule>();
            TrinityTripleModuleClient.Start();

            Global.LocalStorage.ResetStorage();

            Log.WriteLine("Setup Reactive Event Stream Processing!");

            TripleClientSideModule = TrinityTripleModuleClient.GetCommunicationModule<TripleModule>();

            TripleClientSideModule.TripleBySubjectReceivedAction
              .ObserveOn(TripleClientSideModule.ObserverOnNewThreadScheduler)
              .Do(onNext: subscriberSource =>
                          {
                              var msg = "TripleBySubjectReceivedAction-1";
                              Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                          })
              .SubscribeOn(TripleClientSideModule.SubscribeOnEventLoopScheduler)
              .Subscribe(onNext: async tripleStore =>
                                 {
                                     using var reactiveGetTripleBySubjectTask = Task.Factory.StartNew(async () =>
                                         {
                                             //await Task.Yield();

                                             await Task.Delay(0).ConfigureAwait(false);

                                             Log.WriteLine("Reactive Async - Parallel-Tasking return from Server-Side Get Request on behalf of the Client.");

                                             Log.WriteLine($"Processing Timestamp: {DateTime.Now.ToString(CultureInfo.InvariantCulture)}");

                                             Log.WriteLine($"Triple Object CellID   : {tripleStore.CellId}.");
                                             Log.WriteLine($"Triple Subject Node    : {tripleStore.TripleCell.Subject}");
                                             Log.WriteLine($"Triple Predicate Node  : {tripleStore.TripleCell.Predicate}");
                                             Log.WriteLine($"Triple Object Node     : {tripleStore.TripleCell.Object}.");

                                             var getTripleByCellRequestWriter = new TripleGetRequestWriter()
                                             {
                                                 TripleCellId   = tripleStore.CellId,
                                                 Subject        = tripleStore.TripleCell.Subject,
                                                 Predicate      = tripleStore.TripleCell.Predicate,
                                                 Object         = tripleStore.TripleCell.Object,
                                                 Namespace      = tripleStore.TripleCell.Namespace
                                             };

                                             using var queryResponseA = TrinityTripleModuleClient.GetTripleByCellId(getTripleByCellRequestWriter);
                                             using var queryResponseB = TripleClientSideModule.GetTripleByCellId(Global.CloudStorage.MyPartitionId, getTripleByCellRequestWriter);
                                             using var queryResponseC = TrinityTripleModuleClient.GetTripleSubject(getTripleByCellRequestWriter);
                                         }, cancellationToken: CancellationToken.None,
                                         creationOptions: TaskCreationOptions.HideScheduler,
                                         scheduler: TaskScheduler.Current).Unwrap().ContinueWith(async _ =>
                                     {
                                         await Task.Delay(0);

                                         Log.WriteLine("Task TripleObjectStreamedFromServerReceivedAction Complete...");
                                     }, cancellationToken: CancellationToken.None);

                                     var writeToConsoleTask = reactiveGetTripleBySubjectTask;

                                     await writeToConsoleTask;
                                 });

            // TripleObjectStreamedFromServerReceivedAction

            TripleClientSideModule.TripleObjectStreamedFromServerReceivedAction
              .ObserveOn(TripleClientSideModule.ObserverOnNewThreadScheduler)
              .Do(onNext: subscriberSource =>
                  {
                      var msg = "TripleObjectStreamedFromServerReceivedAction-1";

                      Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                  })
              .SubscribeOn(TripleClientSideModule.SubscribeOnEventLoopScheduler)
              .Subscribe(onNext: async tripleObjectFromServer =>
                 {
                     using var reactiveGraphEngineResponseTask = Task.Factory.StartNew(async () =>
                         {
                             //await Task.Yield();

                             await Task.Delay(0).ConfigureAwait(false);

                             Log.WriteLine("Incoming Triple Object Received from GE Server.");

                             Log.WriteLine($"Processing Timestamp: {DateTime.Now.ToString(CultureInfo.InvariantCulture)}");

                             Log.WriteLine($"Triple Subject Node   : {tripleObjectFromServer.Subject}");
                             Log.WriteLine($"Triple Predicate Node : {tripleObjectFromServer.Predicate}");
                             Log.WriteLine($"Triple Object Node    : {tripleObjectFromServer.Object}");

                         }, cancellationToken: CancellationToken.None,
                            creationOptions: TaskCreationOptions.HideScheduler,
                            scheduler: TaskScheduler.Current).Unwrap().ContinueWith(async _ =>
                     {
                         await Task.Delay(0);

                         Log.WriteLine("Task TripleObjectStreamedFromServerReceivedAction Complete...");
                     }, cancellationToken: CancellationToken.None);

                     var writeToConsoleTask = reactiveGraphEngineResponseTask;

                     await writeToConsoleTask;
                 });

            // ServerStreamedTripleSavedToMemoryCloudAction

            TripleClientSideModule.ServerStreamedTripleSavedToMemoryCloudAction
              .ObserveOn(TripleClientSideModule.ObserverOnNewThreadScheduler)
              .Do(onNext: subscriberSource =>
                  {
                      var msg = "ServerStreamedTripleSavedToMemoryCloudAction-1";
                      Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg,
                          Thread.CurrentThread.ManagedThreadId);
                  })
              .SubscribeOn(TripleClientSideModule.SubscribeOnEventLoopScheduler)
              .Subscribe(onNext: async tripleObjectFromMC =>
                 {
                     using var reactiveGraphEngineResponseTask = Task.Factory.StartNew(async () =>
                         {
                             await Task.Delay(0).ConfigureAwait(false);

                             var myTripleStore = tripleObjectFromMC.NewTripleStore;

                             Log.WriteLine("Incoming TripleStore Object retrieved from MemoryCloud.");

                             Log.WriteLine($"Processing Timestamp: {DateTime.Now.ToString(CultureInfo.InvariantCulture)}");

                             Log.WriteLine($"Triple Object CellID  : {myTripleStore.CellId}");
                             Log.WriteLine($"Triple Subject Node   : {myTripleStore.TripleCell.Subject}");
                             Log.WriteLine($"Triple Predicate Node : {myTripleStore.TripleCell.Predicate}");
                             Log.WriteLine($"Triple Object Node    : {myTripleStore.TripleCell.Object}");
                         }, cancellationToken: CancellationToken.None,
                         creationOptions: TaskCreationOptions.HideScheduler,
                         scheduler: TaskScheduler.Current).Unwrap().ContinueWith(async _ =>
                     {
                         await Task.Delay(0);

                         Log.WriteLine("Task ServerStreamedTripleSavedToMemoryCloudAction Complete...");
                     }, cancellationToken: CancellationToken.None);

                     var writeToConsoleTask = reactiveGraphEngineResponseTask;

                     await writeToConsoleTask;
                 });

            TripleClientSideModule.ServerStreamedTripleStoreReadyInMemoryCloudAction
              .ObserveOn(TripleClientSideModule.ObserverOnNewThreadScheduler)
              .Do(onNext: subscriberSource =>
              {
                  var msg = "ServerStreamedTripleStoreReadyInMemoryCloudAction-1";
                  Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg,
                      Thread.CurrentThread.ManagedThreadId);
              })
              .SubscribeOn(TripleClientSideModule.SubscribeOnEventLoopScheduler)
              .Subscribe(onNext: async tripleObjectFromMC =>
              {
                  using var reactiveGraphEngineResponseTask = Task.Factory.StartNew(async () =>
                  {
                      await Task.Delay(0).ConfigureAwait(false);

                      var myTripleStore = tripleObjectFromMC.TripleCell;

                      Log.WriteLine("Incoming TripleStore Object retrieved from MemoryCloud.");

                      var rpcResponseCode = await TrinityTripleModuleClient.GetTripleByCellId(
                          new TripleGetRequestWriter()
                          {
                              Subject = myTripleStore.Subject,
                              Namespace = myTripleStore.Namespace,
                              Predicate = myTripleStore.Predicate,
                              Object = myTripleStore.Object,
                              TripleCellId = tripleObjectFromMC.CellId
                          }).ConfigureAwait(false);

                      Log.WriteLine(rpcResponseCode.QueryResult
                          ? $"Query Triple Object (Using CellId): {tripleObjectFromMC.CellId}, does exist in GE App Server Local Memory Cloud."
                          : $"Query Triple Object (Using CellId): {tripleObjectFromMC.CellId}, does NOT exist in GE App Server Local Memory Cloud.");

                      var rpcResponseCodeB = await TrinityTripleModuleClient.GetTripleSubject(
                          new TripleGetRequestWriter()
                          {
                              Subject = myTripleStore.Subject,
                              Namespace = myTripleStore.Namespace,
                              Predicate = myTripleStore.Predicate,
                              Object = myTripleStore.Object,
                              TripleCellId = tripleObjectFromMC.CellId
                          }).ConfigureAwait(false);

                      Log.WriteLine(rpcResponseCode.QueryResult
                          ? $"Query Triple Object (Using CellId+Subject): {tripleObjectFromMC.CellId}, does exist in GE App Server Local Memory Cloud."
                          : $"Query Triple Object (Using CellId+Subject): {tripleObjectFromMC.CellId}, does NOT exist in GE App Server Local Memory Cloud.");
                  }, cancellationToken: CancellationToken.None,
                     creationOptions: TaskCreationOptions.HideScheduler,
                     scheduler: TaskScheduler.Current).Unwrap().ContinueWith(async _ =>
                      {
                          await Task.Delay(0);

                          Log.WriteLine("Task ServerStreamedTripleStoreReadyInMemoryCloudAction Complete...");
                      }, cancellationToken: CancellationToken.None);

                  var writeToConsoleTask = reactiveGraphEngineResponseTask;

                  await writeToConsoleTask;
              });


            TripleClientSideModule.TripleByCellIdReceivedAction
                                  .ObserveOn(TripleClientSideModule.ObserverOnNewThreadScheduler)
                                  .Do(onNext: subscriberSource =>
                                              {
                                                  var msg = "TripleByCellIdReceivedAction-1";
                                                  Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg,
                                                      Thread.CurrentThread.ManagedThreadId);
                                              })
                                  .SubscribeOn(TripleClientSideModule.SubscribeOnEventLoopScheduler)
                                  .Synchronize()
                                  .Subscribe(onNext: ProcessTripleFetchedUsingCellId);

            //Log.WriteLine($"Please press the enter to continue!");

            //Log.ReadLine();

            // Prevents this host process from terminating so services keep running.
            //Thread.Sleep(Timeout.Infinite);

            // Main Processing Loop!

            ClientRegistrationResponseReader forPushAutomation = null;

            forPushAutomation = TrinityTripleModuleClient.RegisterForPushAutomation(new ClientRegistrationRequestWriter(TrinityTripleModuleClient.ClientMessageId));

            using var trinityClientProcessingLoopTask = Task.Factory.StartNew(async () =>
              {
                  while (true)
                  {
                      try
                      {
                          var clientId = Global.CloudStorage.MyInstanceId;

                          var sampleTriple = new List<Triple>
                              {new Triple {Subject = $"Test-GraphEngineClient-{clientId} @ {DateTime.Now.Ticks.ToString()}", Predicate = "is", Object = $"Running @ {DateTime.Now}"}};

                          if (forPushAutomation != null)
                          {
                              using var tripleStreamWriter = new TripleStreamWriter(forPushAutomation.PushAutomationRegId, sampleTriple);

                              var rcpResult = await TrinityTripleModuleClient.PostTriplesToServer(tripleStreamWriter).ConfigureAwait(false);
                          }
                      }
                      catch (Exception ex)
                      {
                          Log.WriteLine(ex.ToString());
                      }

                      await Task.Delay(10000).ConfigureAwait(false);

                      forPushAutomation ??=
                          TrinityTripleModuleClient.RegisterForPushAutomation(
                              new ClientRegistrationRequestWriter(TrinityTripleModuleClient.ClientMessageId));
                  }
              }, cancellationToken: CancellationToken.None,
                 creationOptions: TaskCreationOptions.HideScheduler,
                 scheduler: TaskScheduler.Current).Unwrap();

            var mainLoopTask = trinityClientProcessingLoopTask;

            await mainLoopTask;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tripleObjectFromGetRequest"></param>
        private static async void ProcessTripleFetchedUsingCellId(TripleStore tripleObjectFromGetRequest)
        {
            using var getTripleBySubjectTask = Task.Factory.StartNew(async () =>
            {
                 //await Task.Yield();

                 await Task.Delay(0).ConfigureAwait(false);

                 Log.WriteLine("Reactive Async - Client-Side Get Request.");
                 Log.WriteLine($"Processing Timestamp: {DateTime.Now.ToString(CultureInfo.InvariantCulture)}");
                 Log.WriteLine($"Triple Object CellID : {tripleObjectFromGetRequest.CellId}.");
                 Log.WriteLine($"Triple Subject Node  : {tripleObjectFromGetRequest.TripleCell.Subject}");
                 Log.WriteLine($"Triple Predicate Node: {tripleObjectFromGetRequest.TripleCell.Predicate}");
                 Log.WriteLine($"Triple Object Node   : {tripleObjectFromGetRequest.TripleCell.Object}.");

             }, cancellationToken: CancellationToken.None, 
                creationOptions: TaskCreationOptions.HideScheduler, 
                scheduler: TaskScheduler.Current).Unwrap()
            .ContinueWith(async _ =>
             {
                 await Task.Delay(0).ConfigureAwait(false);

                 Log.WriteLine("Task TripleByCellIdReceivedAction Complete...");
             }, cancellationToken: CancellationToken.None);

            var writeToConsoleTask = getTripleBySubjectTask;
                
            await writeToConsoleTask;
        }

        private static void TrinityTripleModuleClientOnStarted()
        {
            Log.WriteLine($"Trinity Client is connected to target Trinity Graph Engine Server.");
        }


        private static void TrinityTripleModuleClient_UnhandledException(object sender, Network.Messaging.MessagingUnhandledExceptionEventArgs e)
        {
           Log.WriteLine($"Yikes! An unexpected Trinity Networking Error has been detected: {e.ToString()}");
        }

        /// <summary>
        /// This is how you intercept LOG I/O from the Trinity Communications Runtime
        /// </summary>
        /// <param name="trinityLogCollection"></param>
        private static async void Log_LogsWritten(IList<LOG_ENTRY> trinityLogCollection)
        {
            const string logLevelFormat = "{0,-8}";

            using var trinityLogIOTask = Task.Factory.StartNew(async () =>
            {
                await Task.Yield(); // Get off the caller's stack 

                foreach (var logEntry in trinityLogCollection)
                {
                    var formatLogLevel = string.Format(logLevelFormat, logEntry.logLevel);

                    Log.WriteLine($"TrinityClient LOG: {logEntry.logTime}, {formatLogLevel}, {logEntry.logMessage}");
                }
            }, cancellationToken: CancellationToken.None,
               creationOptions: TaskCreationOptions.HideScheduler,
               scheduler: TaskScheduler.Current).Unwrap();

            var taskAwaitable = trinityLogIOTask;

            await taskAwaitable;
        }
    }

     public static class PropertyHelper
    {
        /// <summary>
        /// Returns a _private_ Property Value from a given Object. Uses Reflection.
        /// Throws a ArgumentOutOfRangeException if the Property is not found.
        /// </summary>
        /// <typeparam name="T">Type of the Property</typeparam>
        /// <param name="obj">Object from where the Property Value is returned</param>
        /// <param name="propName">Propertyname as string.</param>
        /// <returns>PropertyValue</returns>
        public static T GetPrivatePropertyValue<T>(this object obj, string propName)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            PropertyInfo pi = obj.GetType().GetProperty(propName,
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance);
            if (pi == null)
                throw new ArgumentOutOfRangeException("propName",
                    string.Format("Property {0} was not found in Type {1}", propName,
                        obj.GetType().FullName));
            return (T) pi.GetValue(obj, null);
        }

        /// <summary>
        /// Returns a private Field Value from a given Object. Uses Reflection.
        /// Throws a ArgumentOutOfRangeException if the Property is not found.
        /// </summary>
        /// <typeparam name="T">Type of the Field</typeparam>
        /// <param name="obj">Object from where the Field Value is returned</param>
        /// <param name="propName">Field Name as string.</param>
        /// <returns>FieldValue</returns>
        public static T GetPrivateFieldValue<T>(this object obj, string propName)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            Type      t  = obj.GetType();
            FieldInfo fi = null;
            while (fi == null && t != null)
            {
                fi = t.GetField(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                t = t.BaseType;
            }

            if (fi == null)
                throw new ArgumentOutOfRangeException("propName",
                    string.Format("Field {0} was not found in Type {1}", propName,
                        obj.GetType().FullName));
            return (T) fi.GetValue(obj);
        }

        /// <summary>
        /// Sets a _private_ Property Value from a given Object. Uses Reflection.
        /// Throws a ArgumentOutOfRangeException if the Property is not found.
        /// </summary>
        /// <typeparam name="T">Type of the Property</typeparam>
        /// <param name="obj">Object from where the Property Value is set</param>
        /// <param name="propName">Propertyname as string.</param>
        /// <param name="val">Value to set.</param>
        /// <returns>PropertyValue</returns>
        public static void SetPrivatePropertyValue<T>(this object obj, string propName, T val)
        {
            Type t = obj.GetType();
            if (t.GetProperty(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance) == null)
                throw new ArgumentOutOfRangeException("propName",
                    string.Format("Property {0} was not found in Type {1}", propName,
                        obj.GetType().FullName));
            t.InvokeMember(propName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty |
                BindingFlags.Instance, null, obj, new object[] {val});
        }


        /// <summary>
        /// Set a private Field Value on a given Object. Uses Reflection.
        /// </summary>
        /// <typeparam name="T">Type of the Field</typeparam>
        /// <param name="obj">Object from where the Property Value is returned</param>
        /// <param name="propName">Field name as string.</param>
        /// <param name="val">the value to set</param>
        /// <exception cref="ArgumentOutOfRangeException">if the Property is not found</exception>
        public static void SetPrivateFieldValue<T>(this object obj, string propName, T val)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            Type      t  = obj.GetType();
            FieldInfo fi = null;
            while (fi == null && t != null)
            {
                fi = t.GetField(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                t = t.BaseType;
            }

            if (fi == null)
                throw new ArgumentOutOfRangeException("propName",
                    string.Format("Field {0} was not found in Type {1}", propName,
                        obj.GetType().FullName));
            fi.SetValue(obj, val);
        }
    }
}
