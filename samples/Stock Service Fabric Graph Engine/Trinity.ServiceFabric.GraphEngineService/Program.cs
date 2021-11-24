﻿using FanoutSearch;
using System.Threading;
using Trinity.Azure.Storage;
using Trinity.Diagnostics;
using Trinity.DynamicCluster.Storage;
using Trinity.ServiceFabric;
using Trinity.ServiceFabric.Remoting;
using Trinity.ServiceFabric.SampleProtocols;
using Trinity.ServiceFabric.SampleProtocols.ServiceFabricSampleModule;

namespace Trinity.SampleApplication.ServiceFabric
{
    using System.Linq;

    // Workaround: extension assembly will be removed by the
    // compiler if it is not explicitly used in the code.
    [UseExtension(typeof(BlobStoragePersistentStorage))]
    [UseExtension(typeof(ITrinityOverRemotingService))]
    [UseExtension(typeof(FanoutSearchModule))]
    [UseExtension(typeof(SampleModuleImpl))]
    internal static class Program
    {
        private static SampleModuleImpl sampleModule = null;
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            // The ServiceManifest.XML file defines one or more service type names.
            // Registering a service maps a service type name to a .NET type.
            // When Service Fabric creates an instance of this service type,
            // an instance of the class is created in this host process.

            // When StartService returns, it is guaranteed that Global.CloudStorage
            // is fully operational, and Global.CommunicationInstance is successfully
            // started.

            GraphEngineService.StartServiceAsync("Trinity.ServiceFabric.GraphEngineServiceType").GetAwaiter().GetResult();

            // Global.Communications runtime is ready

            var sampleModuleImplementation = Global.CommunicationInstance;

            var graphEngineModules = Global.CommunicationInstance.GetRegisteredCommunicationModuleTypes();

            foreach (var _ in graphEngineModules.Where(module => module.Assembly.FullName == nameof(SampleModuleImpl)).Select(module => new { }))
            {
                var p = Global.CommunicationInstance.CloudStorage.MyPartitionId;
                sampleModule = Global.CommunicationInstance.GetCommunicationModule<SampleModuleImpl>();
                sampleModule.Ping(p);
            }

            // Also, pay attention that, only *master replicas of the partitions* reach here.
            // When the cluster is shutting down, it is possible that the secondary replicas
            // become the master. However, these "transient" masters will be blocked, and
            // do not reach this point.

            Log.WriteLine("Hello world from GE-SF integration!");

            var memcloud = Global.CloudStorage as DynamicMemoryCloud;

            // Prevents this host process from terminating so services keep running.
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
