using Ninject;
using SignalR.Hosting.Common;
using SignalR.Hosting.Self;
using SignalR.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemMonitor.WorkerRole
{
    internal class HubServer
    {
        private Server _server;
        private StandardKernel _kernel;

        public HubServer(StandardKernel kernel)
        {
            _kernel = kernel;
        }

        public void Start()
        {
            _server = new Server("http://localhost:17/", new NinjectDependencyResolver(_kernel));
            _server.MapHubs();
            _server.Start();
        }

        public void Stop()
        {
            if (_server != null)
                _server.Stop();
        }
    }
}
