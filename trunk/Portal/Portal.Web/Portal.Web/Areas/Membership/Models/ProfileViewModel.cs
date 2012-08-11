using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Membership.Models;
using Portal.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Common.Extensions;

namespace Portal.Web.Areas.Membership.Models
{
    public class ProfileViewModel
    {
        private int _id = 0;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _username = string.Empty;
        private string _company = string.Empty;
        private string _phone = string.Empty;

        private Profile _profile = null;


        public ProfileViewModel() { }

        public ProfileViewModel(Profile profile)
        {
            this._profile = profile;

            if (this._profile != null)
            {
                this._id = profile.Id;
                this._firstName = profile.FirstName;
                this._lastName = profile.LastName;
                this._username = profile.Username;
                this._company = profile.Company;
                this._phone = profile.Phone;
            }
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
        /// Gets the first name of the member
        /// </summary>
        [DisplayName("First Name")]
        public string FirstName
        {
            get { return this._firstName; }
            set { this._firstName = value; }
        }

        /// <summary>
        /// Gets the first name of the member
        /// </summary>
        [DisplayName("Last Name")]
        public string LastName
        {
            get { return this._lastName; }
            set { this._lastName = value; }
        }

        /// <summary>
        /// Gets the members name that can be then used in the url
        /// </summary>
        public string NameUrlFriendly
        {
            get
            {
                if (string.IsNullOrEmpty(this.FirstName) && string.IsNullOrEmpty(this.LastName) && string.IsNullOrEmpty(this.Company))
                {
                    return string.Empty;
                }

                return this.FirstName.ToUrl() + this.LastName.ToUrl() + this.Company.ToUrl();
            }
        }

        /// <summary>
        /// Gets the name of the username
        /// </summary>
        [DisplayName("Phone")]
        public string Phone
        {
            get { return this._phone; }
            set { this._phone = value; }
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

        [DisplayName("Username")]
        public string Username
        {
            get { return this._username; }
            set { this._username = value; }
        }

        /// <summary>
        /// Gets the date cerated of the member
        /// </summary>
        public string DateCreated
        {
            get
            {
                if (this._profile != null)
                {
                    return this._profile.DateCreated.ToString("d MMMM yyy");
                }

                return string.Empty;
            }
        }
    }
}