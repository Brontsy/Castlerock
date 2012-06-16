using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Portal.Membership.Models;
using Portal.Web.Areas.Membership.Models;

namespace Portal.Web
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

            routes.MapRoute("Login", "Login", new { controller = "Login", action = "Index" });
            routes.MapRoute("Login-Go", "Login/Go", new { controller = "Login", action = "Go" });
            routes.MapRoute("Logout", "Logout", new { controller = "Login", action = "Logout" });
            routes.MapRoute("No-Permission", "Permission/Invalid", new { controller = "Permission", action = "Invalid" });
            routes.MapRoute("Upload-Images", "Upload/Images", new { controller = "Upload", action = "Images" });

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Login", action = "Login", id = UrlParameter.Optional });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(Object source, EventArgs e)
        {
            
        }
    }
}