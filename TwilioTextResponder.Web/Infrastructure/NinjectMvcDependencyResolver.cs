using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TwilioTextResponder.Web.Infrastructure
{
    public class NinjectMvcDependencyResolver : IDependencyResolver
    {
        private StandardKernel _kernel;

        public NinjectMvcDependencyResolver(StandardKernel kernel)
        {
            _kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType) ?? null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _kernel.GetAll(serviceType);
            }
            catch { return new List<object>(); }
        }
    }

    public class NinjectMvcControllerActivator : IControllerActivator
    {
        public IController Create(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }

}