using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SignalRMvcApiSharedContainer.Infrastructure;

namespace SignalRMvcApiSharedContainer.Controllers
{
    public class MessageController : ApiController
    {
        private IMessageBridge _bridge;

        public MessageController(IMessageBridge bridge)
        {
            _bridge = bridge;
        }

        public bool Post(string body)
        {
            _bridge.SendMessage(body);

            return true;
        }
    }
}
