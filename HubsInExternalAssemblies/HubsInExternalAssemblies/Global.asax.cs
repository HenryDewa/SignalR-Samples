using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using SignalR;
using System.Web.Routing;
using HubsInOtherAssemblies.SomeOtherAssembly;

namespace HubsInExternalAssemblies
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalHost.ConnectionManager.GetHubContext<ExternalHub>();
        }
    }
}