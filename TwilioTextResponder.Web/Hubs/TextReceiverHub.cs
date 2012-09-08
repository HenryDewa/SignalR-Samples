using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwilioTextResponder.Web.Infrastructure;

namespace TwilioTextResponder.Web.Hubs
{
    [HubName("textReceiver")]
    public class TextReceiverHub : Hub
    {
        private ITextReceiver _textReceiver;

        public TextReceiverHub(ITextReceiver textReceiver)
        {
            _textReceiver = textReceiver;
        }

        public void Start()
        {
            _textReceiver.TextReceived += (s, e) => Caller.onTextReceived(e.Data);
        }

        public void FakeIt()
        {
            List<Tuple<string, string>> fakes = new List<Tuple<string, string>>();
            fakes.Add(new Tuple<string, string>("Houston", "TX"));
            fakes.Add(new Tuple<string, string>("Richmond", "VA"));
            fakes.Add(new Tuple<string, string>("Phoenix", "AZ"));
            fakes.Add(new Tuple<string, string>("Seattle", "WA"));
            fakes.Add(new Tuple<string, string>("Charlotte", "NC"));

            var rnd = new Random();
            var indx = rnd.Next(0, fakes.Count - 1);

            _textReceiver.ReceiveText(new TextData
            {
                Body = string.Format("{0} {1}: This is a test to see if it works", fakes[indx].Item1, fakes[indx].Item2),
                City = fakes[indx].Item1,
                ZipCode = fakes[indx].Item2
            });
        }
    }
}