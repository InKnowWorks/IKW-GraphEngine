﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity.Network.Messaging;
using Trinity.Storage;

namespace Trinity.DynamicCluster.Storage
{
    public partial class Partition
    {
        public void RoundRobin(Action<IMessagePassingEndpoint> sendFunc)
        {
            var current = m_roundrobin_getter();
            if (current == null) throw new NoSuitableReplicaException();
            sendFunc(current);
        }

        public TResponse RoundRobin<TResponse>(Func<IMessagePassingEndpoint, TResponse> sendFunc)
        {
            var current = m_roundrobin_getter();
            if (current == null) throw new NoSuitableReplicaException();
            return sendFunc(current);
        }

        public Task<TResponse> RoundRobin<TResponse>(Func<IMessagePassingEndpoint, Task<TResponse>> sendFunc)
        {
            var current = m_roundrobin_getter();
            if (current == null) throw new NoSuitableReplicaException();
            return sendFunc(current);
        }
    }
}
