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
            context.MapRoute("FileManager-New-Root-Folder", "file-manager/new-folder", new { controller = "FileManager", action = "NewFolder" });

            context.MapRoute("FileManager-Upload", "file-Manager/upload", new { controller = "FileManager", action = "Upload" });

            context.MapRoute("BlobStorage", "blob-storage", new { controller = "BlobStorage", action = "Index" });
            context.MapRoute("BlobStorage-Delete", "blob-storage/delete", new { controller = "BlobStorage", action = "Delete" });


            context.MapRoute("FileManager-View", "file-manager/{path}", new { controller = "FileManager", action = "View", path = UrlParameter.Optional });

            context.MapRoute("FileManager-Folder-Delete", "file-manager/folder/delete/{path}", new { controller = "FileManager", action = "DeleteFolder" });
            context.MapRoute("FileManager-File-Delete", "file-manager/file/delete", new { controller = "FileManager", action = "DeleteFile" });
            context.MapRoute("FileManager", "file-manager", new { controller = "FileManager", action = "Index" });
        }
    }
}
