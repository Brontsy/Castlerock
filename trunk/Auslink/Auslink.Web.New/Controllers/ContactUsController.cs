﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auslink.Web.New.Models;

namespace Auslink.Web.New.Controllers
{
    public class ContactUsController : Controller
    {
        public ActionResult Index()
        {
            PageViewModel page = new PageViewModel();
            page.RedLogoImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/attractive-yields.png";
            page.RedLogoText = "Attractive Yields";
            page.HeaderImageUrl = "http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/contact-us.jpg";

            return View(page);
        }
    }
}