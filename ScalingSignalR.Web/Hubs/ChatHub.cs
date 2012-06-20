using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;

namespace ScalingSignalR.Web.Hubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(dynamic message)
        {
            Clients.receiveMessage(message);
        }
    }
}