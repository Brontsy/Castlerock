using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auslink.Web.Models
{
    public class PageViewModel
    {
        private Login _login = new Login();
        private string _heaerImageUrl = "/Content/Images/header/home.jpg";
        private string _redLogoImageUrl = "/Content/Images/header/quality-assets.png";
        private string _redLogoText = "Quality Assets";
        
        public PageViewModel() { }

        public PageViewModel(Login login)
        {
            this._login = login;
        }

        public Login Login
        {
            get { return this._login; }
            set { this._login = value; }
        }

        /// <summary>
        /// Gets and sets the url of the larger header image on each page
        /// </summary>
        public string HeaderImageUrl
        {
            get { return this._heaerImageUrl; }
            set { this._heaerImageUrl = value; }
        }

        /// <summary>
        /// Gets and sets the url of the image red logo image that sits inside the header
        /// </summary>
        public string RedLogoImageUrl
        {
            get { return this._redLogoImageUrl; }
            set { this._redLogoImageUrl = value; }
        }

        /// <summary>
        /// Gets and sets the text for the "alt" and "title" properties on the red logo image
        /// </summary>
        public string RedLogoText
        {
            get { return this._redLogoText; }
            set { this._redLogoText = value; }
        }
    }
}