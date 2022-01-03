using System.Net;
using Trinity.Client;
using Trinity.Client.TrinityClientModule;
using Trinity.Extension;
using Trinity.Network;

namespace IKW.Advanced.GE.Server.SymmetricRuntime.Implementation
{
    [AutoRegisteredCommunicationModule]
    public class TripleStoreServerModule : TripleServerBase
    {
        // Let's use RX to setup Subscription based processing of object with the intention of
        // the UI viewModel and WPF code-behind to hook-up to presenting to the UI; our Test Server
        // is pushing triples to our WPF client

        private TrinityClientModule? TripleStoreClientModule { get; set; }
        private TrinityServer? TripleStoreServer { get; set; }

        private TrinityClient TrinityTripleClient { get; set; }

        // Dynamically gain access to the client connection
        private Trinity.Storage.IStorage TripleStoreClient { get; set; }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void PushTripleToClientHandler(TripleGetRequestReader request, ErrorCodeResponseWriter response)
        {
            throw new NotImplementedException();
        }

        public override void StreamTriplesAsyncHandler(TripleStreamReader request, ErrorCodeResponseWriter response)
        {
            throw new NotImplementedException();
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        protected override void DispatchHttpRequest(HttpListenerContext context, string endpoint_name, string url)
        {
            base.DispatchHttpRequest(context, endpoint_name, url);
        }

        protected override void RegisterMessageHandler()
        {
            base.RegisterMessageHandler();
        }

        protected override void RootHttpHandler(HttpListenerContext ctx)
        {
            base.RootHttpHandler(ctx);
        }

        protected override void StartCommunicationListeners()
        {
            base.StartCommunicationListeners();
        }

        protected override void StopCommunicationListeners()
        {
            base.StopCommunicationListeners();
        }
    }
}