using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Common.Encryption;
using Portal.Membership.Enums;
using Portal.Websites.Models;
using Portal.Membership.Validation;
using Portal.Websites.Interfaces;
using Portal.Membership.Attributes;

namespace Portal.Membership.Models
{
    public class Member : IMember
    {
        public const string DefaultPassword = "PA$$word1";
        private int _id;
        private string _email = string.Empty;
        private string _password = string.Empty;// Member.DefaultPassword;
        private DateTime _dateCreated = DateTime.Now;

        private string _passwordHashed = string.Empty;
        private bool _passwordChanged = false;

        private IList<IWebsite> _websites = new List<IWebsite>();

        private IList<Role> _roles = new List<Role>();

        private Profile _profile = new Profile();

        public virtual int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public virtual string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public virtual string Password
        {
            get { return this._password; }
            set
            {
                this._password = value;

                if (!string.IsNullOrEmpty(this._password))
                {
                    this._passwordHashed = SimpleHash.ComputeHash(this._password, "MD5");
                }
            }
        }

        public virtual string PasswordHashed
        {
            get { return this._passwordHashed; }
        }

        public DateTime DateCreated
        {
            get { return this._dateCreated; }
            internal set { this._dateCreated = value; }
        }

        public virtual IList<Role> Roles
        {
            get { return this._roles; }
            set { this._roles = value; }
        }

        public virtual IList<IWebsite> Websites
        {
            get { return this._websites; }
            set { this._websites = value; }
        }

        public virtual Profile Profile
        {
            get { return this._profile; }
            set { this._profile = value; }
        }
    }
}
