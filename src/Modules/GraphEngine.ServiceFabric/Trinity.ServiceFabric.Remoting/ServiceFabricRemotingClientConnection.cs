﻿using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Remoting.V2.FabricTransport.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trinity.Core.Lib;
using Trinity.Diagnostics;
using Trinity.Network;
using Trinity.Network.Messaging;
using Trinity.Storage;

namespace Trinity.ServiceFabric.Remoting
{
    using System.Linq;
    using System.Threading;
    using Microsoft.ServiceFabric.Services.Client;

    internal class ServiceFabricRemotingClientConnection : IMessagePassingEndpoint
    {
        private ICommunicationModuleRegistry m_modules;
        private ITrinityOverRemotingService m_svcProxy;
        private ServicePartitionKey m_userSuppliedPartitionKey = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceUrl"></param>
        /// <param name="mods"></param>
        public ServiceFabricRemotingClientConnection(string serviceUrl, ICommunicationModuleRegistry mods)
        {
            this.m_modules = mods;

            var proxyFactory = new ServiceProxyFactory(createServiceRemotingClientFactory: c => new FabricTransportServiceRemotingClientFactory());

            var rng = new Random();

            this.m_svcProxy = proxyFactory.CreateServiceProxy<ITrinityOverRemotingService>(
                new Uri(serviceUrl),
                new ServicePartitionKey(rng.Next()),
                listenerName: Constants.c_RemotingListenerName);
        }

        // Overloaded Service Fabric RemRemoting Client Connection so that the user can
        // supply their own partition key.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceUrl"></param>
        /// <param name="mods"></param>
        /// <param name="userPartitionKey"></param>
        public ServiceFabricRemotingClientConnection(string serviceUrl, 
                                                     ICommunicationModuleRegistry mods, 
                                                     ServicePartitionKey userPartitionKey = null)
        {
            m_userSuppliedPartitionKey = userPartitionKey ?? new ServicePartitionKey(new Random().Next());

            this.m_modules = mods;

            ServiceProxyFactory proxyFactory = new ServiceProxyFactory(serviceRemotingFactory => new FabricTransportServiceRemotingClientFactory());

            this.m_svcProxy = proxyFactory.CreateServiceProxy<ITrinityOverRemotingService>(new Uri(serviceUrl),
                                                                                           m_userSuppliedPartitionKey,
                                                                                           listenerName: Constants.c_RemotingListenerName);
        }

        public T GetCommunicationModule<T>() where T : CommunicationModule => m_modules.GetCommunicationModule<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="size"></param>
        public unsafe void SendMessage(byte* message, int size)
        {
            try
            {
                message += TrinityProtocol.SocketMsgHeader;
                size -= TrinityProtocol.SocketMsgHeader;

                byte[] buf = new byte[size];
                fixed (byte* p = buf) { Memory.memcpy(p, message, (uint)size); }
                m_svcProxy.SendMessageAsync(buf).Wait();
            }
            catch (Exception ex)
            {
                Log.WriteLine(LogLevel.Error, "{0}", ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="size"></param>
        /// <param name="response"></param>
        public unsafe void SendMessage(byte* message, int size, out TrinityResponse response)
        {
            try
            {
                message += TrinityProtocol.SocketMsgHeader;
                size -= TrinityProtocol.SocketMsgHeader;

                byte[] buf = new byte[size];
                fixed (byte* p = buf) { Memory.memcpy(p, message, (uint)size); }
                var result = m_svcProxy.SendMessageWithResponseAsync(buf).Result;
                byte* rsp = (byte*)Memory.malloc((uint)result.Length);
                fixed (byte* p = result) { Memory.memcpy(rsp, p, (uint)result.Length); }
                response = new TrinityResponse(rsp, result.Length);
            }
            catch (Exception ex)
            {
                Log.WriteLine(LogLevel.Error, "{0}", ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="sizes"></param>
        /// <param name="count"></param>
        public unsafe void SendMessage(byte** message, int* sizes, int count)
        {
            int len = 0;
            for (int i = 0; i<count; ++i) { len += sizes[i]; }
            byte[] buf = new byte[len];
            fixed (byte* p = buf)
            {
                byte* pp = p;
                for (int i = 0; i<count; ++i)
                {
                    Memory.memcpy(pp, message[i], (uint)sizes[i]);
                    pp += sizes[i];
                }
            }
            m_svcProxy.SendMessageAsync(buf).Wait();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="sizes"></param>
        /// <param name="count"></param>
        /// <param name="response"></param>
        public unsafe void SendMessage(byte** message, int* sizes, int count, out TrinityResponse response)
        {
            int len = 0;
            for (int i = 0; i<count; ++i) { len += sizes[i]; }
            byte[] buf = new byte[len];
            fixed (byte* p = buf)
            {
                byte* pp = p;
                for (int i = 0; i<count; ++i)
                {
                    Memory.memcpy(pp, message[i], (uint)sizes[i]);
                    pp += sizes[i];
                }
            }
            var result = m_svcProxy.SendMessageWithResponseAsync(buf).Result;
            byte* rsp = (byte*)Memory.malloc((uint)result.Length);
            fixed (byte* p = result) { Memory.memcpy(rsp, p, (uint)result.Length); }
            response = new TrinityResponse(rsp, result.Length);
        }
    }
}
