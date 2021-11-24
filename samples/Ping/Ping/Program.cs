// Graph Engine
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//
using Ping.MyServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Trinity;
using Trinity.Storage;

namespace Ping
{
    class MyServerImpl : MyServerBase
    {
        public override void SynPingHandler(MyMessageReader request)
        {
            Console.WriteLine("Received SynPing, sn={0}", request.sn);
        }

        public override void AsynPingHandler(MyMessageReader request)
        {
            Console.WriteLine("Received AsynPing, sn={0}", request.sn);
        }

        public override void SynEchoPingHandler(MyMessageReader request,
        MyMessageWriter response)
        {
            Console.WriteLine("Received SynEchoPing, sn={0}", request.sn);
            response.sn = request.sn;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var server = new MyServerImpl();
            server.Start();

            var synReq = new MyMessageWriter(sn: 1);

            Global.CloudStorage.SynPingToMyServer(0, synReq);

            var asynReq = new MyMessageWriter(sn: 2);
            Global.CloudStorage.AsynPingToMyServer(0, asynReq);

            var synReqRsp = new MyMessageWriter(sn: 3);
            Console.WriteLine("Response of EchoPing: {0}", Global.CloudStorage[0].SynEchoPing(synReqRsp).sn);

            Console.WriteLine("Done.");
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
            Global.Exit(0);
        }
    }
}

