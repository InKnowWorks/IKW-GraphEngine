namespace IKW.Advanced.GE.Server.SymmetricRuntime.Implementation;
using IKW.Advanced.GE.Server.SymmetricRuntime;

public class ClientTripleStoreModule : ClientTripleStoreModuleBase
{
    public override string GetModuleName() => "ClientTripleStoreModule";

    public override void PostTriplesToServerHandler(TripleStreamReader request, ErrorCodeResponseWriter response)
    {
        throw new NotImplementedException();
    }

    public override void GetTripleByCellIdHandler(TripleGetRequestReader request, ErrorCodeResponseWriter response)
    {
        throw new NotImplementedException();
    }

    public override void GetTripleSubjectHandler(TripleGetRequestReader request, ErrorCodeResponseWriter response)
    {
        throw new NotImplementedException();
    }

    public override void PushTripleToClientHandler(TripleGetRequestReader request, ErrorCodeResponseWriter response)
    {
        throw new NotImplementedException();
    }

    public override void SaveTripleToMemoryCloudHandler(TripleGetRequestReader request, TripleSaveRequestWriter response)
    {
        throw new NotImplementedException();
    }
}