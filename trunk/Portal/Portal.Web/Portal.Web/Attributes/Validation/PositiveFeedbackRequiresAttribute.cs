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
    /// This validation attribute says that a certain properties requires properties X,Y and Z before
    /// positive feedback is given to the user
    /// </summary>
    public class PositiveFeedbackRequiresAttribute : ValidationAttribute, IClientValidatable
    {
        public PositiveFeedbackRequiresAttribute(string[] properties)
        {
            this.Properties = properties;
        }

        public PositiveFeedbackRequiresAttribute(string property)
        {
            this.Properties = new string[] { property };
        }

        public string[] Properties { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule positiveFeedback = new ModelClientValidationRule();
            positiveFeedback.ErrorMessage = this.ErrorMessage;
            positiveFeedback.ValidationType = "positivefeedbackrequires";
            positiveFeedback.ValidationParameters.Add("properties", string.Join(",", this.Properties));
            yield return positiveFeedback;

        }
    }
}