using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Portal.Membership.Validation;

namespace Portal.Web.Areas.Membership.Models
{
    public class ChangePasswordViewModel
    {
        private string _password = string.Empty;

        /// <summary>
        /// Gets the password of the member
        /// </summary>
        [Required(ErrorMessage = "* Please enter a password")]
        [MinimumLength(6, ErrorMessage = "* Password must be at least 6 characters long")]
        [DisplayName("Password")]
        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }

    }
}