using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using SignalR;

namespace BasicExamples.Connections
{
    public class UserCounterConnection : PersistentConnection
    {
        public static int UserCount;

        protected override System.Threading.Tasks.Task OnConnectedAsync(SignalR.Hosting.IRequest request, string connectionId)
        {
            UserCount += 1;
            Debug.WriteLine("OnConnectedAsync " + UserCount);
            this.Connection.Broadcast(UserCount);
            return base.OnConnectedAsync(request, connectionId);
        }

        protected override System.Threading.Tasks.Task OnDisconnectAsync(string connectionId)
        {
            UserCount -= 1;
            Debug.WriteLine("OnDisconnectAsync " + UserCount);
            this.Connection.Broadcast(UserCount);
            return base.OnDisconnectAsync(connectionId);
        }
    }
}