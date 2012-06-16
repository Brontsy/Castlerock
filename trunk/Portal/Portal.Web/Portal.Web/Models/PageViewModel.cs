using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Websites.Interfaces;
using Portal.Websites.Models;

namespace Portal.Web.Models
{
    public class PageViewModel
    {
        private IWebsite _website = null;

        public PageViewModel(IWebsite website)
        {
            this._website = website;
        }

        /// <summary>
        /// TODO: Replace with a list of component view models
        /// </summary>
        public IList<ComponentViewModel> Components
        {
            get 
            { 
                return this._website.Components.Select(o => new ComponentViewModel(o)).ToList(); 
            }
        }

        /// <summary>
        /// Gets the url for this websites logo
        /// </summary>
        public string LogoImageUrl
        {
            get { return this._website.LogoImageUrl; }
        }

        /// <summary>
        /// Is the member / administrator logged in?
        /// </summary>
        public bool IsLoggedIn
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }

        /// <summary>
        /// Gets the name of the website that this portal is for
        /// </summary>
        public string WebsiteName
        {
            get { return this._website.Name; }
        }
    }
}