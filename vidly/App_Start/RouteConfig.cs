using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Enable attribute routing [NEW WAY OF ROUTING starting from MVC 5]
            routes.MapMvcAttributeRoutes();

            // Always define custom routes above default route
            // Custom routes [OLD WAY OF ROUTING]
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new { controller = "movies", action = "ByRelaseDate" },
            //    new { year = @"\d{4}", month = @"\d{2}" }   // Uses regex to limit year to 4 digits and month to 2 digits
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
