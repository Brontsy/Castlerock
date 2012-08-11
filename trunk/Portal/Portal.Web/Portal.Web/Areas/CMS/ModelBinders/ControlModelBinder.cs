using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Membership;
using System.Web.Mvc;
using Portal.Web.ModelBinders;
using Ninject;

namespace Portal.Web.Areas.CMS.ModelBinders
{
    /// <summary>
    /// Custom Model Binder for a member. This allows us to only bind certain member attributes that 
    /// we want. If we used the default model binder, people would be able to say post up DateJoined = '1 Jan 1900' and it would add
    /// that value for the date joined property on the member
    /// </summary>
    public class ControlModelBinder : PortalModelBinder
    {
        private IKernel _kernel;
        public ControlModelBinder(IKernel kernel)
        {
            this._kernel = kernel;
        }

        public override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Set the name
            if (bindingContext.ValueProvider.GetValue("className") != null && bindingContext.ValueProvider.GetValue("className").AttemptedValue != null)
            {
                if (bindingContext.ValueProvider.GetValue("assembly") != null && bindingContext.ValueProvider.GetValue("assembly").AttemptedValue != null)
                {
                    string className = bindingContext.ValueProvider.GetValue("className").AttemptedValue;
                    string assembly = bindingContext.ValueProvider.GetValue("assembly").AttemptedValue;

                    return this._kernel.Get(Type.GetType(className + ", " + assembly));

                    //return (Portal.Cms.Interfaces.IControl)Activator.CreateInstance(Type.GetType(className + ", " + assembly));

                }
            }

            return null;
        }
    }
}