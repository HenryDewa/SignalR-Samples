using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HubsInOtherAssemblies.SomeOtherAssembly
{
    [HubName("externalHub")]
    public class ExternalHub : Hub
    {
        public void SomeExternalMethod()
        {
            Caller.onSomeExternalMethod("external test");
        }
    }
}
