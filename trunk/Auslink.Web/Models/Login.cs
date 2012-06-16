using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Auslink.Web.Validation;
using System.Web.Security;

namespace Auslink.Web.Models
{
    public enum LoginLocation { Home, CurrentUnitHolders };

    public class Login
    {
        private LoginLocation _loginLocation = LoginLocation.Home;

        /// <summary>
        /// Gets and sets the location the user is logging in from
        /// </summary>
        public LoginLocation LoginLocation
        {
            get { return this._loginLocation; }
            set { this._loginLocation = value; }
        }

        /// <summary>
        /// Is the member logged in or not
        /// </summary>
        public bool IsLoggedIn
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }

        [DisplayName("Username")]
        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DisplayName("Password")]
        public string Password { get; set; }

    }
}