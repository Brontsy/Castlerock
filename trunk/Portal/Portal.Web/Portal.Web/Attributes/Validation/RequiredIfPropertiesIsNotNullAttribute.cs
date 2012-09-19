using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace Portal.Web.Attributes.Validation
{
    /// <summary>
    /// This validation attribute says that the property is only required if the "properties" are not null
    /// Eg. Rego Expiry is not required unless the users enters a Rego value
    /// </summary>
    public class RequiredIfPropertiesIsNotNullAttribute : ValidationAttribute, IClientValidatable
    {
        public RequiredIfPropertiesIsNotNullAttribute(string[] properties)
        {
            this.Properties = properties;
        }

        public string[] Properties { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            foreach (string propertyName in this.Properties)
            {
                var propertyInfo = validationContext.ObjectType.GetProperty(propertyName);

                var propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);

                // if both values are null then it is invalid
                if (propertyValue != null && value == null)
                {
                    return new ValidationResult(ErrorMessageString);
                }
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule requiredIfNotNull = new ModelClientValidationRule();
            requiredIfNotNull.ErrorMessage = this.ErrorMessage;
            requiredIfNotNull.ValidationType = "requiredifpropertiesisnotnull";
            requiredIfNotNull.ValidationParameters.Add("properties", string.Join(",", this.Properties));
            yield return requiredIfNotNull;

        }
    }
}