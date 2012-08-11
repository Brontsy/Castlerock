using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Membership.Models;
using Portal.Membership;
using Ninject;
using Portal.Web.Areas.Membership.Models;
using Portal.Cms.Interfaces;
using Portal.Interfaces.Cms;

namespace Portal.Web.Areas.CMS.ModelBinders
{
    /// <summary>
    /// Custom Model Binder Provider that allows us to check if the incoming type is of Member or MemberViewModel
    /// then we can let MVC know it should use the Member Model Binder to bind hte model the the action method
    /// </summary>
    public class ControlModelBinderProvider : IModelBinderProvider
    {
        private IKernel _kernel = null;

        public ControlModelBinderProvider(IKernel kernel)
        {
            this._kernel = kernel;
        }

        #region IModelBinderProvider Members

        public IModelBinder GetBinder(Type modelType)
        {
            if (modelType == typeof(IControl))
            {
                return new ControlModelBinder(this._kernel);
            }

            return null;
        }

        #endregion
    }
}