using Api.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Api
{
    public class BootstrapApplication
    {
        public void ConfigureRoute(HttpConfiguration config)
        {
            AreaRegistration.RegisterAllAreas();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //   new PollMessages().start();
        }
    }
}
