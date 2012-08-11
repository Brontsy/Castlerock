using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.StorageClient;
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

        public ActionResult View(int? storageItemId)
        {
            IStorageItem currentStorageItem = null;

            if (storageItemId.HasValue)
            {
                currentStorageItem = this._fileManagerService.GetStorageItem(storageItemId.Value);
            }

            var viewModel = new FileManagerPageViewModel(this._website, currentStorageItem, this._fileManagerService.GetStorageItems(storageItemId));

            return View("Index", viewModel);
        }

        public ActionResult DeleteFolder(int storageItemId)
        {
            IStorageItem item = this._fileManagerService.GetStorageItem(storageItemId);

            this._fileManagerService.DeleteFolder(storageItemId);

            if (item.Parent != null)
            {
                return this.RedirectToRoute("FileManager-View", new { storageItemId = item.Parent.Id });
            }

            return this.RedirectToRoute("FileManager");
        }

        public ActionResult DeleteFile(int storageItemId)
        {
            IStorageItem item = this._fileManagerService.GetStorageItem(storageItemId);

            this._fileManagerService.DeleteFile(storageItemId);

            if (item.Parent != null)
            {
                return this.RedirectToRoute("FileManager-View", new { storageItemId = item.Parent.Id });
            }

            return this.RedirectToRoute("FileManager");
        }
        

        public ActionResult NewFolder(string FolderName, int? storageItemId)
        {
            this._fileManagerService.CreateFolder(FolderName, storageItemId);

            if (storageItemId.HasValue)
            {
                return this.RedirectToRoute("FileManager-View", new { storageItemId = storageItemId });
            }

            return this.RedirectToRoute("FileManager");
        }

        public ActionResult Upload(int? parentFolderId)
        {
            var storageItems = this._fileManagerService.UploadFiles(Request.Files, parentFolderId);

            return this.View("StorageItems", storageItems.Select(o => new FileViewModel(o as File) as IStorageItemViewModel).ToList());
        }

    }
}
