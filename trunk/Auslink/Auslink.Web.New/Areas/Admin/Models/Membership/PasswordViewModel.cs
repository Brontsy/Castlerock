using Auslink.Membership.Models;
using Auslink.Web.New.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.Web.New.Areas.Admin.Models.Membership
{
    public class PasswordViewModel
    {
        public int MemberId { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        public PasswordViewModel() { }

        public PasswordViewModel(int memberId)
        {
            this.MemberId = memberId;
        }
    }
}
