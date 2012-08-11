using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Castlerock.Web.Models
{
    public class Login : PageViewModel
    {
        public Login() { this.Title = "Login"; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DisplayName("Password")]
        public string Password { get; set; }

    }
}