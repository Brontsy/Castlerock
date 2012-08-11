using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Portal.Membership.Models;

namespace Portal.Membership.Attributes
{
    public class PasswordMinLengthAttribute : ValidationAttribute
    {
        private  int MinLength { get; set; }

        public PasswordMinLengthAttribute(int minLength)
        {
            MinLength = minLength;
        }

        public override bool IsValid(object value)
        {
            string password = value.ToString();
            // We only want to do validation when the password changes!
            //if (password != Member.DefaultPassword)
            //{
                if (string.IsNullOrEmpty(password) || password.Length < this.MinLength)
                {
                    return false;
                }
            //}

            return true;
        }
    }
}
