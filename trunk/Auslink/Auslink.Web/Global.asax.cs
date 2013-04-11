using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Auslink.Web
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

            routes.MapRoute("About", "About/Overview", new { controller = "About", action = "Overview" });
            routes.MapRoute("About-Key-Features", "About/Key-Features", new { controller = "About", action = "KeyFeatures" });

            routes.MapRoute("Property-Portfolio", "Property-Portfolio", new { controller = "PropertyPortfolio", action = "AllProperties" });
            routes.MapRoute("Property-Portfolio-Single", "Property-Portfolio/{propertyName}", new { controller = "PropertyPortfolio", action = "Property" });

            routes.MapRoute("Financials", "Financials/Returns", new { controller = "Financials", action = "Returns" });
            routes.MapRoute("Financials-Fund-Summary", "Financials/Fund-Summary", new { controller = "Financials", action = "FundSummary" });

            routes.MapRoute("Management", "Management/Trust-Manager", new { controller = "Management", action = "TrustManager" });
            routes.MapRoute("Management-Property-Manager", "Management/Property-Manager", new { controller = "Management", action = "PropertyManager" });

            routes.MapRoute("Investors", "Investors/Prospective", new { controller = "Investors", action = "Prospective" });
            routes.MapRoute("Investors-Current-Unitholders", "Investors/Current-Unit-Holders", new { controller = "Investors", action = "CurrentUnitholders" });
            routes.MapRoute("Investors-Current-Unitholders-Members", "Members/Investors/Current-Unit-Holders", new { controller = "Members", action = "CurrentUnitholders" });

            
            routes.MapRoute("Contact-Us", "Contact-US", new { controller = "ContactUs", action = "Index" });

            routes.MapRoute("Disclaimer", "Disclaimer", new { controller = "Disclaimer", action = "Index" });
            routes.MapRoute("Privacy", "Privacy", new { controller = "Privacy", action = "Index" });

            routes.MapRoute("Forgotten-Login-Details", "Forgotten-Login-Details", new { controller = "ForgottenLoginDetails", action = "Index" });

            routes.MapRoute("ComingSoon", "ComingSoon", new { controller = "ComingSoon", action = "Index" });


            routes.MapRoute("Login", "Login", new { controller = "Login", action = "Index" });
            routes.MapRoute("Logout", "Logout", new { controller = "Login", action = "Logout" });

            routes.MapRoute("Error-404", "Error/404", new { controller = "Error", action = "NotFound" });
            routes.MapRoute("Error-500", "Error/500", new { controller = "Error", action = "Unknown" });

            
            routes.MapRoute("Carnarvon", "Property-Portfolio/Carnarvon", new { controller = "Property-Portfolio", action = "Carnarvon" });
            routes.MapRoute("Boronia", "Property-Portfolio/Boronia", new { controller = "Property-Portfolio", action = "Boronia" });
            routes.MapRoute("Port-Pirie", "Property-Portfolio/Port-Pirie", new { controller = "Property-Portfolio", action = "PortPirie" });
            routes.MapRoute("Footscray", "Property-Portfolio/Footscray", new { controller = "Property-Portfolio", action = "Footscray" });
            routes.MapRoute("South-Brisbane", "Property-Portfolio/South-Brisbane", new { controller = "Property-Portfolio", action = "SouthBrisbane" });
            routes.MapRoute("Townsville", "Property-Portfolio/Townsville", new { controller = "Property-Portfolio", action = "Townsville" });


            routes.MapRoute("Home", "", new { controller = "Home", action = "Index" });

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}