using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PirateThis.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(null,
            //    "",
            //    new
            //    {
            //        controller = "Song", action = "List",
            //        Artist = (string)null, page = 1
            //    }
            //);

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Home",
                    action = "Index"
                }
            );

            routes.MapRoute(null,
                "Page{page}",
                new
                {
                    controller = "Song",
                    action = "List",
                    Artist = (string)null
                },
                new { page = @"\d+" }
            );

            routes.MapRoute(null,
                "{artist}",
                new
                {
                    controller = "Song",
                    action = "List",
                    page = 1
                }
            );

            routes.MapRoute(null,
                "{artist}/Page{page}",
                new
                {
                    controller = "Song",
                    action = "List"
                },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}