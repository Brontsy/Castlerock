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
        private string _name = string.Empty;
        private string _company = string.Empty;
        private string _username = string.Empty;
        private string _email = string.Empty;
        private string _password = Member.DefaultPassword;
        private DateTime _dateCreated = DateTime.Now;

        private string _passwordHashed = string.Empty;
        private bool _passwordChanged = false;

        private IList<IWebsite> _websites = new List<IWebsite>();

        private IList<Role> _roles = new List<Role>();

        public virtual int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        //[Required(ErrorMessage = "* Please enter a name")]
        //[DisplayName("Name")]
        public virtual string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        //[DisplayName("Company")]
        public virtual string Company
        {
            get { return this._company; }
            set { this._company = value; }
        }

        //[Required(ErrorMessage = "* Please enter a Username")]
        //[DisplayName("Username")]
        public virtual string Username
        {
            get { return this._username; }
            set { this._username = value; }
        }

        //[DisplayName("Email")]
        public virtual string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        //[PasswordMinLengthAttribute(6, ErrorMessage = "* Password must be at least 6 characters long")]
        //[PasswordRequired(ErrorMessage = "* Please enter a password")]
        //[DisplayName("Password")]
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

        //[Required(ErrorMessage = "* Please enter a password")]
        //[MinimumLength(6, ErrorMessage = "* Password must be at least 6 characters long")]
        //[DisplayName("Password")]
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
    }
}
