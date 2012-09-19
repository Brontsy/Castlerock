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
            context.MapRoute("FileManager-New-Root-Folder", "file-manager/New-Folder", new { controller = "FileManager", action = "NewFolder" });

            context.MapRoute("FileManager-Upload", "file-Manager/Upload", new { controller = "FileManager", action = "Upload" });

            context.MapRoute("BlobStorage", "BlobStorage", new { controller = "BlobStorage", action = "Index" });
            context.MapRoute("BlobStorage-Delete", "BlobStorage/Delete", new { controller = "BlobStorage", action = "Delete" });


            context.MapRoute("FileManager-View", "file-manager/{path}", new { controller = "FileManager", action = "View", path = UrlParameter.Optional });

            context.MapRoute("FileManager-Folder-Delete", "file-manager/Folder/Delete/{path}", new { controller = "FileManager", action = "DeleteFolder" });
            context.MapRoute("FileManager-File-Delete", "file-manager/file/delete", new { controller = "FileManager", action = "DeleteFile" });
            context.MapRoute("FileManager", "file-manager", new { controller = "FileManager", action = "Index" });
        }
    }
}
