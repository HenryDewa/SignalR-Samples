using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemMonitor.WorkerRole
{
    [HubName("trace")]
    public class TraceHub : Hub
    {
        private ITraceMessageWriter _writer;

        public TraceHub(ITraceMessageWriter writer)
        {
            _writer = writer;
        }

        public void StartTrace()
        {
            _writer.MessageWritten += (s, e) =>
                Caller.receiveTraceMessage(
                    string.Format("{0} {1} {2}",
                        DateTime.Now.ToShortDateString(),
                        DateTime.Now.ToLongTimeString(),
                        e.Message));
        }
    }
}
