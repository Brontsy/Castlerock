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
            public const string Edit = "Admin Quarterly Edit";
            public const string Save = "Admin Quarterly Save";
            public const string Delete = "Admin Quarterly Delete";
        }

        public class Cms
        {
            public class Page
            {
                public const string Index = "Admin Cms Index";
                public const string AddPage = "Admin Cms AddPage";
                public const string EditPage = "Admin Cms EditPage";
                public const string SavePage = "Admin Cms SavePage";
                public const string View = "Admin Cms ViewPage";
            }

            public const string EditPageContent = "Admin Cms EditPageContent";
            public const string SavePageContent = "Admin Quarterly SavePageContent";
            public const string PublishPageContent = "Admin Quarterly PublishPageContent";
        }

        public class FileUploader
        {
            public const string Index = "FileUploader Index";
            public const string Upload = "FileUploader Upload";
            public const string DeleteFile = "FileUploader DeleteFile";
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
            context.MapRoute(AdminRoutes.QuarterlyUpdates.Add, "admin/quarterly-updates/add", new { controller = "QuarterlyUpdates", action = "Add" });
            context.MapRoute(AdminRoutes.QuarterlyUpdates.Edit, "admin/quarterly-updates/edit/{quarterlyUpdateId}", new { controller = "QuarterlyUpdates", action = "Edit" });
            context.MapRoute(AdminRoutes.QuarterlyUpdates.Save, "admin/quarterly-updates/save/{quarterlyUpdateId}", new { controller = "QuarterlyUpdates", action = "Save" });
            context.MapRoute(AdminRoutes.QuarterlyUpdates.Delete, "admin/quarterly-updates/delete/{quarterlyUpdateId}", new { controller = "QuarterlyUpdates", action = "Delete" });

            context.MapRoute(AdminRoutes.Cms.Page.Index, "admin/cms", new { controller = "Cms", action = "Index" });
            context.MapRoute(AdminRoutes.Cms.Page.View, "admin/cms/view-page/{name}/{pageId}", new { controller = "Cms", action = "ViewPage" });
            context.MapRoute(AdminRoutes.Cms.Page.AddPage, "admin/cms/add-page", new { controller = "Cms", action = "AddPage" });
            context.MapRoute(AdminRoutes.Cms.Page.EditPage, "admin/cms/edi-page/{name}/{pageId}", new { controller = "Cms", action = "EditPage" });
            context.MapRoute(AdminRoutes.Cms.Page.SavePage, "admin/cms/save-page/{pageId}", new { controller = "Cms", action = "SavePage" });

            context.MapRoute(AdminRoutes.Cms.EditPageContent, "admin/cms/edit-page/{name}/{pageId}/content/{contentId}", new { controller = "Cms", action = "EditPageContent" });
            context.MapRoute(AdminRoutes.Cms.SavePageContent, "admin/cms/save-page/{name}/{pageId}/content/{contentId}", new { controller = "Cms", action = "SavePageContent" });
            context.MapRoute(AdminRoutes.Cms.PublishPageContent, "admin/cms/publish/{name}/{pageId}/content/{contentId}", new { controller = "Cms", action = "PublishPageContent" });


            context.MapRoute(AdminRoutes.FileUploader.Index, "admin/file-uploader", new { controller = "FileUploader", action = "Add" });
            context.MapRoute(AdminRoutes.FileUploader.Upload, "admin/file-uploader/upload", new { controller = "FileUploader", action = "Upload" });
            context.MapRoute(AdminRoutes.FileUploader.DeleteFile, "admin/file-uploader/delete", new { controller = "FileUploader", action = "DeleteFile" });

            context.MapRoute(AdminRoutes.Login, "admin/login", new { controller = "Login", action = "Index" });
            context.MapRoute(AdminRoutes.Logout, "admin/logout", new { controller = "Logout", action = "Index" });
            context.MapRoute(AdminRoutes.Home, "admin", new { controller = "Home", action = "Index" });
            context.MapRoute(AdminRoutes.Default, "admin/{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}