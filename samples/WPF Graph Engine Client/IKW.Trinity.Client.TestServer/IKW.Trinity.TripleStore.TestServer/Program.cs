using System.Globalization;
using System.Reactive.Linq;
using Trinity.Client.TrinityClientModule;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trinity;
using Trinity.Client.TestProtocols;
using Trinity.Client.TestProtocols.TripleServer;
using Trinity.Diagnostics;
using Trinity.Network;
using Trinity.Storage;
using System.Reflection;
using System.Security.Cryptography;
using Trinity.Client;

namespace Trinity.TripleStore.TestServer
{
    internal class Program
    {
        //private static TripleModule GraphEngineTripleServerAPI { get; set; }
        //private static TripleStoreDemoServerModule GraphEngineTripleStoreDemoServerImpl { get; set; }
        //private static TrinityClientModule GraphEngineTripleClientAPI { get; set; }
        private static TrinityServer TripleStoreServer { get; set; }

        //private static ServerInfo TripleStoreServerInfo { get; } =
        //    new ServerInfo("GenNexusPrime.inknowworks.dev.net", 6808, @"U:\Trinity TripleStore Server Deployment", LogLevel.Debug);

        private static string TripleStoreStorageRoot { get; } = @"D:\\GraphEngine-Storage";
        private static AvailabilityGroup graphEngineCluster;

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        private static async Task Main(string[] args)
        {
            TrinityConfig.LoadConfig(@"D:\Trinity TripleStore Server Deployment\trinity.xml");

            //graphEngineCluster = new AvailabilityGroup()
            //{
            //    Id = "rub-truespark-ge-cluster",
            //    Instances = new List<ServerInfo>()
            //    {
            //        new ServerInfo("GenNexusPrime.inknowworks.dev.net", 9888, string.Empty, LogLevel.Verbose),
            //        new ServerInfo("metagengraph-a.inknowworks.dev.net", 9888, string.Empty, LogLevel.Verbose),
            //        new ServerInfo("metagengraph-b.inknowworks.dev.net", 9888, string.Empty, LogLevel.Verbose)
            //        //new ServerInfo("truesparksf03.inknowworks.dev.net", 7808, string.Empty, LogLevel.Verbose),
            //        //new ServerInfo("truesparksf04.inknowworks.dev.net", 7808, string.Empty, LogLevel.Verbose),
            //        //new ServerInfo("truesparksf05.inknowworks.dev.net", 7808, string.Empty, LogLevel.Verbose)
            //    }
            //};

            TrinityConfig.LoggingLevel = LogLevel.Debug;
            //TrinityConfig.Servers.Add(graphEngineCluster);
            //TrinityConfig.CurrentRunningMode = RunningMode.Server;
            //TrinityConfig.AddServer(TripleStoreServerInfo);
            //TrinityConfig.LogEchoOnConsole = true;
            //TrinityConfig.StorageRoot = TripleStoreStorageRoot;

            //Log.LogsWritten += Log_LogsWritten;



            TripleStoreServer = new TrinityServer();

            if (Global.CloudStorage is { } cloudStorage) cloudStorage.ServerConnected += CloudStorage_ServerConnected;


            if (TripleStoreServer.CloudStorage != null)
                TripleStoreServer.CloudStorage.ServerConnected += CloudStorage_ServerConnected;

            var registeredModuleTypes = TripleStoreServer.GetRegisteredCommunicationModuleTypes();

            var moduleTypes = registeredModuleTypes as Type[] ?? registeredModuleTypes.ToArray();

            if (!moduleTypes.Contains(typeof(TrinityClientModule)))
            {
                TripleStoreServer.RegisterCommunicationModule<TrinityClientModule>();
            }

            if (!moduleTypes.Contains(typeof(TripleModule)))
            {
                TripleStoreServer.RegisterCommunicationModule<TripleModule>();
            }

            //TripleStoreServer.Started += TripleStoreServer_Started; 
            //TripleStoreServer.RegisterCommunicationModule<TripleStoreDemoServerModule>();

            TripleStoreServer.Start();

            Global.CloudStorage.ResetStorage();
            Global.LocalStorage.ResetStorage();

            //Global.LocalStorage.LoadStorage();

            var clientConnection  = TripleStoreServer.GetCommunicationModule<Trinity.Client.TrinityClientModule.TrinityClientModule>();

            // We inject an instance of the TripleModule class object so that we hook-up to our custom sever-side code

            var serverSideRuntime = TripleStoreServer.GetCommunicationModule<TripleModule>();

            if (serverSideRuntime != null)
            {
                Log.WriteLine("Setup Reactive Event Stream Processing!");

                serverSideRuntime.TriplePostedToServerReceivedAction
                    .ObserveOn(serverSideRuntime.ObserverOnNewThreadScheduler)
                    .Do(onNext: subscriberSource =>
                    {
                        var msg = "TriplePostedToServerReceivedAction-1";
                        Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);

                    })
                    .SubscribeOn(serverSideRuntime.SubscribeOnEventLoopScheduler)
                    .Subscribe(onNext: async tripleFromClient =>
                    {
                        using var processTriplePostedToServerReceiveActionTask = Task.Factory.StartNew(async () =>
                        {
                            //await Task.Yield();

                            await Task.Delay(0).ConfigureAwait(false);

                            Log.WriteLine($"Processing Timestamp: {DateTime.Now.ToString(CultureInfo.InvariantCulture)}");

                            Log.WriteLine($"Triple Received from Client has been saved Received.");

                            Log.WriteLine($"Triple Subject Node  : {tripleFromClient.Subject}");
                            Log.WriteLine($"Triple Predicate Node: {tripleFromClient.Predicate}");
                            Log.WriteLine($"Triple Object Node   : {tripleFromClient.Object}");

                        }, cancellationToken: CancellationToken.None,
                           creationOptions: TaskCreationOptions.HideScheduler,
                           scheduler: TaskScheduler.Current).Unwrap().ContinueWith(async _ =>
                        {
                            await Task.Delay(0);

                            Log.WriteLine("Task TriplePostedToServerReceivedAction Complete...");
                        }, cancellationToken: CancellationToken.None);

                        var writeToConsoleTask = processTriplePostedToServerReceiveActionTask;

                        await writeToConsoleTask;
                    });

                // Reactive Event: ServerStreamedTripleSavedToMemoryCloudAction
                // Description: Setup Reactive Subscription on Cold Observable. Logic is trigger/executed whenever
                // a client call RPC Method "PostTripleToServer."

                //serverSideRuntime.ServerStreamedTripleSavedToMemoryCloudAction
                //    .ObserveOn(serverSideRuntime.ObserverOnNewThreadScheduler)
                //    .Do(onNext: subscriberSource =>
                //    {
                //        var msg = "ServerStreamedTripleSavedToMemoryCloudAction-1";
                //        Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg,
                //            Thread.CurrentThread.ManagedThreadId);
                //    })
                //    .SubscribeOn(serverSideRuntime.SubscribeOnEventLoopScheduler)
                //    .Subscribe(onNext: async savedTriple =>
                //    {
                //        using var graphEngineResponseTask = Task.Factory.StartNew(async () =>
                //        {
                //            //await Task.Yield();

                //            await Task.Delay(0).ConfigureAwait(false);

                //            Log.WriteLine($"Processing Timestamp: {DateTime.Now.ToString(CultureInfo.InvariantCulture)}");
                //            Log.WriteLine($"Triple Streamed to Pushed Client has been saved to MemoryCloud.");
                //            Log.WriteLine($"TripleStore CellID   : {savedTriple.NewTripleStore.CellId}");
                //            Log.WriteLine($"Triple Subject Node  : {savedTriple.NewTripleStore.TripleCell.Subject}");
                //            Log.WriteLine($"Triple Predicate Node: {savedTriple.NewTripleStore.TripleCell.Predicate}");
                //        }, cancellationToken: CancellationToken.None,
                //        creationOptions: TaskCreationOptions.HideScheduler,
                //        scheduler: TaskScheduler.Current).Unwrap().ContinueWith(async _ =>
                //        {
                //            await Task.Delay(0).ConfigureAwait(false);

                //            Log.WriteLine("Task ServerStreamedTripleSavedToMemoryCloudAction Complete...");
                //        }, cancellationToken: CancellationToken.None);

                //        var writeToConsoleTask = graphEngineResponseTask;

                //        await writeToConsoleTask;
                //    });

                // ClientPostedTripleStoreReadyInMemoryCloudAction

                serverSideRuntime.ClientPostedTripleStoreReadyInMemoryCloudAction
                    .ObserveOn(serverSideRuntime.ObserverOnNewThreadScheduler)
                    .Do(onNext: subscriberSource =>
                    {
                        var msg = "ClientPostedTripleStoreReadyInMemoryCloudAction-1";

                        Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg,
                            Thread.CurrentThread.ManagedThreadId);
                    })
                    .SubscribeOn(serverSideRuntime.SubscribeOnEventLoopScheduler)
                    .Synchronize()
                    .Subscribe(onNext: async tripleObject =>
                    {
                        using var getTripleByCellIdTask = Task.Factory.StartNew(async () =>
                        {
                            // await Task.Yield();
                            await Task.Delay(0).ConfigureAwait(false);

                            var isLocalCell = Global.LocalStorage.IsTripleStore(tripleObject.CellId);

                            //var isLocalCell = Global.LocalStorage.IsLocalCell(tripleObject.CellId);

                            if (isLocalCell)
                            {
                                //Log.WriteLine($"Found TripleStore Object: {tripleObject.CellId} in Local MemoryCloud!");

                                //using var getRequest = new TripleGetRequestWriter()
                                //{
                                //    TripleCellId   = tripleObject.CellId,
                                //    Subject        = tripleObject.TripleCell.Subject,
                                //    Predicate      = tripleObject.TripleCell.Predicate,
                                //    Namespace      = tripleObject.TripleCell.Namespace,
                                //    Object         = tripleObject.TripleCell.Object
                                //};

                                //Log.WriteLine($"Make Client-Side call from Server-side: GetTripleByCellId.");

                                //await serverSideRuntime.GetTripleByCellId(0, getRequest).ConfigureAwait(false);
                            }
                        }, cancellationToken: CancellationToken.None,
                           creationOptions: TaskCreationOptions.HideScheduler,
                           scheduler: TaskScheduler.Current).Unwrap().ContinueWith(async _ =>
                        {
                            await Task.Delay(0).ConfigureAwait(false);

                            Log.WriteLine("Task ClientPostedTripleStoreReadyInMemoryCloudAction Complete...");
                        }, cancellationToken: CancellationToken.None);

                        var writeToConsoleTask = getTripleByCellIdTask;

                        await writeToConsoleTask;
                    });

                // Reactive: ClientPostedTripleStoreReadyInMemoryCloudHotAction

                async Task ServerMakeClientSideGetTripleByCellID()
                {
                    // await Task.Yield();
                    await Task.Delay(0).ConfigureAwait(false);
                }

                serverSideRuntime.ClientPostedTripleStoreReadyInMemoryCloudHotAction
                 .ObserveOn(serverSideRuntime.HotObservableSchedulerContext)
                 .Do(onNext: subscriberSource =>
                     {
                         var msg = "ClientPostedTripleStoreReadyInMemoryCloudHotAction-1";
                         Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg,
                             Thread.CurrentThread.ManagedThreadId);
                     })
                 .SubscribeOn(serverSideRuntime.HotObservableSchedulerContext)
                 .Synchronize()
                 .Subscribe(onNext: async tripleObject =>
                    {
                        using var getTripleByCellIdTask = Task.Factory.StartNew(ServerMakeClientSideGetTripleByCellID,
                            cancellationToken: CancellationToken.None,
                            creationOptions: TaskCreationOptions.HideScheduler,
                            scheduler: TaskScheduler.Current).Unwrap().ContinueWith(async _ =>
                                                                        {
                                                                            await Task.Delay(0).ConfigureAwait(false);

                                                                            Log.WriteLine("Task ClientPostedTripleStoreReadyInMemoryCloudHotAction Complete...");
                                                                        }, cancellationToken: CancellationToken.None);

                        var writeToConsoleTask = getTripleByCellIdTask;

                        await writeToConsoleTask;
                    });

                serverSideRuntime.ClientPostedTripleStoreReadyInMemoryCloudHotAction.Connect();

                serverSideRuntime.TripleByCellIdReceivedAction
                    .ObserveOn(serverSideRuntime.ObserverOnNewThreadScheduler)
                    .Do(onNext: subscriberSource =>
                    {
                        var msg = "TripleByCellIdReceivedAction-1";
                        Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg,
                            Thread.CurrentThread.ManagedThreadId);
                    })
                    .SubscribeOn(serverSideRuntime.SubscribeOnEventLoopScheduler)
                    .Synchronize()
                    .Subscribe(onNext: async tripleObjectFromGetRequest =>
                    {
                        using var getTripleBySubjectTask = Task.Factory.StartNew(async () =>
                        {
                            //await Task.Yield();

                            await Task.Delay(0).ConfigureAwait(false);

                            Log.WriteLine("Reactive Async - Server-Side Get Request on behalf of the Client.");
                            Log.WriteLine($"Processing Timestamp: {DateTime.Now.ToString(CultureInfo.InvariantCulture)}");
                            Log.WriteLine($"Triple Object CellID : {tripleObjectFromGetRequest.CellId}.");
                            Log.WriteLine($"Triple Subject Node  : {tripleObjectFromGetRequest.TripleCell.Subject}");
                            Log.WriteLine($"Triple Predicate Node: {tripleObjectFromGetRequest.TripleCell.Predicate}");
                            Log.WriteLine($"Triple Object Node   : {tripleObjectFromGetRequest.TripleCell.Object}.");

                        }, cancellationToken: CancellationToken.None,
                           creationOptions: TaskCreationOptions.HideScheduler,
                           scheduler: TaskScheduler.Current).Unwrap().ContinueWith(async _ =>
                        {
                            await Task.Delay(0).ConfigureAwait(false);

                            Log.WriteLine("Task TripleByCellIdReceivedAction Complete...");
                        }, cancellationToken: CancellationToken.None);

                        var writeToConsoleTask = getTripleBySubjectTask;

                        await writeToConsoleTask;
                    });

                serverSideRuntime.ClientPostedTripleSavedToMemoryCloudAction
                    .ObserveOn(serverSideRuntime.ObserverOnNewThreadScheduler)
                    .Do(onNext: subscriberSource =>
                    {
                        var msg = "ClientPostedTripleSavedToMemoryCloudAction-1";
                        Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg,
                            Thread.CurrentThread.ManagedThreadId);
                    })
                    .SubscribeOn(serverSideRuntime.SubscribeOnEventLoopScheduler)
                    .Synchronize()
                    .Subscribe(onNext: async tripleStoreMemoryContext =>
                    {
                        using var reactToTriplePostedSavedToMemoryCloudTask = Task.Factory.StartNew(async () =>
                        {
                            await Task.Delay(0).ConfigureAwait(false);

                            var isLocalCell = Global.CloudStorage.IsLocalCell(tripleStoreMemoryContext.NewTripleStore.CellId);

                            if (isLocalCell)
                            {
                                Log.WriteLine($"Found TripleStore Object: {tripleStoreMemoryContext.NewTripleStore.CellId} in Local MemoryCloud!");

                                using var getRequest = new TripleGetRequestWriter()
                                {
                                    TripleCellId = tripleStoreMemoryContext.NewTripleStore.CellId,
                                    Subject      = tripleStoreMemoryContext.NewTripleStore.TripleCell.Subject,
                                    Predicate    = tripleStoreMemoryContext.NewTripleStore.TripleCell.Predicate,
                                    Namespace    = tripleStoreMemoryContext.NewTripleStore.TripleCell.Namespace,
                                    Object       = tripleStoreMemoryContext.NewTripleStore.TripleCell.Object
                                };

                                Log.WriteLine($"Make Client-Side call from Server-side: GetTripleByCellId.");

                                foreach (var storage in clientConnection.Clients.ToList().Where(storage => storage.GetPrivatePropertyValue<int>("InstanceId") ==
                                             tripleStoreMemoryContext.GraphEngineClient.GetPrivatePropertyValue<int>(
                                                 "InstanceId")).Where(storage => tripleStoreMemoryContext.GraphEngineClient != null))
                                {
                                    await tripleStoreMemoryContext.GraphEngineClient.GetTripleByCellId(getRequest)
                                                                  .ConfigureAwait(false);
                                }

                                //clientConnection.ClientInitialize(RunningMode.Client, Global.CloudStorage);

                                //await serverSideRuntime.GetTripleByCellId(Global.MyPartitionId, getRequest).ConfigureAwait(false);

                                //if (tripleStoreMemoryContext.GraphEngineClient != null)
                                //    await tripleStoreMemoryContext.GraphEngineClient.GetTripleByCellId(getRequest)
                                //                                  .ConfigureAwait(false);
                            }

                        }, cancellationToken: CancellationToken.None,
                           creationOptions: TaskCreationOptions.HideScheduler,
                           scheduler: TaskScheduler.Current).Unwrap().ContinueWith(async _ =>
                        {
                            await Task.Delay(0).ConfigureAwait(false);

                            Log.WriteLine("Task ClientPostedTripleSavedToMemoryCloudAction Complete...");
                        }, cancellationToken: CancellationToken.None);

                        var storeFromMemoryCloudTask = reactToTriplePostedSavedToMemoryCloudTask;

                        await storeFromMemoryCloudTask;
                    });
            }

            //Console.ReadLine();

            Log.WriteLine("Graph Engine Server is up, running and waiting to client connections");

            //Thread.Sleep(Timeout.Infinite);

            //GraphEngineTripleStoreDemoServerImpl =
            //    TripleStoreServer.GetCommunicationModule<TripleStoreDemoServerModule>();

            while (true)
            {
                // Each time we pass through the look check to see how many active clients are connected

                using var processingLoopTask = Task.Factory.StartNew(async () =>
                {
                    if (clientConnection.Clients.Any())
                    {
                        var geStorageClient = clientConnection.Clients.ToList();

                        Log.WriteLine($"The number of real-time Connected TripleStore Client: {geStorageClient.Count}.");

                        foreach (var connectedTripleStoreClient in geStorageClient.Where(connectedTripleStoreClient => connectedTripleStoreClient != null))
                        {
                            if (serverSideRuntime is null) continue;

                            var geClientPushRegId =
                                await serverSideRuntime.RegisterClientForPushAutomationAsync(connectedTripleStoreClient,
                                                           connectedTripleStoreClient.GetPrivatePropertyValue<int>("InstanceId")).ConfigureAwait(false);

                            try
                            {
                                var triples = new List<Triple>
                                {
                                    new Triple
                                    {
                                        Subject = $"GraphEngineServer + Id: {DateTime.Now.Ticks.ToString()}",
                                        Predicate = "is", Object = $"Running @ {DateTime.Now}"
                                    }
                                };

                                // New-up the Request Message!

                                if (geClientPushRegId.HasValue)
                                {
                                    using var tripleStreamPayload =
                                        new TripleStreamWriter(geClientPushRegId.Value, triples);

                                    //  a triple to the Client

                                    var rpcResult =
                                        await connectedTripleStoreClient.StreamTriplesAsync(tripleStreamPayload);

                                    Console.WriteLine($@"Client responded: {rpcResult.errno}");

                                }
                            }
                            catch (Exception ex)
                            {
                                Log.WriteLine(ex.ToString());
                            }


                        }
                    }

                    await Task.Delay(10000).ConfigureAwait(false);

                }, cancellationToken: CancellationToken.None,
                   creationOptions: TaskCreationOptions.HideScheduler,
                   scheduler: TaskScheduler.Current).Unwrap();

                var mainLoopTask = processingLoopTask;

                await mainLoopTask;
            }
        }

        private static void Mc_ServerConnected(object sender, RemoteStorageEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void CloudStorage_ServerConnected(object sender, RemoteStorageEventArgs e)
        {
            var geclient = sender as IStorage;
            // e.RemoteStorage.
        }

        /// <summary>
        /// 
        /// </summary>
        private static void TripleStoreServer_Started()
        {
            Log.WriteLine($"{nameof(TripleStoreServer)} is update and running.");
        }

        /// <summary>
        /// This is how you intercept LOG I/O from the Trinity Communications Runtime
        /// </summary>
        /// <param name="trinityLogCollection"></param>
        private static async void Log_LogsWritten(IList<LOG_ENTRY> trinityLogCollection)
        {
            const string logLevelFormat = "{0,-8}";

            using var trinityLog = Task.Factory.StartNew(async () =>
                {
                    await Task.Yield(); // Get off the caller's stack 

                    foreach (var logEntry in trinityLogCollection)
                    {
                        var formatLogLevel = string.Format(logLevelFormat, logEntry.logLevel);

                        Log.WriteLine($"TrinityServer LOG: {logEntry.logTime}, {formatLogLevel}, {logEntry.logMessage}");
                    }
                }, cancellationToken: CancellationToken.None,
                creationOptions: TaskCreationOptions.HideScheduler,
                scheduler: TaskScheduler.Current).Unwrap();

            var ioTask = trinityLog.ConfigureAwait(false);

            await ioTask;
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

