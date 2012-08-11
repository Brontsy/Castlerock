using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Castlerock.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Privacy-Policy", "PrivacyPolicy", new { controller = "PrivacyPolicy", action = "Index" });

            routes.MapRoute("Disclaimer", "Disclaimer", new { controller = "Disclaimer", action = "Index" });

            routes.MapRoute("Contact-Us", "ContactUs", new { controller = "ContactUs", action = "Index" });

            routes.MapRoute("About-Us", "AboutUs", new { controller = "AboutUs", action = "Index" });

            routes.MapRoute("Experience", "Experience", new { controller = "Experience", action = "Index" });


            routes.MapRoute("Investors", "Investors", new { controller = "Investors", action = "Index" });


            routes.MapRoute("Properties", "Properties", new { controller = "Properties", action = "Index" });

            routes.MapRoute("PropertiesFromState", "Properties/State/{state}", new { controller = "Properties", action = "State" });

            routes.MapRoute("Property", "Properties/Show/{propertyName}/{propertyId}", new { controller = "Properties", action = "Show" });

            routes.MapRoute("Login", "login", new { controller = "Login", action = "Index" });
            routes.MapRoute("Logout", "Logout", new { controller = "Login", action = "Logout" });
            routes.MapRoute("Member-Downloads", "members/downloads", new { controller = "Member", action = "Downloads" });


            routes.MapRoute("Error-404", "Error/404", new { controller = "Error", action = "Show404" });
            routes.MapRoute("Error-500", "Error/500", new { controller = "Error", action = "Show500" });

            routes.MapRoute("Home", "", new { controller = "Home", action = "Index" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}