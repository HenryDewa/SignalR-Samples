using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HubsInExternalAssemblies.Hubs
{
    [HubName("internalHub")]
    public class InternalHub : Hub
    {
        public void SomeInternalMethod()
        {
            Caller.onSomeInternalMethod("internal test");
        }
    }
}