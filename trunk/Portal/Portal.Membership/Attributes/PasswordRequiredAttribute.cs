using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Portal.Membership.Models;

namespace Portal.Membership.Attributes
{
    public class PasswordRequiredAttribute : ValidationAttribute
    {
        public bool PasswordChanged { get; set; }

        public override bool IsValid(object value)
        {
            string password = value.ToString();

            // We only want to do validation when the password changes!
            if (password != Member.DefaultPassword)
            {
                if (string.IsNullOrEmpty(password))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
