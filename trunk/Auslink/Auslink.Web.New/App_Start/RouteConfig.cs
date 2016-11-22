using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Auslink.Web.New
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            string[] namespaces = new string[] { "Auslink.Web.New.Controllers" };

            routes.MapRoute("About", "About/Overview", new { controller = "About", action = "Overview"}, namespaces);
            routes.MapRoute("About-Key-Features", "About/Key-Features", new { controller = "About", action = "KeyFeatures"}, namespaces);

            routes.MapRoute("Property-Portfolio", "Property-Portfolio", new { controller = "PropertyPortfolio", action = "AllProperties"}, namespaces);
            routes.MapRoute("Property-Portfolio-Single", "Property-Portfolio/{propertyName}", new { controller = "PropertyPortfolio", action = "Property"}, namespaces);

            routes.MapRoute("Financials", "Financials/Returns", new { controller = "Financials", action = "Returns"}, namespaces);
            routes.MapRoute("Financials-Fund-Summary", "Financials/Fund-Summary", new { controller = "Financials", action = "FundSummary"}, namespaces);

            routes.MapRoute("Management", "Management/Trust-Manager", new { controller = "Management", action = "TrustManager"}, namespaces);
            routes.MapRoute("Management-Property-Manager", "Management/Property-Manager", new { controller = "Management", action = "PropertyManager"}, namespaces);

            routes.MapRoute("Investors", "Investors/Prospective", new { controller = "Investors", action = "Prospective"}, namespaces);
            routes.MapRoute("Investors-Current-Unitholders", "Investors/Current-Unit-Holders", new { controller = "Investors", action = "CurrentUnitholders"}, namespaces);
            routes.MapRoute("Investors-Current-Unitholders-Members", "Members/Investors/Current-Unit-Holders", new { controller = "Members", action = "CurrentUnitholders"}, namespaces);


            routes.MapRoute("Contact-Us", "Contact-US", new { controller = "ContactUs", action = "Index"}, namespaces);

            routes.MapRoute("Disclaimer", "Disclaimer", new { controller = "Disclaimer", action = "Index"}, namespaces);
            routes.MapRoute("Privacy", "Privacy", new { controller = "Privacy", action = "Index"}, namespaces);

            routes.MapRoute("Forgotten-Login-Details", "Forgotten-Login-Details", new { controller = "ForgottenLoginDetails", action = "Index"}, namespaces);

            routes.MapRoute("ComingSoon", "ComingSoon", new { controller = "ComingSoon", action = "Index"}, namespaces);


            routes.MapRoute("Login", "Login", new { controller = "Login", action = "Index" }, namespaces);
            routes.MapRoute("Logout", "Logout", new { controller = "Login", action = "Logout" }, namespaces);

            routes.MapRoute("Error-404", "Error/404", new { controller = "Error", action = "NotFound"}, namespaces);
            routes.MapRoute("Error-500", "Error/500", new { controller = "Error", action = "Unknown"}, namespaces);


            routes.MapRoute("Carnarvon", "Property-Portfolio/Carnarvon", new { controller = "Property-Portfolio", action = "Carnarvon"}, namespaces);
            routes.MapRoute("Boronia", "Property-Portfolio/Boronia", new { controller = "Property-Portfolio", action = "Boronia"}, namespaces);
            routes.MapRoute("Port-Pirie", "Property-Portfolio/Port-Pirie", new { controller = "Property-Portfolio", action = "PortPirie"}, namespaces);
            routes.MapRoute("Footscray", "Property-Portfolio/Footscray", new { controller = "Property-Portfolio", action = "Footscray"}, namespaces);
            routes.MapRoute("South-Brisbane", "Property-Portfolio/South-Brisbane", new { controller = "Property-Portfolio", action = "SouthBrisbane"}, namespaces);
            routes.MapRoute("Townsville", "Property-Portfolio/Townsville", new { controller = "Property-Portfolio", action = "Townsville"}, namespaces);
            routes.MapRoute("Albury", "Property-Portfolio/Albury", new { controller = "Property-Portfolio", action = "Albury"}, namespaces);
            routes.MapRoute("Bowen", "Property-Portfolio/Bowen", new { controller = "Property-Portfolio", action = "Bowen"}, namespaces);
            routes.MapRoute("Port-Augusta", "Property-Portfolio/Port-Augusta", new { controller = "Property-Portfolio", action = "PortAugusta"}, namespaces);
            routes.MapRoute("Goondiwindi", "Property-Portfolio/Goondiwindi", new { controller = "Property-Portfolio", action = "Goondiwindi"}, namespaces);
            routes.MapRoute("Glenorchy", "Property-Portfolio/Glenorchy", new { controller = "Property-Portfolio", action = "Glenorchy" }, namespaces);
            routes.MapRoute("Warragul", "Property-Portfolio/Warragul", new { controller = "Property-Portfolio", action = "Warragul" }, namespaces);
            routes.MapRoute("Brunswick", "Property-Portfolio/Brunswick", new { controller = "Property-Portfolio", action = "Brunswick" }, namespaces);
            routes.MapRoute("Mildura", "Property-Portfolio/Mildura", new { controller = "Property-Portfolio", action = "Mildura" }, namespaces);
            

            routes.MapRoute("Home", "", new { controller = "Home", action = "Index"}, namespaces);

            routes.MapRoute(name: "Default", url: "{controller}/{action}/{id}", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional}, namespaces: namespaces);
        }
    }
}
