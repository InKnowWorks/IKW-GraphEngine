﻿using System.Threading.Tasks;
using Trinity.Configuration;
using Trinity.Diagnostics;
using Trinity.Network;
using Trinity.Storage;

namespace Trinity.Client
{
    internal class DefaultClientConnection : RemoteStorage, IMessagePassingEndpoint
    {
        private ICommunicationModuleRegistry m_modules;

        protected internal DefaultClientConnection(ServerInfo server, ICommunicationModuleRegistry modules)
            : base(new[] { server }, NetworkConfig.Instance.ClientMaxConn, null, -1, nonblocking: true)
        {
            m_modules = modules;
        }

        internal static IMessagePassingEndpoint New(string host, int port, ICommunicationModuleRegistry modules)
        {
            return new DefaultClientConnection(new ServerInfo(host, port, null, LogLevel.Info), modules);
        }

        public override T GetCommunicationModule<T>() => m_modules.GetCommunicationModule<T>();
    }
}