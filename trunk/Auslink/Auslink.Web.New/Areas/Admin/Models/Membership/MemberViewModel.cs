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
    public class MemberViewModel
    {
        public int MemberId { get; set; }

        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }

        [DisplayName("Email")]
        [Email(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Company")]
        public string Company { get; set; }

        [DisplayName("Phone")]
        [PhoneNumber(ErrorMessage = "Please enter a valid australian phone number")]
        public string Phone { get; set; }

        public PasswordViewModel Password { get; set; }

        public IList<Role> SelectedRoles { get; set; }

        public MemberViewModel() 
        {
            this.SelectedRoles = new List<Role>() { Role.Member };
            this.Password = new PasswordViewModel(this.MemberId);
        }

        public MemberViewModel(Member member)
        {
            this.MemberId = member.MemberId;
            this.Username = member.Username;
            this.Email = member.Email;
            this.FirstName = member.FirstName;
            this.LastName = member.LastName;
            this.Company = member.Company;
            this.Phone = member.Phone;
            this.Password = new PasswordViewModel(member.MemberId);
            this.SelectedRoles = member.Roles;
        }
    }
}
