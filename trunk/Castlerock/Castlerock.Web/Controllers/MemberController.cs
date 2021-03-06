﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castlerock.Web.Models;
using System.Web.Security;
using Portal.FileManager.Interfaces;
using System.Configuration;

namespace Castlerock.Web.Controllers
{
    public class MemberController : Controller
    {
        [HttpGet]
        public ActionResult Downloads()
        {
            string pdfFolder = ConfigurationManager.AppSettings["PdfFolder"].ToString();

            IList<IStorageItem> items = ServiceLocator.GetFileManagerService().GetStorageItems(pdfFolder);
            ViewData["StorageItems"] = items.OrderBy(o => o.Uri.ToString()).ToList();

            return View("Downloads", new PageViewModel() { Title = "Downloads" });
        }
    }
}
