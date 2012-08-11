using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.FileManager;

namespace Portal.Web.Areas.FileManager.Controllers
{
    public class BlobStorageController : Controller
    {
        private IFileManagerService _fileManagerService;

        public BlobStorageController(IFileManagerService fileManagerService)
        {
            this._fileManagerService = fileManagerService;
        }

        public ActionResult Index()
        {
            return View("Index", this._fileManagerService.GetBlobStorageItems());
        }

        public ActionResult Delete(string path)
        {
            this._fileManagerService.DeleteBlobStorageItem(path);

            return this.Index();
        }
    }
}