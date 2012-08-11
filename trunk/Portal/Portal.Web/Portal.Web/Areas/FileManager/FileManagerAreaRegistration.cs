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
            context.MapRoute("FileManager-New-Root-Folder", "File-Manager/New-Folder", new { controller = "FileManager", action = "NewFolder" });
            context.MapRoute("FileManager-New-Child-Folder", "File-Manager/New-Folder/{storageItemId}/{path}", new { controller = "FileManager", action = "NewFolder" });

            context.MapRoute("FileManager-Upload", "File-Manager/Upload", new { controller = "FileManager", action = "Upload" });

            context.MapRoute("BlobStorage", "BlobStorage", new { controller = "BlobStorage", action = "Index" });
            context.MapRoute("BlobStorage-Delete", "BlobStorage/Delete", new { controller = "BlobStorage", action = "Delete" });


            context.MapRoute("FileManager-View", "File-Manager/{storageItemId}/{path}", new { controller = "FileManager", action = "View", path = UrlParameter.Optional, storageItemId = UrlParameter.Optional });

            context.MapRoute("FileManager-Folder-Delete", "File-Manager/Folder/Delete/{storageItemId}/{path}", new { controller = "FileManager", action = "DeleteFolder" });
            context.MapRoute("FileManager-File-Delete", "File-Manager/File/Delete/{storageItemId}/{path}", new { controller = "FileManager", action = "DeleteFile" });
            context.MapRoute("FileManager", "File-Manager", new { controller = "FileManager", action = "Index" });
        }
    }
}
