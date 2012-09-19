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
    /// The validation attribute says that a certain property is required in the "properties" is null
    /// Eg. Rego is required if Vin is null
    /// </summary>
    public class RequiredIfPropertiesIsNullAttribute : ValidationAttribute, IClientValidatable
    {
        public RequiredIfPropertiesIsNullAttribute(string[] properties)
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
                if (propertyValue != null || value != null)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessageString);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule requiredIfNull = new ModelClientValidationRule();
            requiredIfNull.ErrorMessage = this.ErrorMessage;
            requiredIfNull.ValidationType = "requiredifpropertiesisnull";
            requiredIfNull.ValidationParameters.Add("properties", string.Join(",", this.Properties));
            yield return requiredIfNull;

        }
    }
}