using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using SignalR.Hosting.Self;

namespace TimeServer.WorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        public TimeHubServer Server { get; set; }

        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            Server = new TimeHubServer();
            Server.Start();

            return base.OnStart();
        }

        public override void Run()
        {
            Trace.WriteLine("TimeServer.WorkerRole entry point called", "Information");

            while (true)
            {
                Thread.Sleep(10000);
                Trace.WriteLine("Working", "Information");
            }
        }

        public override void OnStop()
        {
            if (Server != null)
                Server.Stop();

            base.OnStop();
        }
    }
}
