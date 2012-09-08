using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Ninject;

namespace SystemMonitor.WorkerRole
{
    public class SignalRTraceListener : TraceListener
    {
        public override void Write(string message)
        {
            Console.Write(message);

            try
            {
                WorkerRole.NinjectKernel.Get<ITraceMessageWriter>().Write(message);
            }
            catch { /* might not be wired up by the time we call this */ }
        }

        public override void WriteLine(string message)
        {
            Console.WriteLine(message);
            try
            {
                WorkerRole.NinjectKernel.Get<ITraceMessageWriter>().Write(message);
            }
            catch { /* might not be wired up by the time we call this */ }
        }
    }

    public class MessageWrittenEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public MessageWrittenEventArgs(string message)
        {
            Message = message;
        }
    }

    public interface ITraceMessageWriter
    {
        void Write(string message);
        event EventHandler<MessageWrittenEventArgs> MessageWritten;
    }

    public class TraceMessageWriter : ITraceMessageWriter
    {
        public void Write(string message)
        {
            if (MessageWritten != null)
                MessageWritten(this, new MessageWrittenEventArgs(message));
        }


        public event EventHandler<MessageWrittenEventArgs> MessageWritten;
    }
}
