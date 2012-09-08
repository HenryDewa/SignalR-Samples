using Ninject;
using SignalR;
using SignalR.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;
using SignalRMvcApiSharedContainer.Infrastructure;

namespace SignalRMvcApiSharedContainer
{
    public class InfrastructureConfig
    {
        public static void RegisterServices()
        {
            // set up the container
            var kernel = new StandardKernel();

            kernel.Bind<IMessageBridge>().To<MessageBridge>().InSingletonScope();
            kernel.Bind<IControllerActivator>().To<NinjectMvcControllerActivator>();
            kernel.Bind<IHttpControllerActivator>().To<NinjectWebApiControllerActivator>();

            // tell signalr which resolver to use
            RouteTable.Routes.MapHubs(new NinjectDependencyResolver(kernel));

            // tell MVC which resolver to use
            DependencyResolver.SetResolver(new NinjectMvcDependencyResolver(kernel));

            // tell Web API which resolver to use
            GlobalConfiguration.Configuration.DependencyResolver =
                new NinjectWebApiControllerDependencyResolver(kernel);
        }
    }
}