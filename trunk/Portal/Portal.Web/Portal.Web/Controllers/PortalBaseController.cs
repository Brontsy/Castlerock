using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Web.Attributes;
using Portal.Websites.Interfaces;

namespace Portal.Web.Controllers
{
    public class PortalBaseController : Controller
    {
        private IWebsite _website;

        public PortalBaseController(IWebsite website)
        {
            this._website = website;
        }

        /// <summary>
        /// Gets the website that this portal is for
        /// </summary>
        protected IWebsite Website
        {
            get { return this._website; }
        }

        /// <summary>
        /// Sets a confirmation message for the page
        /// </summary>
        public string ConfirmationMessage
        {
            set
            {
                this.TempData["ConfirmationMessage"] = value;
            }
        }

        /// <summary>
        /// Sets a error message for the page
        /// </summary>
        public string ErrorMessage
        {
            set
            {
                this.TempData["ErrorMessage"] = value;
            }
        }
    }
}
