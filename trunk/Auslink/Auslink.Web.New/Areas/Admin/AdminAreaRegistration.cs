using System.Web.Mvc;

namespace Auslink.Web.New.Areas.Admin
{
    public class AdminRoutes : AreaRegistration 
    {
        public const string Default = "Admin Default";
        public const string Home = "Admin Home";
        public const string CMS = "Admin CMS";
        public const string Logout = "Admin Logout";
        public const string Login = "Admin Login";

        public class Membership
        {
            public const string Index = "Admin Membership Index";
            public const string Edit = "Admin Membership Edit";
            public const string Add = "Admin Membership Add";
            public const string Save = "Admin Membership Save";
            public const string ChangePassword = "Admin Membership ChangePassword";
        }

        public class QuarterlyUpdates
        {
            public const string Index = "Admin Quarterly Index";
            public const string Add = "Admin Quarterly Add";
        }
        
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(AdminRoutes.Membership.Index, "admin/membership", new { controller = "Membership", action = "Index" });
            context.MapRoute(AdminRoutes.Membership.Add, "admin/membership/add", new { controller = "Membership", action = "Add" });
            context.MapRoute(AdminRoutes.Membership.Edit, "admin/membership/edit/{memberId}", new { controller = "Membership", action = "Edit" });
            context.MapRoute(AdminRoutes.Membership.Save, "admin/membership/save/{memberId}", new { controller = "Membership", action = "Save" });
            context.MapRoute(AdminRoutes.Membership.ChangePassword, "admin/membership/change-password/{memberId}", new { controller = "Membership", action = "ChangePassword" });


            context.MapRoute(AdminRoutes.QuarterlyUpdates.Index, "admin/quarterly-updates", new { controller = "QuarterlyUpdates", action = "Index" });

            context.MapRoute(AdminRoutes.Login, "admin/login", new { controller = "Login", action = "Index" });
            context.MapRoute(AdminRoutes.Logout, "admin/logout", new { controller = "Logout", action = "Index" });
            context.MapRoute(AdminRoutes.Home, "admin", new { controller = "Home", action = "Index" });
            context.MapRoute(AdminRoutes.Default, "admin/{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}