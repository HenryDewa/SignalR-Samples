using Ninject;
using SignalR;
using SignalR.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TwilioTextResponder.Web.Infrastructure;

namespace TwilioTextResponder.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var kernel = new StandardKernel();
            kernel.Bind<ITextReceiver>().To<TextReceiver>().InSingletonScope();
            kernel.Bind<IControllerActivator>().To<NinjectMvcControllerActivator>();
            RouteTable.Routes.MapHubs(new NinjectDependencyResolver(kernel));
            DependencyResolver.SetResolver(new NinjectMvcDependencyResolver(kernel));

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}