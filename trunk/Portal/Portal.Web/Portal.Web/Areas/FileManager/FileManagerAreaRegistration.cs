using System.Web.Mvc;

namespace Portal.Web.Areas.FileManager
{
    public class FileManagerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "FileManager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("FileManager-View", "File-Manager/View", new { controller = "FileManager", action = "View" });
            context.MapRoute("FileManager-Upload", "File-Manager/Upload", new { controller = "FileManager", action = "Upload" });
            context.MapRoute("FileManager-New-Folder", "File-Manager/Folder/New", new { controller = "FileManager", action = "NewFolder" });
            context.MapRoute("FileManager-Folder-Delete", "File-Manager/Folder/Delete", new { controller = "FileManager", action = "DeleteFolder" });
            context.MapRoute("FileManager-File-Delete", "File-Manager/File/Delete", new { controller = "FileManager", action = "DeleteFile" });
            context.MapRoute("FileManager", "File-Manager", new { controller = "FileManager", action = "Index" });
        }
    }
}
