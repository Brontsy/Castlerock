using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Auslink.Web.New.Attributes.Validation
{
    public class PhoneNumberAttribute : RegularExpressionAttribute
    {
        static PhoneNumberAttribute()
        {
            // necessary to enable client side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(PhoneNumberAttribute), typeof(RegularExpressionAttributeAdapter));
        }

        public PhoneNumberAttribute()
            : base(@"^\({0,1}((0|\+61|61)(2|4|3|7|8)){0,1}\){0,1}(\ |-){0,1}[0-9]{2}(\ |-){0,1}[0-9]{2}(\ |-){0,1}[0-9]{1}(\ |-){0,1}[0-9]{3}$")
        {
        }
    }
}
