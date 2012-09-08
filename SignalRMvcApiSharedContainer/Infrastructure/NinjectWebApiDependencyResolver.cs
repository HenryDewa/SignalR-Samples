using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;

namespace SignalRMvcApiSharedContainer.Infrastructure
{
    /// <summary>
    /// Sets up the resolution for MVC controllers
    /// </summary>
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
            return _kernel.GetAll(serviceType) ?? new List<object>();
        }
    }

    /// <summary>
    /// Activates MVC controllers.
    /// </summary>
    public class NinjectMvcControllerActivator : IControllerActivator
    {
        public IController Create(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            var ret = DependencyResolver.Current.GetService(controllerType) as IController;
            return ret;
        }
    }

    /// <summary>
    /// Sets up resolution for Web API controllers.
    /// </summary>
    public class NinjectWebApiControllerDependencyResolver 
        : System.Web.Http.Dependencies.IDependencyResolver
    {
        private StandardKernel _kernel;

        public NinjectWebApiControllerDependencyResolver(StandardKernel kernel)
        {
            _kernel = kernel;
        }

        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _kernel.Get(serviceType) ?? null;
            }
            catch { return null; }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _kernel.GetAll(serviceType) ?? new List<object>();
            }
            catch
            {
                return null;
            }
        }

        public void Dispose()
        {
        }
    }

    /// <summary>
    /// Activates Web API controllers.
    /// </summary>
    public class NinjectWebApiControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(System.Net.Http.HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            return System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver
                .GetService(controllerType) as IHttpController;
        }
    }
}