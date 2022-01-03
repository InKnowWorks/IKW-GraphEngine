// See https://aka.ms/new-console-template for more information

using IKW.Advanced.GE.Server.SymmetricRuntime;
using IKW.Advanced.GE.Server.SymmetricRuntime.Implementation;
using Trinity;

namespace IKW.Advanced.GE.TripleStore.AppServer
{
    internal class Program
    {
        private TripleStoreServerModule TripleStoreServerImpl { get; set; } = new TripleStoreServerModule();

        public static async Task<Task> Main(string[] args)
        {
            await Task.Delay(0).ConfigureAwait(false);

            Console.WriteLine("Hello, World!");
            return Task.CompletedTask;
        }
    }
}

