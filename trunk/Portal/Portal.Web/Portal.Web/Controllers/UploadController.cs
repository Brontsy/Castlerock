using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Portal.Membership;
using Portal.Web.Attributes;
using Portal.Web.Areas.Membership;
using Portal.Websites.Interfaces;
using Portal.Web.Models;
using Portal.Membership.Models;
using Portal.Images;

namespace Portal.Web.Controllers
{
    public class UploadController : PortalBaseController
    {
        private IImageService _imageService = null;

        public UploadController(IWebsite website, IImageService imageService)
            : base (website)
        {
            this._imageService = imageService;
        }

        public ActionResult Images(string imagePath)
        {
            return this.Json(this._imageService.UploadImages(Request.Files, imagePath));
        }
    }
}
