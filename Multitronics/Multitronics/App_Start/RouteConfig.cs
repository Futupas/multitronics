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
                defaults: new { controller = "Product", action = "SomeProductData" }
            );
            routes.MapRoute(
                name: "some_product_comments",
                url: "Product/{id}/comments",
                defaults: new { controller = "Product", action = "SomeProductComments" }
            );
            routes.MapRoute(
                name: "some_product",
                url: "Product/{id}",
                defaults: new { controller = "Product", action = "SomeProduct" }
            );

            routes.MapRoute(
                name: "products_data",
                url: "Products/data",
                defaults: new { controller = "Product", action = "ProductsData" }
            );
            routes.MapRoute(
                name: "get_categories",
                url: "Products/categories",
                defaults: new { controller = "Product", action = "GetCategories" }
            );
            routes.MapRoute(
                name: "products",
                url: "Products",
                defaults: new { controller = "Product", action = "Products" }
            );

            routes.MapRoute(
                name: "product",
                url: "Product",
                defaults: new { controller = "Product", action = "Product" }
            );

            routes.MapRoute(
                name: "authors",
                url: "Authors",
                defaults: new { controller = "Author", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

        }
    }
}
