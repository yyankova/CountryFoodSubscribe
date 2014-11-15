using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CountryFood.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "By Category",
                url: "categories/{category}",
                defaults: new { controller = "Categories", action = "GetProductsFromCategory"},
                namespaces: new string[] { "CountryFood.Web.Controllers" }
                );

            routes.MapRoute(
                name: "Producers",
                url: "producers/{id}",
                defaults: new { controller = "Producers", action = "Display", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "CountryFood.Web.Controllers" }
            );
        }
    }
}
