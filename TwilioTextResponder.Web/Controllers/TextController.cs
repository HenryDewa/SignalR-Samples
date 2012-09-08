using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.Mvc;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;
using TwilioTextResponder.Web.Infrastructure;

namespace TwilioTextResponder.Web.Controllers
{
    public class TextController : Twilio.TwiML.Mvc.TwilioController
    {
        private ITextReceiver _textReceiver;

        public TextController(ITextReceiver textReceiver)
        {
            _textReceiver = textReceiver;
        }

        public TwiMLResult ReceiveText(SmsRequest request)
        {
            var response = new TwilioResponse()
                .Sms(string.Format("Hello from {0}, {1}. Hope you're enjoying the session!",
                        request.FromCity,
                        request.FromState));

            _textReceiver.ReceiveText(new TextData
            {
                Body = string.Format("{0}, {1}: {2}",
                        request.FromCity,
                        request.FromState,
                        request.Body),
                City = request.FromCity,
                ZipCode = request.FromZip
            });

            return new TwiMLResult(response);
        }

        public ActionResult Index(SmsRequest request)
        {
            return View();
        }
    }
}
