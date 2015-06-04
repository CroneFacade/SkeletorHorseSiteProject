using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SkeletorHorseProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Horses",
              url: "Horses",
              defaults: new { controller = "FilteredHorsePage", action = "FilterPage", navigationId = 1 }

              );
            routes.MapRoute(
               name: "Admin",
               url: "Admin",
               defaults: new { controller = "AdminLogin", action = "Login" }

               );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
