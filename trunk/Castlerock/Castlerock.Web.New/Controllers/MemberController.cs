using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.New.Models;
using System.Web.Security;
using System.Configuration;
using Castlerock.FileManager;
using Castlerock.FileManager.Interfaces;

namespace Castlerock.Web.New.Controllers
{
    public class MemberController : Controller
    {
        private IFileManagerService _fileManagerService;

        public MemberController(IFileManagerService fileManagerService)
        {
            this._fileManagerService = fileManagerService;
        }

        [HttpGet]
        public ActionResult Downloads()
        {
            string pdfFolder = ConfigurationManager.AppSettings["PdfFolder"].ToString();

            IList<IStorageItem> items = this._fileManagerService.GetStorageItems(pdfFolder);
            ViewBag.StorageItems = items.OrderBy(o => o.Uri.ToString()).ToList();
            ViewBag.Title = "Downloads";

            return View("Downloads");
        }
    }
}
