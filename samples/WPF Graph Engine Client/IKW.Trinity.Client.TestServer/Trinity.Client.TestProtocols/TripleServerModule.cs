using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Reactive.Bindings;
using Trinity.Client.TestProtocols.TripleAppServerGateway;
using Trinity.Client.TestProtocols.TripleServer;
using Trinity.Core.Lib;
using Trinity.Diagnostics;
using Trinity.Extension;
using Trinity.Network;
using Trinity.Storage;
using Trinity.TSL.Lib;

using static System.Formats.Asn1.AsnWriter;

namespace Trinity.Client.TestProtocols
{
    [AutoRegisteredCommunicationModule]
    public class TripleModule : TripleServerBase
    {
        // Let's use RX to setup Subscription based processing of object with the intention of
        // the UI viewModel and WPF code-behind to hook-up to presenting to the UI; our Test Server
        // is pushing triples to our WPF client

        private static TripleModule GraphEngineTripleModuleImpl { get; set; }
        //private static TripleStoreDemoServerModule GraphEngineTripleStoreDemoServerImpl { get; set; }
        private TrinityClientModule.TrinityClientModule TrinityTripleModuleClient { get; set; }
        private TrinityServer TripleStoreServer { get; set; }

        private TrinityClient TrinityTripleClient { get; set; }

        // Dynamically gain access to the client connection
        private Storage.IStorage TripleStoreClient { get; set; }

        private IObserver<(Storage.IStorage GraphEngineClient, TripleStreamReader TriplePayload)> TripleStreamReceivedActionObserver {get;set;}
        private IObserver<(Storage.IStorage GraphEngineClient, TripleStreamReader TriplePayload)> TripleStreamPostedActionObserver { get; set; }
        private IObserver<(Storage.IStorage GraphEngineClient, TripleGetRequestReader TriplePayload)> GetTripleByCellIdRequestActionObserver { get; set; }
        private IObserver<(Storage.IStorage GraphEngineClient, TripleGetRequestReader TriplePayload)> GetTripleBySubjectRequestActionObserver { get; set; }
        private IObserver<(Storage.IStorage GraphEngineClient, TripleStore NewTripleStore)> RequestServerSaveStreamedTripleToMemoryCloudActionObserver {get; set; }
        private IObserver<(Storage.IStorage GraphEngineClient, TripleStore NewTripleStore)> SaveClientPostedTripleToMemoryCloudActionObserver { get; set; }
        private IObserver<Triple> TripleObjectProjectedActionObserver {get; set; }
        private IObserver<Triple> TriplePostedToServerProjectedActionObserver { get; set; }
        private IObserver<TripleStore> TripleByCellIdProjectedActionObserver { get; set; }
        private IObserver<TripleStore> TripleBySubjectProjectedActionObserver { get; set; }
        private IObserver<TripleStore> ServerStreamedTripleStoreReadyInMemoryCloudActionObserver {get; set; }
        private IObserver<TripleStore> ClientPostedTripleStoreReadyInMemoryCloudActionObserver { get; set; }

        private IObserver<TripleStreamReader> SaveTripleToMemoryActionObserver { get; set; }
        private IObservable<TripleStore> SaveTripleToMemoryActionSubscriber { get; set; }
        private IDisposable SaveTripleToMemoryActionSubscription { get; set; }

        private IObservable<(Storage.IStorage GraphEngineClient, TripleStreamReader TriplePayload)> TripleStreamReceivedActionSubscriber {get;set;}
        private IObservable<(Storage.IStorage GraphEngineClient, TripleStreamReader TriplePayload)> TripleStreamPostedActionSubscriber { get; set; }
        private IObservable<(Storage.IStorage GraphEngineClient, TripleGetRequestReader TriplePayload)> GetTripleByCellIdRequestActionSubscriber { get; set; }
        private IObservable<(Storage.IStorage GraphEngineClient, TripleGetRequestReader TriplePayload)> GetTripleBySubjectRequestActionSubscriber { get; set; }
        private IObservable<(Storage.IStorage GraphEngineClient, TripleStore NewTripleStore)> SaveServerStreamedTripleToMemoryCloudActionSubscriber {get;set;}
        private IObservable<(Storage.IStorage GraphEngineClient, TripleStore NewTripleStore)> SaveClientPostedTripleToMemoryCloudActionSubscriber { get; set; }
        private IObservable<Triple> TripleObjectProjectedActionSubscriber {get;set;}
        private IObservable<Triple> TriplePostedToServerProjectedActionSubscriber { get; set; }
        private IObservable<TripleStore> TripleByCellIdProjectedActionSubscriber { get; set; }
        private IObservable<TripleStore> TripleBySubjectProjectedActionSubscriber { get; set; }
        private IObservable<TripleStore> ServerStreamedTripleStoreReadyInMemoryCloudActionSubscriber {get;set;}
        private IObservable<TripleStore> ClientPostedTripleStoreReadyInMemoryCloudActionSubscriber { get; set; }

        public ReactiveProperty<Triple> TripleObjectStreamedFromServerReceivedAction {get; private set;}
        public ReactiveProperty<TripleStore> TripleByCellIdReceivedAction { get; private set; }
        public ReactiveProperty<TripleStore> TripleBySubjectReceivedAction { get; private set; }
        public ReactiveProperty<Triple> TriplePostedToServerReceivedAction { get; private set; }
        public ReactiveProperty<(Storage.IStorage GraphEngineClient, TripleStore NewTripleStore)> ServerStreamedTripleSavedToMemoryCloudAction { get; private set; }
        public ReactiveProperty<(Storage.IStorage GraphEngineClient, TripleStore NewTripleStore)> ClientPostedTripleSavedToMemoryCloudAction {get; private set;}
        public ReactiveProperty<TripleStore> ServerStreamedTripleStoreReadyInMemoryCloudAction { get; set; }
        public ReactiveProperty<TripleStore> ClientPostedTripleStoreReadyInMemoryCloudAction { get; set; }

        public IConnectableObservable<TripleStore> ClientPostedTripleStoreReadyInMemoryCloudHotAction { get; set; }
        private IDisposable ClientPostedTripleStoreReadyInMemoryCloudHotSubscription { get; set; }

        // Declare the Subscription for proper clean-up

        private IDisposable TripleObjectReceivedActionSubscription {get;set;}
        private IDisposable TripleSaveToMemoryCloudActionSubscription {get;set;}
        private IDisposable PostTripleToMemoryCloudActionSubscription { get; set; }
        private IDisposable TripleObjectProjectedActionSubscription {get;set;}
        private IDisposable TripleStoreReadyInMemoryCloudActionSubscription {get;set;}
        private IDisposable ClientPostedTripleReadyInMemoryCloudSubscription { get;set; }
        private IDisposable GetTripleByCellIdActionSubscription { get; set; }
        private IDisposable GetTripleBySubjectActionSubscription { get; set; }
        private IDisposable PostTripleToServerActionSubscription { get; set; }
        private IDisposable TriplePostedToServerProjectedActionSubscription { get; set; }


        public EventLoopScheduler  SubscribeOnEventLoopScheduler { get; private set; }
        public NewThreadScheduler ObserverOnNewThreadScheduler { get; private set; }
        public IScheduler HotObservableSchedulerContext { get; private set; } 
        // Fix to protect Graph Engine Reader/Writer Objects
        private SpinLock tripleGetRequestReaderSpinLock = new SpinLock();
        private SpinLock tripleGetRequestWriterSpinLock = new SpinLock();
        private bool requestReaderlockAcquired = false;
        private bool requestWriterlockAcquired = false;
        private Mutex requestReaderMutex = new Mutex();
        private Mutex requestWriterMutex = new Mutex();

        private readonly TripleEqualityCompare _tripleEqualityCompare = null;
        private readonly TripleStoreEqualityCompare _tripleStoreEqualityCompare = null;
        private readonly TripleTupleEqualityCompare _tripleTupleEqualityCompare = null;

        // We modify the default class constructor 
        public TripleModule()
        {
            SubscribeOnEventLoopScheduler = new EventLoopScheduler();
            ObserverOnNewThreadScheduler  = NewThreadScheduler.Default;
            HotObservableSchedulerContext = TaskPoolScheduler.Default;

            _tripleEqualityCompare       = new TripleEqualityCompare();
            _tripleStoreEqualityCompare  = new TripleStoreEqualityCompare();
            _tripleTupleEqualityCompare  = new TripleTupleEqualityCompare();

            SetupObservers();
            SetUpObservables();
            SetupExternalReactiveProperties();
        }

        /// <summary>
        ///  
        /// </summary>
        private class TripleEqualityCompare : IEqualityComparer<Triple>
        {
            private readonly Triple EmptyTriple = new Triple(null);
            public bool Equals(Triple tripleObjectX, Triple tripleObjectY)
            {
                if (tripleObjectX == EmptyTriple)
                {
                    return false;
                }else if (tripleObjectY == EmptyTriple)
                {
                    return false;
                }else if (tripleObjectX != EmptyTriple && tripleObjectY != EmptyTriple)
                {
                    var test = tripleObjectX.Namespace.Equals(tripleObjectY.Namespace) &&
                                                          tripleObjectX.Subject.Equals(tripleObjectY.Subject) &&
                                                          tripleObjectX.Predicate.Equals(tripleObjectY.Predicate) &&
                                                          tripleObjectX.Object.Equals(tripleObjectY.Object);

                    return tripleObjectX.Namespace.Equals(tripleObjectY.Namespace) &&
                           tripleObjectX.Subject.Equals(tripleObjectY.Subject) &&
                           tripleObjectX.Predicate.Equals(tripleObjectY.Predicate) &&
                           tripleObjectX.Object.Equals(tripleObjectY.Object);
                }else
                {
                    return false;
                }

            }

            public int GetHashCode(Triple obj)
            {
                return obj.Subject.GetHashCode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private class TripleStoreEqualityCompare : IEqualityComparer<TripleStore>
        {
            private readonly TripleStore EmptyTripleStore = new TripleStore()
            {
                CellId = 0,
                TripleCell = new Triple(null)
            };

            public bool Equals(TripleStore tripleStoreX, TripleStore tripleStoreY)
            {
                if (tripleStoreX == EmptyTripleStore)
                {
                    return false;
                }
                else if (tripleStoreY == EmptyTripleStore)
                {
                    return false;
                }
                else if (tripleStoreX != EmptyTripleStore && tripleStoreY != EmptyTripleStore)
                {
                    return !tripleStoreX.CellId.Equals(tripleStoreY.CellId) &&
                           tripleStoreX.TripleCell.Namespace.Equals(tripleStoreY.TripleCell.Namespace) &&
                           tripleStoreX.TripleCell.Subject.Equals(tripleStoreY.TripleCell.Subject) &&
                           tripleStoreX.TripleCell.Predicate.Equals(tripleStoreY.TripleCell.Predicate) &&
                           tripleStoreX.TripleCell.Object.Equals(tripleStoreY.TripleCell.Object);
                }
                else
                {
                    return false;
                }
            }

            public int GetHashCode(TripleStore obj)
            {
                return obj.CellId.GetHashCode(); 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private class TripleTupleEqualityCompare : IEqualityComparer<(Storage.IStorage GraphEngineClient, TripleStore NewTripleStore)>
        {
            private readonly (Storage.IStorage GraphEngineClient, TripleStore NewTripleStore) EmptyTripleTuple = (null, new TripleStore());

            public bool Equals((Storage.IStorage GraphEngineClient, TripleStore NewTripleStore) tripleTupleX, (Storage.IStorage GraphEngineClient, TripleStore NewTripleStore) tripleTupleY)
            {
                if (tripleTupleX == EmptyTripleTuple)
                {
                    return false;
                }
                else if (tripleTupleY == EmptyTripleTuple)
                {
                    return false;
                }
                else if (tripleTupleX != EmptyTripleTuple && tripleTupleY != EmptyTripleTuple)
                {
                    var objectAreEqual = (tripleTupleX.GraphEngineClient != tripleTupleY.GraphEngineClient) &&
                                             //tripleTupleX.NewTripleStore.CellId.Equals(tripleTupleY.NewTripleStore.CellId) &&
                                             tripleTupleX.NewTripleStore.TripleCell.Namespace.Equals(tripleTupleY.NewTripleStore.TripleCell.Namespace) &&
                                             tripleTupleX.NewTripleStore.TripleCell.Subject.Equals(tripleTupleY.NewTripleStore.TripleCell.Subject) &&
                                             tripleTupleX.NewTripleStore.TripleCell.Predicate.Equals(tripleTupleY.NewTripleStore.TripleCell.Predicate) &&
                                             tripleTupleX.NewTripleStore.TripleCell.Object.Equals(tripleTupleY.NewTripleStore.TripleCell.Object);

                    return !tripleTupleX.GraphEngineClient.Equals(tripleTupleY.GraphEngineClient) &&
                           //tripleTupleX.NewTripleStore.CellId.Equals(tripleTupleY.NewTripleStore.CellId) &&
                           tripleTupleX.NewTripleStore.TripleCell.Namespace.Equals(tripleTupleY.NewTripleStore.TripleCell.Namespace) &&
                           tripleTupleX.NewTripleStore.TripleCell.Subject.Equals(tripleTupleY.NewTripleStore.TripleCell.Subject) &&
                           tripleTupleX.NewTripleStore.TripleCell.Predicate.Equals(tripleTupleY.NewTripleStore.TripleCell.Predicate) &&
                           tripleTupleX.NewTripleStore.TripleCell.Object.Equals(tripleTupleY.NewTripleStore.TripleCell.Object);
                }
                else
                {
                    return false;
                }
                
            }

            public int GetHashCode((Storage.IStorage GraphEngineClient, TripleStore NewTripleStore) obj)
            {
                return obj.NewTripleStore.CellId.GetHashCode();
            }
        }

        /// <summary>
        ///   Let's new-up and make-ready our reactive properties for use 
        /// </summary>
        private void SetupExternalReactiveProperties()
        {
            // We initialize the ReactiveProperties to trigger based on the internal Observable

            // Reactive Use: Intended for use on the Server-side.

            TripleObjectStreamedFromServerReceivedAction =
                new ReactiveProperty<Triple>(source: TripleObjectProjectedActionSubscriber
                        .ObserveOn(ObserverOnNewThreadScheduler)
                        .Do(onNext: subscriberSource =>
                        {
                            var msg = "R-1";
                            Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                        })
                        .SubscribeOn(SubscribeOnEventLoopScheduler),
                    initialValue: new Triple(null),
                    mode: ReactivePropertyMode.None,
                    equalityComparer: _tripleEqualityCompare);

            TripleByCellIdReceivedAction =
                new ReactiveProperty<TripleStore>(source: TripleByCellIdProjectedActionSubscriber
                        .ObserveOn(ObserverOnNewThreadScheduler)
                        .Do(onNext: subscriberSource =>
                        {
                            var msg = "R-2";
                            Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                        })
                        .SubscribeOn(SubscribeOnEventLoopScheduler),
                    initialValue: new TripleStore(),
                    mode: ReactivePropertyMode.None,
                    equalityComparer: _tripleStoreEqualityCompare);

            TripleBySubjectReceivedAction =
                new ReactiveProperty<TripleStore>(source: TripleBySubjectProjectedActionSubscriber
                        .ObserveOn(ObserverOnNewThreadScheduler)
                        .Do(onNext: subscriberSource =>
                        {
                            var msg = "R-3";
                            Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                        })
                        .SubscribeOn(SubscribeOnEventLoopScheduler),
                    initialValue: new TripleStore(),
                    mode: ReactivePropertyMode.None,
                    equalityComparer: _tripleStoreEqualityCompare);

            TriplePostedToServerReceivedAction =
                new ReactiveProperty<Triple>(source: TripleObjectProjectedActionSubscriber
                        .ObserveOn(ObserverOnNewThreadScheduler)
                        .Do(onNext: subscriberSource =>
                        {
                            var msg = "R-4";
                            Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                        })
                        .SubscribeOn(SubscribeOnEventLoopScheduler),
                    initialValue: new Triple(null),
                    mode: ReactivePropertyMode.None,
                    equalityComparer: _tripleEqualityCompare);

            ServerStreamedTripleSavedToMemoryCloudAction =
                new ReactiveProperty<(Storage.IStorage GraphEngineClient, TripleStore NewTripleStore)>(
                    source: SaveServerStreamedTripleToMemoryCloudActionSubscriber
                        .ObserveOn(ObserverOnNewThreadScheduler)
                        .Do(onNext: subscriberSource =>
                        {
                            var msg = "R-5";
                            Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                        })
                        .SubscribeOn(SubscribeOnEventLoopScheduler),
                    initialValue: (GraphEngineClient: null, NewTripleStore: new TripleStore()),
                    mode: ReactivePropertyMode.None,
                    equalityComparer: _tripleTupleEqualityCompare);

            ClientPostedTripleSavedToMemoryCloudAction =
                new ReactiveProperty<(Storage.IStorage GraphEngineClient, TripleStore NewTripleStore)>(
                    source: SaveClientPostedTripleToMemoryCloudActionSubscriber
                        .ObserveOn(ObserverOnNewThreadScheduler)
                        .Do(onNext: subscriberSource =>
                        {
                            var msg = "R-6";
                            Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                        })
                        .SubscribeOn(SubscribeOnEventLoopScheduler),
                    initialValue: (GraphEngineClient: null, NewTripleStore: new TripleStore()),
                    mode: ReactivePropertyMode.None,
                    equalityComparer: _tripleTupleEqualityCompare);

            ServerStreamedTripleStoreReadyInMemoryCloudAction =
                new ReactiveProperty<TripleStore>(source: ServerStreamedTripleStoreReadyInMemoryCloudActionSubscriber
                        .ObserveOn(ObserverOnNewThreadScheduler)
                        .Do(onNext: subscriberSource =>
                        {
                            var msg = "R-7";
                            Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                        })
                        .SubscribeOn(SubscribeOnEventLoopScheduler),
                    initialValue: new TripleStore(),
                    mode: ReactivePropertyMode.None,
                    equalityComparer: _tripleStoreEqualityCompare);

            ClientPostedTripleStoreReadyInMemoryCloudAction =
                new ReactiveProperty<TripleStore>(source: ClientPostedTripleStoreReadyInMemoryCloudActionSubscriber
                        .ObserveOn(ObserverOnNewThreadScheduler)
                        .Do(onNext: subscriberSource =>
                        {
                            var msg = "R-8";
                            Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                        })
                        .SubscribeOn(SubscribeOnEventLoopScheduler),
                    initialValue: new TripleStore(),
                    mode: ReactivePropertyMode.None,
                    equalityComparer: _tripleStoreEqualityCompare);

            // Set-up HOT observable 

            ClientPostedTripleStoreReadyInMemoryCloudHotAction = ClientPostedTripleStoreReadyInMemoryCloudAction
                .ObserveOn(HotObservableSchedulerContext)
                .Do(onNext: subscriberSource =>
                {
                    var msg = "HR-1";
                    Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                })
                .SubscribeOn(HotObservableSchedulerContext)
                .Publish();
        }

        /// <summary>
        /// Setup processing for Observables ... these are the code fragments that listen observers
        /// </summary>
        private void SetUpObservables()
        {
            // Proper Initialization ...

            TripleStreamReceivedActionSubscriber = Observable
                .Empty<(Storage.IStorage GraphEngineClient, TripleStreamReader TriplePayload)>()
                .ObserveOn(scheduler: TaskPoolScheduler.Default);

            TripleStreamPostedActionSubscriber = Observable
                .Empty<(Storage.IStorage GraphEngineClient, TripleStreamReader TriplePayload)>()
                .ObserveOn(scheduler: TaskPoolScheduler.Default);

            GetTripleByCellIdRequestActionSubscriber = Observable
                .Empty<(Storage.IStorage GraphEngineClient, TripleGetRequestReader TriplePayload)>()
                .ObserveOn(scheduler: TaskPoolScheduler.Default);
            
            GetTripleBySubjectRequestActionSubscriber = Observable
                .Empty<(Storage.IStorage GraphEngineClient, TripleGetRequestReader TriplePayload)>()
                .ObserveOn(scheduler: TaskPoolScheduler.Default);

            SaveServerStreamedTripleToMemoryCloudActionSubscriber = Observable
                .Empty<(Storage.IStorage GraphEngineClient, TripleStore NewTripleStore)>()
                .ObserveOn(scheduler: TaskPoolScheduler.Default);

            SaveClientPostedTripleToMemoryCloudActionSubscriber = Observable
                .Empty<(Storage.IStorage GraphEngineClient, TripleStore NewTripleStore)>()
                .ObserveOn(scheduler: TaskPoolScheduler.Default);

            TripleObjectProjectedActionSubscriber = Observable
                .Empty<Triple>()
                .ObserveOn(scheduler: TaskPoolScheduler.Default);

            TripleByCellIdProjectedActionSubscriber = Observable
                .Empty<TripleStore>()
                .ObserveOn(scheduler: TaskPoolScheduler.Default);

            TripleBySubjectProjectedActionSubscriber = Observable
                .Empty<TripleStore>()
                .ObserveOn(scheduler: TaskPoolScheduler.Default);

            TriplePostedToServerProjectedActionSubscriber = Observable
                .Empty<Triple>()
                .ObserveOn(scheduler: TaskPoolScheduler.Default);

            SaveClientPostedTripleToMemoryCloudActionSubscriber = Observable
                .Empty<(Storage.IStorage GraphEngineClient, TripleStore NewTripleStore)>()
                .ObserveOn(scheduler: TaskPoolScheduler.Default);

            ServerStreamedTripleStoreReadyInMemoryCloudActionSubscriber = Observable
                .Empty<TripleStore>()
                .ObserveOn(scheduler: TaskPoolScheduler.Default);

            ClientPostedTripleStoreReadyInMemoryCloudActionSubscriber = Observable
                .Empty<TripleStore>()
                .ObserveOn(scheduler: TaskPoolScheduler.Default);

            // Reactive Subscriber Setup

            TripleObjectReceivedActionSubscription = TripleStreamReceivedActionSubscriber
                .SubscribeOn(SubscribeOnEventLoopScheduler)
                .Do(onNext: tripleStreamReader =>
                {
                    var msg = "A-1";
                    Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);

                })
                .Select(selector: tripleStreamReader => tripleStreamReader)
                .ObserveOn(ObserverOnNewThreadScheduler)
                .Subscribe(TripleStreamReceivedActionObserver);

            TripleSaveToMemoryCloudActionSubscription = SaveServerStreamedTripleToMemoryCloudActionSubscriber
                .SubscribeOn(SubscribeOnEventLoopScheduler)
                .Do(onNext: subscriberSource =>
                {
                    var msg = "A-2";
                    Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                })
                .Synchronize()
                .Select(selector: tripleObject => tripleObject)
                .ObserveOn(ObserverOnNewThreadScheduler)
                .Subscribe(RequestServerSaveStreamedTripleToMemoryCloudActionObserver);

            PostTripleToMemoryCloudActionSubscription = SaveClientPostedTripleToMemoryCloudActionSubscriber
                .SubscribeOn(SubscribeOnEventLoopScheduler)
                .Do(onNext: subscriberSource =>
                {
                    var msg = "A-3";
                    Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                })
                .Synchronize()
                .Select(selector: tripleObject => tripleObject)
                .ObserveOn(ObserverOnNewThreadScheduler)
                .Subscribe(SaveClientPostedTripleToMemoryCloudActionObserver);

            TripleObjectProjectedActionSubscription = TripleObjectProjectedActionSubscriber
                .SubscribeOn(SubscribeOnEventLoopScheduler)
                .Do(onNext: subscriberSource =>
                {
                    var msg = "A-4";
                    Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                })
                .Select(selector: tripleObject => tripleObject)
                .Synchronize()
                .ObserveOn(ObserverOnNewThreadScheduler)
                .Subscribe(TripleObjectProjectedActionObserver);

            TripleStoreReadyInMemoryCloudActionSubscription = ServerStreamedTripleStoreReadyInMemoryCloudActionSubscriber
                .SubscribeOn(SubscribeOnEventLoopScheduler)
                .Do(onNext: subscriberSource =>
                {
                    var msg = "A-5";
                    Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                })
                .Select(selector: tripleObject => tripleObject)
                .ObserveOn(ObserverOnNewThreadScheduler)
                .Subscribe(ServerStreamedTripleStoreReadyInMemoryCloudActionObserver);

            ClientPostedTripleReadyInMemoryCloudSubscription = ClientPostedTripleStoreReadyInMemoryCloudActionSubscriber
                .SubscribeOn(SubscribeOnEventLoopScheduler)
                .Synchronize()
                .Do(onNext: subscriberSource =>
                {
                    var msg = "A-6";
                    Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                })
                .Select(selector: tripleObject => tripleObject)
                .ObserveOn(ObserverOnNewThreadScheduler)
                .Subscribe(ClientPostedTripleStoreReadyInMemoryCloudActionObserver);

            GetTripleByCellIdActionSubscription = GetTripleByCellIdRequestActionSubscriber
                .SubscribeOn(SubscribeOnEventLoopScheduler)
                .Synchronize()
                .Do(onNext: subscriberSource =>
                {
                    var msg = "A-7";
                    Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                })
                .Select(selector: tripleObject => tripleObject)
                .ObserveOn(ObserverOnNewThreadScheduler)
                .Subscribe(GetTripleByCellIdRequestActionObserver);

            GetTripleBySubjectActionSubscription = GetTripleBySubjectRequestActionSubscriber
                .SubscribeOn(SubscribeOnEventLoopScheduler)
                .Do(onNext: subscriberSource =>
                {
                    var msg = "A-8";
                    Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                })
                .Synchronize()
                .Select(selector: tripleObject => tripleObject)
                .ObserveOn(ObserverOnNewThreadScheduler)
                .Subscribe(GetTripleBySubjectRequestActionObserver);

            PostTripleToServerActionSubscription = TripleStreamPostedActionSubscriber
                .SubscribeOn(SubscribeOnEventLoopScheduler)
                .Do(onNext: subscriberSource =>
                {
                    var msg = "A-9";
                    Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                })
                .Synchronize()
                .Select(selector: tripleObject => tripleObject)
                .ObserveOn(ObserverOnNewThreadScheduler)
                .Subscribe(TripleStreamPostedActionObserver);

            TriplePostedToServerProjectedActionSubscription = TriplePostedToServerProjectedActionSubscriber
                .SubscribeOn(SubscribeOnEventLoopScheduler)
                .Do(onNext: subscriberSource =>
                {
                    var msg = "A-10";
                    Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                })
                .Select(selector: tripleObject => tripleObject)
                .ObserveOn(ObserverOnNewThreadScheduler)
                .Subscribe(TriplePostedToServerProjectedActionObserver);
        }

        private enum QueryModeType
        {
            ByCellId = 0,
            BySubject = 1
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryModeType"></param>
        /// <param name="querySubject"></param>
        /// <returns></returns>
        private static IObservable<bool> QueryTripleStore(QueryModeType queryModeType, in TripleGetRequest querySubject)
        {
            var tripleQuerySubject = querySubject;

            return Observable.Create<bool>(observer =>
               {
                   var newTriple = new TripleStore(new Triple());

                   newTriple.TripleCell.Namespace = tripleQuerySubject.Namespace;
                   newTriple.TripleCell.Object    = tripleQuerySubject.Object;
                   newTriple.TripleCell.Predicate = tripleQuerySubject.Predicate;
                   newTriple.TripleCell.Subject   = tripleQuerySubject.Subject;

                   newTriple.CellId = tripleQuerySubject.TripleCellId;

                   if (Global.CloudStorage.IsLocalCell(newTriple.CellId) && queryModeType == QueryModeType.ByCellId)
                   {
                       observer.OnNext(true);
                       observer.OnCompleted();
                   }
                   else if (Global.CloudStorage.IsLocalCell(newTriple.CellId) && queryModeType == QueryModeType.BySubject)
                   {
                       using var tripleObject = Global.LocalStorage
                                                      .TripleStore_Accessor_Selector()
                                                      .AsParallel()
                                                      .FirstOrDefault(tripleObjectAccessor => (tripleObjectAccessor.CellId == tripleQuerySubject.TripleCellId && 
                                                                                               tripleObjectAccessor.TripleCell.Subject == tripleQuerySubject.Subject));
                       if (tripleObject is not null)
                       {
                           observer.OnNext(true);
                           observer.OnCompleted();
                       }
                       else
                       {
                           observer.OnNext(false);
                           observer.OnCompleted();
                       }
                   }

                   return Disposable.Empty;

               });
        }

        /// <summary>
        /// Server-side
        /// </summary>
        /// <param name="triple"></param>
        /// <returns></returns>
        private static IObservable<TripleSaveResponseWriter> SaveTripleToMemoryCloud(in TripleSaveRequestReader triple)
        {
            var reader = triple;

            return Observable.Create<TripleSaveResponseWriter>(observer =>
               {
                   var newTriple = new TripleStore(new Triple());

                   newTriple.TripleCell.Namespace = reader.Namespace;
                   newTriple.TripleCell.Object    = reader.Object;
                   newTriple.TripleCell.Predicate = reader.Predicate;
                   newTriple.TripleCell.Subject   = reader.Subject;

                    // Save Triple to local memory cloud and return the newly have triple to the calling client

                    if (Global.LocalStorage.SaveTripleStore(CellAccessOptions.StrongLogAhead, newTriple.CellId, newTriple))
                    {
                        var returnTripleStore = new TripleSaveResponseWriter()
                        {
                            TripleCellId = newTriple.CellId
                        };

                        observer.OnNext(returnTripleStore);
                        observer.OnCompleted();
                        return Disposable.Empty;
                    }
                    else
                    {
                        return Disposable.Empty;
                    }
               });
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetupObservers()
        {
            // A Client has sent use a Triple store 
            TripleStreamPostedActionObserver =
                Observer.Create<(Storage.IStorage GraphEngineClient, TripleStreamReader TriplePayload)>(onNext: async tripleStreamReaderObject =>
                    {
                        Triple firstTripleObject = tripleStreamReaderObject.TriplePayload.triples[0];

                        // TriplePostedToServerReceivedAction

                        TriplePostedToServerProjectedActionObserver.OnNext(firstTripleObject);

                        var myTripleStore = new TripleStore(new Triple());
                        {
                            var newTriple = firstTripleObject;
                        };

                        (long CellIdOnTriple, TripleStore NewTripleStore) sourceTripleContext = (myTripleStore.CellId, myTripleStore);

                        await Task.Delay(0).ConfigureAwait(false);

                        SaveClientPostedTripleToMemoryCloudActionObserver.OnNext((tripleStreamReaderObject.GraphEngineClient, myTripleStore));

                        //Log.WriteLine($"Triple Received from Client via PostTriplesToServer: Subject node: {firstTripleObject.Subject}");

                        // Let's save the TripleStore to the LocalStorage and let the Client know 

                        //using var tripleStreamReceivedActionTask = Task.Factory.StartNew(function: async () =>
                        //    {

                        //    },
                        //    cancellationToken: CancellationToken.None,
                        //    creationOptions: TaskCreationOptions.HideScheduler,
                        //    scheduler: TaskScheduler.Current).Unwrap();

                        //var taskResult = tripleStreamReceivedActionTask.ConfigureAwait(false);

                        //await taskResult;
                    },
                    onCompleted: () => { },
                    onError: errorContext =>
                    {
                        Log.WriteLine($"An Unexpected Error has been detected: {errorContext.Message}");
                    });

            // Client-side code Reactive Event Processing
            // Can't make any GE API Calls to save data locally; instead we make a local call back to GE App Server to save and or
            // perform additional processing.

            TripleStreamReceivedActionObserver =
                Observer.Create<(Storage.IStorage GraphEngineClient, TripleStreamReader TriplePayload)>(onNext: async tripleStreamReaderPayload =>
                    {
                        await Task.Delay(0).ConfigureAwait(false);

                        Triple myTriple = tripleStreamReaderPayload.TriplePayload.triples[0];

                        // Let the client know we are in receipt of incoming data from the GE App Server

                        TripleObjectProjectedActionObserver.OnNext(myTriple);     

                        // We need to create Prep and TripleStore for the GE App Server to save

                        var myTripleStore = new TripleStore()
                        {
                            CellId = 0,
                            TripleCell = myTriple
                        };

                        (long CellIdOnTriple, TripleStore NewTripleStore) sourceTripleContext = (myTripleStore.CellId, myTripleStore);

                        RequestServerSaveStreamedTripleToMemoryCloudActionObserver.OnNext((tripleStreamReaderPayload.GraphEngineClient, myTripleStore));

                        //Log.WriteLine($"Triple Received from Server via StreamTriplesAsync: Subject node: {sourceTripleContext.CellIdOnTriple}");
                    },
                    onCompleted: () => { },
                    onError: errorContext =>
                    {
                        Log.WriteLine($"An Unexpected Error has been detected: {errorContext.Message}");
                    });

            RequestServerSaveStreamedTripleToMemoryCloudActionObserver = Observer.Create<(Storage.IStorage GraphEngineClient, TripleStore NewTripleStore)>(onNext: async sourceTripleStore =>
                {
                    //await Task.Yield();

                    await Task.Delay(0).ConfigureAwait(false);

                    switch (Global.CommunicationInstance)
                    {
                        case TrinityClient:
                        {
                            //Log.WriteLine($"Processing: RequestServerSaveStreamedTripleToMemoryCloudActionObserver on the Client-side.");

                            var (graphEngineClient, newTripleStore) = sourceTripleStore;

                            Triple myTriple = newTripleStore.TripleCell;

                            try
                            {
                                List<Triple> collectionOfTriples = new List<Triple> {newTripleStore.TripleCell};

                                using var saveRequestWriter = new TripleSaveRequestWriter()
                                {
                                    TripleCellId = 0,
                                    Subject      = newTripleStore.TripleCell.Subject,
                                    Namespace    = newTripleStore.TripleCell.Namespace,
                                    Object       = newTripleStore.TripleCell.Object
                                };

                                var c = Global.CloudStorage.MyInstanceId;

                                string msg;

                                //Log.WriteLine($"Response from SaveTripleToTripleStore: {Global.CloudStorage[0].SaveTripleToTripleStore(saveRequestWriter).TripleCellId}");

                                //var geClientInstance = Global.CommunicationInstance.GetCommunicationModule<TrinityClientModule.TrinityClientModule>();

                                //var responseData = Global.LocalStorage.SaveTripleToTripleStore(saveRequestWriter)
                                //                         .TripleCellId;

                                using (var tripleStoreCellId = Global.CloudStorage[0].SaveTripleToTripleStore(saveRequestWriter))
                                {
                                    msg = "RequestServerSaveStreamedTripleToMemoryCloudActionObserver-1";

                                    // Let the Client know we have saved a New TripleStore to the MemoryCloud  

                                    newTripleStore.CellId = tripleStoreCellId.TripleCellId;
                                }

                                ServerStreamedTripleSavedToMemoryCloudAction.Value = (GraphEngineClient: graphEngineClient, NewTripleStore: newTripleStore);

                                ServerStreamedTripleStoreReadyInMemoryCloudActionObserver.OnNext(newTripleStore);

                                //Log.WriteLine($"Triple Object: Cell-ID from server {tripleStoreCellId.TripleCellId}");

                                //Log.WriteLine("Triple Object Streamed to Client has been saved to MemoryCloud.");

                                //Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg, Thread.CurrentThread.ManagedThreadId);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            finally
                            {
                                //requestWriterMutex.ReleaseMutex();

                                //if (requestWriterlockAcquired)
                                //    tripleGetRequestWriterSpinLock.Exit(false);
                            }

                            break;
                        }
                    }


                    //using var tripleStoreSavedToMemoryCloudTask = Task.Factory.StartNew(function: async () =>
                    //    {

                    //    },
                    //    cancellationToken: CancellationToken.None,
                    //    creationOptions: TaskCreationOptions.HideScheduler,
                    //    scheduler: TaskScheduler.Current).Unwrap();

                    //var taskResult = tripleStoreSavedToMemoryCloudTask.ConfigureAwait(false);

                    //await taskResult;
                },
        onCompleted: () => { },
        onError: errorContext =>
                 {
                     Log.WriteLine($"An Unexpected Error has been detected: {errorContext.Message}");
                 });

            // Server-side Reactive Properties the Server subscribes to

            SaveClientPostedTripleToMemoryCloudActionObserver =
                Observer.Create<(Storage.IStorage GraphEngineClient, TripleStore NewTripleStore)>(onNext: async sourceTripleStore =>
                {
                    await Task.Delay(0).ConfigureAwait(false);

                    var (idOnTriple, store) = sourceTripleStore;

                    if (Global.LocalStorage.SaveTripleStore(CellAccessOptions.StrongLogAhead, store.CellId))
                    {
                        var msg = "SaveClientPostedTripleToMemoryCloudActionObserver-1";

                        Log.WriteLine("{0} Subscription happened on this Thread: {1}", msg,
                            Thread.CurrentThread.ManagedThreadId);

                        try
                        {
                            using var tripleStore = Global.LocalStorage.UseTripleStore(store.CellId, CellAccessOptions.StrongLogAhead);

                            using var tripleStoreStreamWriter1 = new TripleGetRequestWriter()
                            {
                                TripleCellId  = tripleStore.CellId,
                                Subject       = tripleStore.TripleCell.Subject,
                                Namespace     = tripleStore.TripleCell.Namespace,
                                Object        = tripleStore.TripleCell.Object
                            };

                            Log.WriteLine($"Cell-ID from newly saved Triple Store Object: {tripleStore.CellId}");

                            //List<Triple> collectionOfTriples = new List<Triple> { sourceTripleStore.NewTripleStore.TripleCell };

                            //using var storeStreamWriter = new TripleGetRequestWriter()
                            //{
                            //    TripleCellId = sourceTripleStore.NewTripleStore.CellId,
                            //    Subject = sourceTripleStore.NewTripleStore.TripleCell.Subject,
                            //    Namespace = sourceTripleStore.NewTripleStore.TripleCell.Namespace,
                            //    Object = sourceTripleStore.NewTripleStore.TripleCell.Object
                            //};

                            ClientPostedTripleStoreReadyInMemoryCloudActionObserver.OnNext(store);

                            ClientPostedTripleSavedToMemoryCloudAction.Value = (null, store);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        finally
                        {
                            //if (requestWriterlockAcquired)
                            //    tripleGetRequestWriterSpinLock.Exit(false);
                        }
                    }
                },
        onCompleted: () => { },
        onError: errorContext =>
                 {
                     Log.WriteLine($"An Unexpected Error has been detected: {errorContext.Message}");
                 });

            GetTripleByCellIdRequestActionObserver =
                Observer.Create<(Storage.IStorage GraphEngineClient, TripleGetRequestReader TriplePayload)>(onNext: async tripleGetRequestReader =>
                    {
                        await Task.Delay(0).ConfigureAwait(false);

                        try
                        {
                            //tripleGetRequestReaderSpinLock.Enter(ref requestReaderlockAcquired);
                            //requestWriterMutex.WaitOne();


                            var tripleStoreObject = new TripleStore(
                                tripleGetRequestReader.TriplePayload.TripleCellId, new Triple(
                                    tripleGetRequestReader.TriplePayload.Subject,
                                    tripleGetRequestReader.TriplePayload.Predicate,
                                    tripleGetRequestReader.TriplePayload.Object,
                                    tripleGetRequestReader.TriplePayload.Namespace));

                            // Let's save the TripleStore to the LocalStorage and let the Client know 

                            TripleByCellIdProjectedActionObserver.OnNext(tripleStoreObject);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                        finally
                        {
                            //requestWriterMutex.ReleaseMutex();

                            //if (requestReaderlockAcquired)
                            //    tripleGetRequestReaderSpinLock.Exit(false);
                        }
                    },
                    onCompleted: () => { },
                    onError: errorContext =>
                    {
                        Log.WriteLine($"An Unexpected Error has been detected: {errorContext.Message}");
                    });

            // This code runs in the Client address space

            GetTripleBySubjectRequestActionObserver =
                Observer.Create<(Storage.IStorage GraphEngineClient, TripleGetRequestReader TriplePayload)>(
                    onNext: async tripleGetRequestReader =>
                            {
                                await Task.Delay(0).ConfigureAwait(false);

                                //var tripleStoreFromMemoryCloud = Global.LocalStorage.TripleStore_Accessor_Selector()
                                //    //.Select(tripleObject => tripleObject)
                                //    .Where(tripleNode => tripleNode.CellId.Equals(tripleGetRequestReader.TriplePayload.TripleCellId) &&
                                //                                        tripleNode.TripleCell.Subject.Contains(tripleGetRequestReader.TriplePayload.Subject))
                                //    .Select(objectTripleFromMemoryCloud => objectTripleFromMemoryCloud.TripleCell)
                                //    .FirstOrDefault();

                                //foreach (var tripleStoreAccessorFromMC in Global.LocalStorage.TripleStore_Accessor_Selector())
                                //{
                                //    if (tripleStoreAccessorFromMC.CellId == tripleGetRequestReader.TriplePayload.TripleCellId)
                                //    {
                                //        var test = "We got this far";

                                //    }
                                //}

                                //requestReaderlockAcquired = false;

                                try
                                {
                                    //tripleGetRequestReaderSpinLock.Enter(ref requestReaderlockAcquired);

                                    //requestReaderMutex.WaitOne();

                                    TripleStore tripleStoreObject = new TripleStore(
                                        tripleGetRequestReader.TriplePayload.TripleCellId, new Triple(
                                            tripleGetRequestReader.TriplePayload.Subject,
                                            tripleGetRequestReader.TriplePayload.Predicate,
                                            tripleGetRequestReader.TriplePayload.Object,
                                            tripleGetRequestReader.TriplePayload.Namespace));

                                    // Let's save the TripleStore to the LocalStorage and let the Client know 

                                    TripleBySubjectProjectedActionObserver.OnNext(tripleStoreObject);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                                finally
                                {
                                   // requestReaderMutex.ReleaseMutex();

                                    //if (requestReaderlockAcquired)
                                    //    tripleGetRequestReaderSpinLock.Exit(false);
                                }

                                //using var getTripleQueryTask = Task.Factory.StartNew(function: async () =>
                                //    {

                                //    },
                                //    cancellationToken: CancellationToken.None,
                                //    creationOptions: TaskCreationOptions.HideScheduler,
                                //    scheduler: TaskScheduler.Current).Unwrap();

                                //var taskResult = getTripleQueryTask.ConfigureAwait(false);

                                //await taskResult;
                            },
                    onCompleted: () => { },
                    onError: errorContext =>
                             {
                                 Log.WriteLine($"An Unexpected Error has been detected: {errorContext.Message}");
                             });

            // Client-side Reactive Properties the Client subscribes to

            TripleObjectProjectedActionObserver = 
                Observer.Create<Triple>(onNext: sourceTriple =>
                    {
                        TripleObjectStreamedFromServerReceivedAction.Value = sourceTriple;
                    },
                onCompleted: () => { },
                onError: errorContext =>
                {
                    Log.WriteLine($"An Unexpected Error has been detected: {errorContext.Message}");
                });

            ServerStreamedTripleStoreReadyInMemoryCloudActionObserver = 
                Observer.Create<TripleStore>(onNext: sourceTripleStore =>
                    {
                        ServerStreamedTripleStoreReadyInMemoryCloudAction.Value = sourceTripleStore;
                    },
                onCompleted: () => { },
                onError: errorContext =>
                {
                    Log.WriteLine($"An Unexpected Error has been detected: {errorContext.Message}");
                });

            ClientPostedTripleStoreReadyInMemoryCloudActionObserver =
                Observer.Create<TripleStore>(onNext: sourceTripleStore =>
                    {
                        ClientPostedTripleStoreReadyInMemoryCloudAction.Value = sourceTripleStore;
                    },
                    onCompleted: () => { },
                    onError: errorContext =>
                    {
                        Log.WriteLine($"An Unexpected Error has been detected: {errorContext.Message}");
                    });

            TriplePostedToServerProjectedActionObserver = 
                Observer.Create<Triple>(onNext: sourceTriple =>
                    {
                        TriplePostedToServerReceivedAction.Value = sourceTriple;
                    },
                onCompleted: () => { },
                onError: errorContext =>
                {
                    Log.WriteLine($"An Unexpected Error has been detected: {errorContext.Message}");
                });

            TripleByCellIdProjectedActionObserver  =
                Observer.Create<TripleStore>(onNext: sourceTriple =>
                    {
                         TripleByCellIdReceivedAction.Value = sourceTriple;
                    }, 
                onCompleted: () => { },
                onError: errorContext =>
                {
                    Log.WriteLine($"An Unexpected Error has been detected: {errorContext.Message}");
                });

            TripleBySubjectProjectedActionObserver =
                Observer.Create<TripleStore>(onNext: sourceTriple =>
                    {
                        TripleBySubjectReceivedAction.Value = sourceTriple;
                    },
                onCompleted: () => { },
                onError: errorContext =>
                {
                    Log.WriteLine($"An Unexpected Error has been detected: {errorContext.Message}");
                });
        }

        //public override string GetModuleName() => "TripleModule";
        private static TripleModule TripleClientSideModule { get; set; } = null;

        // To be received on the server side
        /// <summary>
        /// As this call originates from the Client side of the Symmetric TCP/RPC runtime; the GE App Server
        /// will response to this handler.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public override void PostTriplesToServerHandler(TripleStreamReader request, ErrorCodeResponseWriter response)
        {
            // Setup Communications Guard so that this code will only execute on the GE App Server-side

            switch (Global.CommunicationInstance)
            {
                case null:
                    break;
                case TrinityClient:
                case TripleAppServerGatewayBase:
                case TrinityProxy:
                {
                    throw new InvalidOperationException("This code can only be executed on the GE App Server-side");
                }
                case TrinityServer:
                {
                    response.errno = 100;
                    response.QueryResult = false;

                    //TripleStoreServer = Global.CommunicationInstance as TrinityServer;

                    (IStorage GraphEngineClient, TripleStreamReader TriplePayload) requestPayload = (null, request);

                    TripleStreamPostedActionObserver.OnNext(requestPayload);

                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public override void GetTripleByCellIdHandler(TripleGetRequestReader request, ErrorCodeResponseWriter response)
        {
            response.errno = 0;

            switch (Global.CommunicationInstance)
            {
                case null:
                    break;
                case TrinityClient:
                case TripleAppServerGatewayBase:
                case TrinityProxy:
                {
                    throw new InvalidOperationException("This code can only be executed on the GE App Server-side");
                }
                case TrinityServer:
                {
                    (IStorage GraphEngineClient, TripleGetRequestReader TriplePayload) requestPayload = (TripleStoreClient, request);

                    GetTripleByCellIdRequestActionObserver.OnNext(requestPayload);

                    var getQueryRequestPayload = new TripleGetRequest()
                    {
                        Namespace = request.Namespace,
                        Subject = request.Subject,
                        Predicate = request.Predicate,
                        Object = request.Object,
                        TripleCellId = request.TripleCellId
                    };

                    QueryTripleStore(QueryModeType.ByCellId, getQueryRequestPayload)
                    .Subscribe(queryResponse =>
                       {
                           response.QueryResult = queryResponse;
                       });

                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public override void GetTripleSubjectHandler(TripleGetRequestReader request, ErrorCodeResponseWriter response)
        {
            response.errno = 0;

            switch (Global.CommunicationInstance)
            {
                case null:
                    break;
                case TrinityClient:
                case TripleAppServerGatewayBase:
                case TrinityProxy:
                {
                    throw new InvalidOperationException("This code can only be executed on the GE App Server-side");
                }
                case TrinityServer:
                {
                    (IStorage GraphEngineClient, TripleGetRequestReader TriplePayload) requestPayload = (TripleStoreClient, request);

                    GetTripleBySubjectRequestActionObserver.OnNext(requestPayload);

                    var getQueryRequestPayload = new TripleGetRequest()
                    {
                        Namespace = request.Namespace,
                        Subject = request.Subject,
                        Predicate = request.Predicate,
                        Object = request.Object,
                        TripleCellId = request.TripleCellId
                    };

                    QueryTripleStore(QueryModeType.BySubject, getQueryRequestPayload)
                    .Subscribe(queryResponse =>
                       {
                           response.QueryResult = queryResponse;
                       });

                    break;
                }
            }
        }

        /// <summary>
        /// Client-side RPC Call
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public override void PushTripleToClientHandler(TripleGetRequestReader request, ErrorCodeResponseWriter response)
        {
            //(IStorage GraphEngineClient, TripleGetRequestReader TriplePayload) requestPayload = (null, request);

            //GetTripleBySubjectRequestActionObserver.OnNext(requestPayload);

            response.errno = 400;
        }

        /// <summary>
        /// Server-side Symmetric TPC/RPC Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public override void SaveTripleToTripleStoreHandler(TripleSaveRequestReader request, TripleSaveResponseWriter response)
        {
            switch (Global.CommunicationInstance)
            {
                case null:
                    break;
                case TrinityClient:
                case TripleAppServerGatewayBase:
                case TrinityProxy:
                {
                    throw new InvalidOperationException("This code can only be executed on the GE App Server-side");
                }
                case TrinityServer:
                {
                    SaveTripleToMemoryCloud(request)
                        .Subscribe(saveTripleResponse => response.TripleCellId = saveTripleResponse.TripleCellId);

                    break;
                }
            }
        }

        // To be received on the client side
        /// <summary>
        /// Called from the server side so the GE Client will execute this handler.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public override void StreamTriplesAsyncHandler(TripleStreamReader request, ErrorCodeResponseWriter response)
        {
            switch (Global.CommunicationInstance)
            {
                case null:
                    break;
                case TripleAppServerGatewayBase appServerGatewayBase:
                case TrinityProxy trinityProxy:
                case TrinityServer trinityServer:
                {
                    throw new InvalidOperationException("This code can only be executed on the GE Client-side");
                }
                case TrinityClient:
                {
                    if (Global.CommunicationInstance is TrinityClient trinityTripleClientModule)
                    {
                        (IStorage GraphEngineClient, TripleStreamReader TriplePayload) requestPayload = (TripleStoreClient, request);

                        TripleStreamReceivedActionObserver.OnNext(requestPayload);

                        response.errno = 0;
                    }

                    break;
                }
                default:
                    throw new InvalidOperationException("This code can only be executed on the GE Client-side");
            }
        }

        public override string GetModuleName() => "TripleModule";
    }
}
