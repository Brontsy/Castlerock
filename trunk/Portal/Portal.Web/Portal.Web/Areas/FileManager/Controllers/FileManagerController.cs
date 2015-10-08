using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Web.Areas.FileManager.Models;
using Portal.Websites.Interfaces;
using Portal.FileManager;
using Portal.FileManager.Interfaces;
using Portal.FileManager.Models;
using Portal.Web.Attributes;

namespace Portal.Web.Areas.FileManager.Controllers
{
    [AdministratorFilter]
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
            var viewModel = new FileManagerPageViewModel(this._website, null, this._fileManagerService.GetStorageItems(null));

            return View("Index", viewModel);
        }

        public ActionResult View(string storageItemId)
        {
            IStorageItem currentStorageItem = null;

            if (!string.IsNullOrEmpty(storageItemId))
            {
                currentStorageItem = this._fileManagerService.GetStorageItem(storageItemId);
            }

            var viewModel = new FileManagerPageViewModel(this._website, currentStorageItem, this._fileManagerService.GetStorageItems(storageItemId));

            return View("Index", viewModel);
        }

        [ValidateInput(false)]
        public ActionResult DeleteFolder(string storageItemId)
        {
            IStorageItem item = this._fileManagerService.DeleteFolder(storageItemId);
            
            if (item != null)
            {
                return this.RedirectToRoute("FileManager-View", this.GetRouteValues(item.Path));
            }

            return this.RedirectToRoute("FileManager");
        }

        /// <summary>
        /// TODO: Make this accept a IStoreage Item
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private object GetRouteValues(string path)
        {
            string originalPath = path;
            if (path != null && path.EndsWith("/"))
            {
                path = path.Substring(0, path.Length - 1);
                originalPath = path;
            }

            path = (path == null ? null : path.Replace("/", "-"));

            return new { path = path, storageItemId = originalPath };
        }

        [ValidateInput(false)]
        public ActionResult DeleteFile(string storageItemId)
        {
            IStorageItem item = this._fileManagerService.GetStorageItem(storageItemId);

            this._fileManagerService.DeleteFile(storageItemId);

            if (item.Parent != null)
            {
                return this.RedirectToRoute("FileManager-View", this.GetRouteValues(item.Path));
            }

            return this.RedirectToRoute("FileManager");
        }


        public ActionResult NewFolder(string FolderName, string path)
        {
            this._fileManagerService.CreateFolder(FolderName, path);

            if (!string.IsNullOrEmpty(path))
            {
                return this.RedirectToRoute("FileManager-View", this.GetRouteValues(path));
            }

            return this.RedirectToRoute("FileManager");
        }

        public ActionResult Upload(string parentFolderId)
        {
            var uploadedItems = this._fileManagerService.UploadFiles(Request.Files, parentFolderId);

            var storageItems = this._fileManagerService.GetStorageItems(parentFolderId);

            return this.View("StorageItems", new FileManagerPageViewModel(this._website, null, storageItems).StorageItems);
        }

    }
}
