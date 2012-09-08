using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRMvcApiSharedContainer.Infrastructure
{
    public interface IMessageBridge
    {
        void SendMessage(string body);
        event EventHandler<MessageBridgeEventArgs> MessageReceived;
    }

    public class MessageBridge : IMessageBridge
    {
        public void SendMessage(string body)
        {
            if (MessageReceived != null)
                MessageReceived(this, new MessageBridgeEventArgs(body));
        }

        public event EventHandler<MessageBridgeEventArgs> MessageReceived;
    }

    public class MessageBridgeEventArgs : EventArgs
    {
        public string Body { get; private set; }

        public MessageBridgeEventArgs(string body)
        {
            this.Body = body;
        }
    }
}