using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace Auslink.Web.New.Areas.Admin.Models.Login
{

    public class LoginViewModel
    {
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