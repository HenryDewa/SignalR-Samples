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

namespace SiteMonitor.WorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        Thread thread;
        Server server;

        public override void Run()
        {
            Trace.WriteLine("SiteMonitor.WorkerRole entry point called", "Information");

            while (true)
            {
                Thread.Sleep(10000);
                server.Run();
            }
        }

        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            // create the server
            server = new Server(
                new TableStorageSiteUrlRepository(), 
                new WorkerRoleHubConfiguration()
                );

            // run the server
            thread = new Thread(new ThreadStart(() => server.Run()));
            thread.Start();

            return base.OnStart();
        }

        public override void OnStop()
        {
            thread.Abort();
            server.Stop();
        }
    }
}
