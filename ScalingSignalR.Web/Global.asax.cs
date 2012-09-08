using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using SignalR;
using SignalR.WindowsAzureServiceBus;
using SignalR.Redis;

namespace ScalingSignalR.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // TODO: comment out one of the sections below. you won't need both. :)

            // use Redis
            // get the Redis for Windows here: https://github.com/MSOpenTech/redis
            //GlobalHost.DependencyResolver.UseRedis("localhost", 6379, string.Empty, "chat");
            
            // if you're using a web role or a cloud service you can use Service Bus
            /*
            GlobalHost.DependencyResolver.UseWindowsAzureServiceBus("yourNamespace",
                "owner", // usually
                "your key here",
                "myTopicPrefix",
                1); // increase this when you need to dramatically increase your throughput
            */
        }
    }
}