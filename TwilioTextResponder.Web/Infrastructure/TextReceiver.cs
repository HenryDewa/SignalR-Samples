using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwilioTextResponder.Web.Infrastructure
{
    public class TextData
    {
        public string Body { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }

    public class GenericEventArgs<T> : EventArgs
    {
        public T Data { get; private set; }

        public GenericEventArgs(T data)
        {
            Data = data;
        }
    }

    public interface ITextReceiver
    {
        void ReceiveText(TextData text);
        event EventHandler<GenericEventArgs<TextData>> TextReceived;
    }

    public class TextReceiver : ITextReceiver
    {
        public void ReceiveText(TextData text)
        {
            if (TextReceived != null)
                TextReceived(this, new GenericEventArgs<TextData>(text));
        }

        public event EventHandler<GenericEventArgs<TextData>> TextReceived;
    }
}