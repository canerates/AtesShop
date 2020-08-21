using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AtesShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "About",
                url: "About",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Contact",
                url: "Contact",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Error2",
                url: "Error",
                defaults: new { controller = "Generic", action = "Error", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Error",
                url: "Error",
                defaults: new { controller = "Home", action = "Error", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Success",
                url: "Success",
                defaults: new { controller = "Generic", action = "Success", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Products",
                url: "Products/List/{categoryId}",
                defaults: new { controller = "Products", action = "Index", categoryId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Shop",
                url: "Shop/List/{categoryId}",
                defaults: new { controller = "Shop", action = "Index", categoryId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ShopSuccess",
                url: "Shop/Success/{orderId}",
                defaults: new { controller = "Shop", action = "Success", orderId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
