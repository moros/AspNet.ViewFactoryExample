using System.Web;
using System.Web.Routing;
using ViewFactoryExample.App_Start;

namespace ViewFactoryExample
{
    public class Global : HttpApplication
    {

        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}