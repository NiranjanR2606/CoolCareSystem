using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CoolCareSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Userservices", "UserService/{action}/{id}", new { controller = "userservice", action = "Service", id = UrlParameter.Optional }, new[] { "CoolCareSystem.Controllers" });

            routes.MapRoute("Userproducts", "UserProduct/{action}/{id}", new { controller = "userproduct", action = "Product", id = UrlParameter.Optional }, new[] { "CoolCareSystem.Controllers" });

            routes.MapRoute("Account", "Account/{action}/{id}", new { controller = "Account", action = "Index", id = UrlParameter.Optional }, new[] { "CoolCareSystem.Controllers" });

            routes.MapRoute("Products", "{product}", new { controller = "Product", action = "Product" }, new[] { "CoolCareSystem.Controllers" });

            routes.MapRoute("Reports", "Report/{action}/{Month}", new { controller = "Report", action = "GenerateReport", Month = UrlParameter.Optional }, new[] { "CoolCareSystem.Controllers" });

            routes.MapRoute("Services", "{service}", new { controller = "Service", action = "Service" }, new[] { "CoolCareSystem.Controllers" });

            routes.MapRoute("default", "", new { controller = "Account", action = "Index" }, new[] { "CoolCareSystem.Controllers" });
        }
    }
}
