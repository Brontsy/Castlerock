using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Membership.Models;
using Portal.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Portal.Web.Areas.Membership.Models
{
    public class MemberViewModel
    {
        private int _id = 0;
        private string _name = string.Empty;
        private string _username = string.Empty;
        private string _email = string.Empty;
        private string _company = string.Empty;

        private Member _member = null;

        private ChangePasswordViewModel _changePassword = null;
        
        public MemberViewModel() { }

        public MemberViewModel(Member member)
        {
            this._member = member;

            this._id = member.Id;
            this._name = member.Name;
            this._username = member.Username;
            this._email = member.Email;
            this._company = member.Company;
        }

        /// <summary>
        /// Gets the id of the member
        /// </summary>
        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        /// <summary>
        /// Gets the name of the member
        /// </summary>
        [Required(ErrorMessage = "* Please enter a name")]
        [DisplayName("Name")]
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// Gets the members name that can be then used in the url
        /// </summary>
        public string NameUrlFriendly
        {
            get 
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    return string.Empty;
                }

                return this.Name.Replace("/", "-").Replace("&", string.Empty).Replace("?", string.Empty).Replace(" ", "-"); 
            }
        }

        /// <summary>
        /// Gets the name of the username
        /// </summary>
        [Required(ErrorMessage = "* Please enter a Username")]
        [DisplayName("Username")]
        public string Username
        {
            get { return this._username; }
            set { this._username = value; }
        }

        /// <summary>
        /// Gets the email of the member
        /// </summary>
        [DisplayName("Email")]
        public string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        /// <summary>
        /// Gets the company this member works for
        /// </summary>
        [DisplayName("Company")]
        public string Company
        {
            get { return this._company; }
            set { this._company = value; }
        }

        /// <summary>
        /// Gets the date cerated of the member
        /// </summary>
        public string DateCreated
        {
            get
            {
                if (this._member != null)
                {
                    return this._member.DateCreated.ToString("d MMMM yyy");
                }

                return string.Empty;
            }
        }

        public ChangePasswordViewModel ChangePassword
        {
            get
            {
                if (this._changePassword == null)
                {
                    this._changePassword = new ChangePasswordViewModel();
                } 

                return this._changePassword;
            }
        }
    }
}