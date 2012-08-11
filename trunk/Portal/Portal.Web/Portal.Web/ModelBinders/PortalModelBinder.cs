using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Web.ModelBinders
{
    /// <summary>
    /// This code was not actually written by me, it was taken from the net as I needed to use a custom model binder
    /// and still allow for data annotation validation
    /// </summary>
    public abstract class PortalModelBinder : DefaultModelBinder
    {

        // Abstract methods
        public abstract object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext);

        // Methods
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Create model
            object model = this.CreateModel(controllerContext, bindingContext);

            if (controllerContext.RequestContext.HttpContext.Request.HttpMethod == "POST")
            {
                bindingContext.ModelName = model.GetType().Name;

                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, model.GetType());
                bindingContext.ModelMetadata.Model = model;

                model = base.BindModel(controllerContext, bindingContext);

            }

            return model;

            // Iterate through model properties
            foreach (ModelMetadata property in bindingContext.PropertyMetadata.Values)
            {
                // Get property value
                property.Model = bindingContext.ModelType.GetProperty(property.PropertyName).GetValue(model, null);

                // Get property validator
                foreach (ModelValidator validator in property.GetValidators(controllerContext))
                {
                    // Validate property
                    foreach (ModelValidationResult result in validator.Validate(model))
                    {
                        // Add error message into model state
                        bindingContext.ModelState.AddModelError(property.PropertyName, result.Message);
                    }
                }
            }

            return model;
        }

        // IModelBinder members
        //object IModelBinder.BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        //{
        //    return this.BindModel(controllerContext, bindingContext);
        //}

    }

    /// <summary>
    /// This code was not actually written by me, it was taken from the net as I needed to use a custom model binder
    /// and still allow for data annotation validation
    /// </summary>
    public abstract class GetPortalModelBinder : DefaultModelBinder
    {

        // Abstract methods
        public abstract object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext);

        // Methods
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Create model
            return this.CreateModel(controllerContext, bindingContext);
        }

        // IModelBinder members
        //object IModelBinder.BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        //{
        //    return this.BindModel(controllerContext, bindingContext);
        //}

    }
}