using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using Trinity.Client;
using Trinity.Client.TestProtocols;
using Trinity.Client.TestProtocols.TripleServer;
using Trinity.Diagnostics;

namespace Trinity.WPF.TestClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TrinityClient TrinityTripleModuleClient { get; set; } = new TrinityClient("GenNexusPrime.inknowworksdev.net:5304");
        private TripleStoreRuntimeModule ClientSideStoreRuntimeModule { get; set; } = null;
        private ClientRegistrationResponseReader ForPushAutomation { get; set; } = null;

        public MainWindow()
        {
            InitializeComponent();

            TrinityConfig.CurrentRunningMode = RunningMode.Client;

            TrinityTripleModuleClient.RegisterCommunicationModule<TripleStoreRuntimeModule>();

            // Hook up to Graph Engine Reactive .. 

            TrinityTripleModuleClient.Start();

            ClientSideStoreRuntimeModule = TrinityTripleModuleClient.GetCommunicationModule<TripleStoreRuntimeModule>();

            ForPushAutomation = TrinityTripleModuleClient.RegisterForPushAutomation(new ClientRegistrationRequestWriter(TrinityTripleModuleClient.ClientMessageId));

            var uiSyncContext = TaskScheduler.FromCurrentSynchronizationContext();

            var token = Task.Factory.CancellationToken;

            // Setup Reactive Processing .. 

            ClientSideStoreRuntimeModule.TripleBySubjectReceivedAction
              .ObserveOn(ClientSideStoreRuntimeModule.ObserverOnNewThreadScheduler)
              .Do(onNext: async subscriberSource =>
                  {
                      var msg = "TripleBySubjectReceivedAction-1";

                      using var reactiveGraphEngineResponseTask = Task.Factory.StartNew(
                          async () =>
                          {
                              await Task.Factory.StartNew(() =>
                                  {
                                      ResponseTextBlock.Items.Add(
                                          $"{msg} Subscription happened on this Thread: {Thread.CurrentThread.ManagedThreadId}");

                                  }, token,
                                  TaskCreationOptions.None,
                                  uiSyncContext);
                          });

                      var upDateOnUITread = reactiveGraphEngineResponseTask;

                      await upDateOnUITread.ConfigureAwait(false);
                  })
              .SubscribeOn(ClientSideStoreRuntimeModule.SubscribeOnEventLoopScheduler)
              .Subscribe(onNext: async tripleStore =>
                 {
                     using var reactiveGetTripleBySubjectTask = Task.Factory.StartNew(async () =>
                       {
                           await Task.Factory.StartNew(() =>
                           {
                               CellIdTb.Text    = tripleStore.CellId.ToString();
                               NameSpaceTb.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                               SubjectTb.Text   = tripleStore.TripleCell.Subject;
                               PredicateTb.Text = tripleStore.TripleCell.Predicate;
                               ObjectTb.Text    = tripleStore.TripleCell.Object;

                               var cell = Trinity.Global.CloudStorage.LoadGenericCell(tripleStore.CellId);

                           },token,
                             TaskCreationOptions.None,
                             uiSyncContext);
                       }).ContinueWith(_ =>
                       {
                           ResponseTextBlock.Items.Add("Task TripleObjectStreamedFromServerReceivedAction Complete...");
                       }, uiSyncContext);

                     var upDateOnUITread = reactiveGetTripleBySubjectTask;

                     await upDateOnUITread;
                 });


            // Reactive Event Stream Processing: ClientSideStoreRuntimeModule.TripleObjectStreamedFromServerReceivedAction


            ClientSideStoreRuntimeModule.TripleObjectStreamedFromServerReceivedAction
              .ObserveOn(ClientSideStoreRuntimeModule.ObserverOnNewThreadScheduler)
              .Do(onNext: async subscriberSource =>
                  {
                      var msg = "TripleObjectStreamedFromServerReceivedAction-1";

                      using var reactiveGraphEngineResponseTask = Task.Factory.StartNew(
                          async () =>
                          {
                              await Task.Factory.StartNew(() =>
                              {
                                  ResponseTextBlock.Items.Add("Incoming Triple Object Streamed from Server.");
                                  ResponseTextBlock.Items.Add($"{msg} Subscription happened on this Thread: {Thread.CurrentThread.ManagedThreadId}");
                              },
                              token,
                              TaskCreationOptions.None,
                              uiSyncContext);
                          });

                      var upDateOnUITread = reactiveGraphEngineResponseTask;

                      await upDateOnUITread.ConfigureAwait(false);
                  })
              .SubscribeOn(ClientSideStoreRuntimeModule.SubscribeOnEventLoopScheduler)
              .Subscribe(onNext: async tripleObjectFromServer =>
                  {
                     using var reactiveGraphEngineResponseTask = Task.Factory
                         .StartNew(async () =>
                           {
                               await Task.Factory.StartNew(() =>
                               {
                                   NameSpaceTb.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                                   SubjectTb.Text   = tripleObjectFromServer.Subject;
                                   PredicateTb.Text = tripleObjectFromServer.Predicate;
                                   ObjectTb.Text    = tripleObjectFromServer.Object;
                                   CellIdTb.Text    = string.Empty;
                               },token,
                                 TaskCreationOptions.None,
                                 uiSyncContext);
                           }).ContinueWith(_ => ResponseTextBlock.Items.Add("Task TripleObjectStreamedFromServerReceivedAction Complete..."), uiSyncContext);

                     var upDateOnUITread = reactiveGraphEngineResponseTask;

                     await upDateOnUITread;
                  });

            ClientSideStoreRuntimeModule.ServerStreamedTripleStoreReadyInMemoryCloudAction
              .ObserveOn(ClientSideStoreRuntimeModule.ObserverOnNewThreadScheduler)
              .Do(onNext: async subscriberSource =>
                  {
                      var msg = "ServerStreamedTripleStoreReadyInMemoryCloudAction-1";

                      using var reactiveGraphEngineResponseTask = Task.Factory.StartNew(
                          async () =>
                          {
                              await Task.Factory.StartNew(() =>
                              {
                                  ResponseTextBlock.Items.Add("Detected TripleStore is Ready in MemoryCloud.");
                                  ResponseTextBlock.Items.Add($"{msg} Subscription happened on this Thread: {Thread.CurrentThread.ManagedThreadId}");
                              },token,
                                TaskCreationOptions.None,
                                uiSyncContext);
                          });

                      var upDateOnUITread = reactiveGraphEngineResponseTask;

                      await upDateOnUITread.ConfigureAwait(false);
                  })
              .SubscribeOn(ClientSideStoreRuntimeModule.SubscribeOnEventLoopScheduler)
              .Subscribe(onNext: tripleObjectFromMC1 => ProcessDataFromServer(tripleObjectFromMC1, uiSyncContext, token));

            ClientSideStoreRuntimeModule.ServerStreamedTripleSavedToMemoryCloudAction
                .ObserveOn(ClientSideStoreRuntimeModule.ObserverOnNewThreadScheduler)
                .Do(onNext: async subscriberSource =>
                    {
                        var msg = "ServerStreamedTripleSavedToMemoryCloudAction-1";

                        using var reactiveGraphEngineResponseTask = Task.Factory.StartNew(
                            async () =>
                            {
                                await Task.Factory.StartNew(() =>
                                {
                                    ResponseTextBlock.Items.Add("Incoming TripleStore Object retrieved from MemoryCloud.");
                                    ResponseTextBlock.Items.Add($"{msg} Subscription happened on this Thread: {Thread.CurrentThread.ManagedThreadId}");
                                },
                                    token,
                                    TaskCreationOptions.None,
                                    uiSyncContext);
                            });

                        var upDateOnUITread = reactiveGraphEngineResponseTask;

                        await upDateOnUITread.ConfigureAwait(false);
                    })
                .SubscribeOn(ClientSideStoreRuntimeModule.SubscribeOnEventLoopScheduler)
                .Subscribe(onNext: async tripleObjectFromMC =>
                   {
                       using var reactiveGraphEngineResponseTask = Task.Factory.StartNew(async () =>
                       {
                           await Task.Factory.StartNew(async () =>
                               {
                                   var myTripleStore = tripleObjectFromMC.NewTripleStore;

                                   ResponseTextBlock.Items.Add($"CellId: {tripleObjectFromMC.NewTripleStore.CellId.ToString()}");
                                   ResponseTextBlock.Items.Add($"Processing Timestamp: {DateTime.Now.ToString(CultureInfo.InvariantCulture)}");
                                   ResponseTextBlock.Items.Add($"Subject  : {myTripleStore.TripleCell.Subject}");
                                   ResponseTextBlock.Items.Add($"Predicate: {myTripleStore.TripleCell.Predicate}");
                                   ResponseTextBlock.Items.Add($"Object   : {myTripleStore.TripleCell.Object}");

                                   var cell = Trinity.Global.CloudStorage.LoadGenericCell(tripleObjectFromMC.NewTripleStore.CellId);

                                   Trinity.Global.CloudStorage.SaveGenericCell(cell);

                                   var fieldNames = cell.GetFieldNames();

                                   var rpcResponseCodeB = await TrinityTripleModuleClient.GetTripleSubject(new TripleGetRequestWriter()
                                   {
                                       Subject = myTripleStore.TripleCell.Subject,
                                       Namespace = myTripleStore.TripleCell.Namespace,
                                       Predicate = myTripleStore.TripleCell.Predicate,
                                       Object = myTripleStore.TripleCell.Object,
                                       TripleCellId = tripleObjectFromMC.NewTripleStore.CellId
                                   }).ConfigureAwait(false);

                                   ResponseTextBlock.Items.Add(rpcResponseCodeB.QueryResult
                                       ? $"Query Triple Object (Using CellId+Subject): {tripleObjectFromMC.NewTripleStore.CellId}, does exist in GE App Server Local Memory Cloud."
                                       : $"Query Triple Object (Using CellId+Subject): {tripleObjectFromMC.NewTripleStore.CellId}, does NOT exist in GE App Server Local Memory Cloud.");

                               }, token,
                                  TaskCreationOptions.None,
                                  uiSyncContext);
                       }).ContinueWith(_ => ResponseTextBlock.Items.Add("Task ServerStreamedTripleSavedToMemoryCloudAction Complete..."), uiSyncContext);

                       var upDateOnUITread = reactiveGraphEngineResponseTask;

                       await upDateOnUITread;
                   });

            ClientSideStoreRuntimeModule.TripleByCellIdReceivedAction
                .ObserveOn(ClientSideStoreRuntimeModule.ObserverOnNewThreadScheduler)
                .Do(onNext: async subscriberSource =>
                    {
                        var msg = "TripleByCellIdReceivedAction-1";

                        using var reactiveGraphEngineResponseTask = Task.Factory.StartNew(
                            async () =>
                            {
                                await Task.Factory.StartNew(() =>
                                {
                                    ResponseTextBlock.Items.Add($"Process results from GetTripleByCellId RPC Request.");
                                    ResponseTextBlock.Items.Add($"Reactive Async - Server-Side Get Request on behalf of the Client.");
                                    ResponseTextBlock.Items.Add($"{msg} Subscription happened on this Thread: {Thread.CurrentThread.ManagedThreadId}");
                                },
                                token,
                                TaskCreationOptions.None,
                                uiSyncContext);
                        });

                        var upDateOnUITread = reactiveGraphEngineResponseTask;

                        await upDateOnUITread.ConfigureAwait(false);
                    })
                .SubscribeOn(ClientSideStoreRuntimeModule.SubscribeOnEventLoopScheduler)
                .Synchronize()
                .Subscribe(onNext: async tripleObjectFromGetRequest =>
                {
                    using var reactiveGraphEngineResponseTask = Task.Factory.StartNew(async () =>
                    {
                        await Task.Factory.StartNew(() =>
                        {
                            var myTripleStore = tripleObjectFromGetRequest.TripleCell;

                            CellIdTb.Text    = tripleObjectFromGetRequest.CellId.ToString();
                            NameSpaceTb.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                            SubjectTb.Text   = myTripleStore.Subject;
                            PredicateTb.Text = myTripleStore.Predicate;
                            ObjectTb.Text    = myTripleStore.Object;
                        }, token,
                           TaskCreationOptions.None,
                           uiSyncContext);
                    }).ContinueWith(_ =>
                    {
                        ResponseTextBlock.Items.Add("Task TripleByCellIdReceivedAction Complete...");
                    }, uiSyncContext);

                    var upDateOnUITread = reactiveGraphEngineResponseTask;

                    await upDateOnUITread.ConfigureAwait(false);
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tripleObjectFromMC"></param>
        /// <param name="uiSyncContext"></param>
        /// <param name="token"></param>
        private async void ProcessDataFromServer(TripleStore tripleObjectFromMC, TaskScheduler uiSyncContext, CancellationToken token)
        {
            using var reactiveGraphEngineResponseTask = Task.Factory.StartNew(async () =>
              {
                  await Task.Factory.StartNew(async () =>
                  {
                      var myTripleStore = tripleObjectFromMC.TripleCell;

                      ResponseTextBlock.Items.Add("Make Client-side GetTripleBy Cell and by Subject RPC Request Calls.");

                      var rpcResponseCode = await TrinityTripleModuleClient.GetTripleByCellId(new TripleGetRequestWriter()
                      {
                          Subject = myTripleStore.Subject,
                          Namespace = myTripleStore.Namespace,
                          Predicate = myTripleStore.Predicate,
                          Object = myTripleStore.Object,
                          TripleCellId = tripleObjectFromMC.CellId
                      }).ConfigureAwait(false);

                      ResponseTextBlock.Items.Add(rpcResponseCode.QueryResult
                          ? $"Query Triple Object (Using CellId): {tripleObjectFromMC.CellId}, does exist in GE App Server Local Memory Cloud."
                          : $"Query Triple Object (Using CellId): {tripleObjectFromMC.CellId}, does NOT exist in GE App Server Local Memory Cloud.");

                  }, token, TaskCreationOptions.None, uiSyncContext);
              }, token).ContinueWith(_ => ResponseTextBlock.Items.Add("Task ServerStreamedTripleStoreReadyInMemoryCloudAction Complete..."), uiSyncContext);

            var upDateOnUITread = reactiveGraphEngineResponseTask;

            await upDateOnUITread.ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TalkToGraphEngineClientBtn_Click(object sender, RoutedEventArgs e)
        {
            var uiSyncContext = TaskScheduler.FromCurrentSynchronizationContext();

            var triples = new List<Triple> { new Triple { Subject = "WPF-GraphEngineClient", Predicate = "isA", Object = $"Success @ {DateTime.Now.ToLocalTime()}" } };

            using var graphEngineRpcTask = Task.Factory.StartNew(async () =>
             {
                 using var streamWriterMessage = new TripleStreamWriter(ForPushAutomation.PushAutomationRegId, Global.CloudStorage.MyInstanceId, triples);

                 var rsp = await TrinityTripleModuleClient.PostTriplesToServer(streamWriterMessage);

                 var token = Task.Factory.CancellationToken;

                 await Task.Factory.StartNew(() =>
                 {
                     ResponseTextBlock.Items.Add($"Executed PostTriplesToServer RPC call to server with Asynchronous Reactive Event Handler.");
                     ResponseTextBlock.Items.Add($"GE Server Response: {rsp.errno}");
                 },token, 
                   TaskCreationOptions.None,
                   uiSyncContext);
             }).ContinueWith(_ => ResponseTextBlock.Items.Add("Task PostTriplesToServer Complete..."), uiSyncContext);


            Task taskResult = graphEngineRpcTask;

            await taskResult.ConfigureAwait(false);
        }
    }
}
