using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Strasbourg
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
 namespaces: new[] { "Strasbourg.UI.Controllers" },
                defaults: new { controller = "Strasbourg", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "Strasbourg.UI.Areas.Login.Controllers" }
            );

        }
    }
}
