using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using Autofac.Integration.Web;
using ViewFactoryExample.App_Start;
using ViewFactoryExample.Injection;

namespace ViewFactoryExample
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        private static IContainerProvider _containerProvider;
        public IContainerProvider ContainerProvider => _containerProvider;

        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = DependencyConfig.Register();
            _containerProvider = new ContainerProvider(container);

            // Instruct the dependency resolver to use the Autofac one on the config.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}