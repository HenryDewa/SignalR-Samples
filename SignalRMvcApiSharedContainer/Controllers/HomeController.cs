using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalRMvcApiSharedContainer.Infrastructure;

namespace SignalRMvcApiSharedContainer.Controllers
{
    public class HomeController : Controller
    {
        private IMessageBridge _bridge;

        public HomeController(IMessageBridge bridge)
        {
            _bridge = bridge;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
