using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using Portal.Websites.Interfaces;

namespace Portal.Web.Models
{
    public class LoginViewModel : PageViewModel
    {
        public LoginViewModel(IWebsite website)
            : base (website)
        {

        }
        
        [DisplayName("Username")]
        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DisplayName("Password")]
        public string Password { get; set; }

    }
}