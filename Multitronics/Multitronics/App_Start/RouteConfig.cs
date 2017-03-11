using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Multitronics
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "some_product_gata",
                url: "Product/{id}/data",
                defaults: new { controller = "Home", action = "SomeProductData" }
            );
            routes.MapRoute(
                name: "some_product",
                url: "Product/{id}",
                defaults: new { controller = "Home", action = "SomeProduct" }
            );

            routes.MapRoute(
                name: "product",
                url: "Product",
                defaults: new { controller = "Home", action = "Product" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
