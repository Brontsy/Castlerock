using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Portal.Membership.Validation
{
    public class MinimumLength : ValidationAttribute
    {
        public int Lenth { get; set; }

        public MinimumLength(int minLength)
        {
            Lenth = minLength;
        }

        public override bool IsValid(object value)
        {
            if (null == value)
            {
                return true;
            }

            if (value.ToString().Length < this.Lenth)
            {
                return false;
            }
                
            return true;
        }
    }
}
