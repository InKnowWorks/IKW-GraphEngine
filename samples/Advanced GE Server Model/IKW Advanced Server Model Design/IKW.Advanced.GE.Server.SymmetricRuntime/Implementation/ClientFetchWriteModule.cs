namespace IKW.Advanced.GE.Server.SymmetricRuntime.Implementation
{
    internal class ClientFetchWriteModule : ClientTripleStoreFetchWriteModuleBase
    {
        public override void FetchTripleAsyncHandler(TripleReader request)
        {
            throw new NotImplementedException();
        }

        public override string GetModuleName() => "ClientFetchWriteModule";

        public override void WriteTripleAsyncHandler(TripleReader request)
        {
            throw new NotImplementedException();
        }
    }
}
