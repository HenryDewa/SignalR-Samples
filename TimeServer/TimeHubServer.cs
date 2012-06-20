using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignalR.Hosting.Self;

namespace TimeServer
{
    public class TimeHubServer
    {
        public Server Server { get; set; }

        public void Start()
        {
            var url = "http://localhost:17/";
            Server = new Server(url);

            Server.Start();

            // map the hubs (really only needed for hubs in external assemblies)
            Server.ConnectionManager.GetHubContext<TimeHub>();

            // map all the hubs so they're proxied
            Server.MapHubs();
        }

        public void Stop()
        {
            if (Server != null)
                Server.Stop();
        }
    }
}
