using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace Portal.Web.Attributes.Validation
{
    public class IsTrueAttribute : ValidationAttribute, IClientValidatable
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is bool && (bool)value)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(this.ErrorMessage);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule isTrueAttribute = new ModelClientValidationRule();
            isTrueAttribute.ErrorMessage = this.ErrorMessage;
            isTrueAttribute.ValidationType = "istrue";
            yield return isTrueAttribute;

        }
    }
}