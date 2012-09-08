using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalRMvcApiSharedContainer.Infrastructure;

namespace SignalRMvcApiSharedContainer.Hubs
{
    public class MessageHub : Hub
    {
        private IMessageBridge _messageBridge;

        public MessageHub(IMessageBridge messageBridge)
        {
            _messageBridge = messageBridge;
        }

        public void Start()
        {
            _messageBridge.MessageReceived += (s, e) => Caller.onMessageReceived(e.Body);
        }
    }
}