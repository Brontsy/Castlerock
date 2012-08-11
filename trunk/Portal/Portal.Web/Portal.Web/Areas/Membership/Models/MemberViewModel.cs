using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Membership.Models;
using Portal.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Portal.Membership.Validation;

namespace Portal.Web.Areas.Membership.Models
{
    public class MemberViewModel
    {
        private int _id = 0;
        private string _email = string.Empty;
        private string _password = string.Empty;

        private Member _member = null;
        private ProfileViewModel _profile = new ProfileViewModel();
        private ChangePasswordViewModel _changePassword = new ChangePasswordViewModel();
        
        public MemberViewModel() { }

        public MemberViewModel(Member member)
        {
            this._member = member;
            this._profile = new ProfileViewModel(member.Profile);

            this._id = member.Id;
            this._password = member.Password;
            this._email = member.Email;
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
        /// Gets the email of the member
        /// </summary>
        [DisplayName("Email*")]
        public string Email
        {
            get { return this._email; }
            set { this._email = value; }
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

        public ProfileViewModel Profile
        {
            get { return this._profile; }
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