using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.StorageClient;
using Portal.Web.Areas.FileManager.Models;
using Portal.Websites.Interfaces;
using Portal.FileManager;

namespace Portal.Web.Areas.FileManager.Controllers
{
    public class FileManagerController : Controller
    {
        private IWebsite _website = null;
        private IFileManagerService _fileManagerService = null;

        public FileManagerController(IWebsite website, IFileManagerService fileManagerService)
        {
            this._website = website;
            this._fileManagerService = fileManagerService;
        }

        public ActionResult Index()
        {
            return View("Index", new FileManagerPageViewModel(this._website, this._fileManagerService.GetStorageItems(string.Empty), string.Empty));
        }

        public ActionResult View(string path)
        {
            return View("Index", new FileManagerPageViewModel(this._website, this._fileManagerService.GetStorageItems(path), path));
        }
        
        public ActionResult DeleteFolder(string path)
        {
            this._fileManagerService.DeleteFolder(path);

            // If there was a problem then return the edit view
            return this.RedirectToRoute("FileManager");
        }

        public ActionResult DeleteFile(string path)
        {
            this._fileManagerService.DeleteFile(path);

            // If there was a problem then return the edit view
            return this.RedirectToRoute("FileManager");
        }
        

        public ActionResult NewFolder(string FolderName, string path)
        {
            this._fileManagerService.CreateFolder(FolderName, path);

            return this.RedirectToRoute("FileManager-View", new { path = path });
        }

        public ActionResult Upload(string path)
        {
            return this.Json(this._fileManagerService.UploadFiles(Request.Files, path));
        }

    }
}
