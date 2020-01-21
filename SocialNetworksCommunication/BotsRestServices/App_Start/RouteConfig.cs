using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication9
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Interface", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Admin",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "User",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Viber",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Viber", id=UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "Telegram",
                url: "{controller}/{action}/{id}/{key}",
                defaults: new { id = UrlParameter.Optional, key=UrlParameter.Optional }
            );
        }
    }
}
