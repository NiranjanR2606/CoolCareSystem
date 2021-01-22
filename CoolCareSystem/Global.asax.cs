using CoolCareSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CoolCareSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DevExtremeBundleConfig.RegisterBundles(BundleTable.Bundles);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
        }

        protected void Application_AuthenticateRequest()
        {
            if (User == null) { return; }

            string username = Context.User.Identity.Name;

            string[] roles = null;

            using (CoolCareSystemEntities db = new CoolCareSystemEntities())
            {
                User dto = db.Users.FirstOrDefault(x => x.UserName == username);

                roles = db.UserRoles.Where(x => x.UserId == dto.Id).Select(x => x.Role.Name).ToArray();
            }

            IIdentity userIdentity = new GenericIdentity(username);
            IPrincipal newUserObj = new GenericPrincipal(userIdentity, roles);

            Context.User = newUserObj;
        }
    }
}
