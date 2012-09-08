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
        public static int _userCount;

        protected override System.Threading.Tasks.Task 
            OnConnectedAsync(IRequest request, string connectionId)
        {
            _userCount += 1;
            Debug.WriteLine("OnConnectedAsync " + _userCount);
            this.Connection.Broadcast(_userCount);
            return base.OnConnectedAsync(request, connectionId);
        }

        protected override System.Threading.Tasks.Task 
            OnDisconnectAsync(string connectionId)
        {
            _userCount -= 1;
            Debug.WriteLine("OnDisconnectAsync " + _userCount);
            this.Connection.Broadcast(_userCount);
            return base.OnDisconnectAsync(connectionId);
        }
    }
}