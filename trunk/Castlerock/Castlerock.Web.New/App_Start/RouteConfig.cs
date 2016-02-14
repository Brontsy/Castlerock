using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Castlerock.Web.New
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            string[] namespaces = new string[] { "Castlerock.Web.New.Controllers" };

            routes.MapRoute("Login", "Login", new { controller = "Login", action = "Index" }, namespaces);
            routes.MapRoute("Logout", "Logout", new { controller = "Login", action = "Logout" }, namespaces);

            routes.MapRoute("Error-404", "Error/404", new { controller = "Error", action = "NotFound" }, namespaces);
            routes.MapRoute("Error-500", "Error/500", new { controller = "Error", action = "Unknown" }, namespaces);

            routes.MapRoute("Privacy-Policy", "PrivacyPolicy", new { controller = "PrivacyPolicy", action = "Index" });

            routes.MapRoute("Disclaimer", "Disclaimer", new { controller = "Disclaimer", action = "Index" });

            routes.MapRoute("Contact-Us", "ContactUs", new { controller = "ContactUs", action = "Index" });

            routes.MapRoute("About-Us", "AboutUs", new { controller = "AboutUs", action = "Index" });

            routes.MapRoute("Experience", "Experience", new { controller = "Experience", action = "Index" });


            routes.MapRoute("Investors", "Investors", new { controller = "Investors", action = "Index" });



            routes.MapRoute("Properties", "Properties", new { controller = "Properties", action = "Index" });

            routes.MapRoute("PropertiesFromState", "Properties/State/{state}", new { controller = "Properties", action = "State" });

            routes.MapRoute("Property", "Properties/Show/{propertyName}/{propertyId}", new { controller = "Properties", action = "Show" });

            routes.MapRoute("Home", "", new { controller = "Home", action = "Index" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
