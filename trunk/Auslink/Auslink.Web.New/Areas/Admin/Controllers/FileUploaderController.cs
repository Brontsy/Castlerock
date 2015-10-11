using Auslink.FileManager;
using Auslink.Web.New.Areas.Admin.Models.FileUploader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auslink.Web.New.Areas.Admin.Controllers
{
    public class FileUploaderController : Controller
    {
        private IFileManagerService _fileManagerService;

        public FileUploaderController(IFileManagerService fileManagerService)
        {
            this._fileManagerService = fileManagerService;
        }

        public ActionResult Index(int maxFiles, string fieldName, string description, string path)
        {
            FileUploaderViewModel viewModel = new FileUploaderViewModel(maxFiles, fieldName, description, path);

            return this.PartialView("Index", viewModel);
        }

        public ActionResult Upload(string path)
        {
            var result = this._fileManagerService.UploadFiles(this.Request.Files, path);


            return this.Json(new { fileName = result.First().Name, path = result.First().Path, uri = result.First().Uri });
        }
    }
}