using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Membership.Models;
using Portal.Membership;
using Ninject;
using Portal.Web.Areas.Membership.Models;

namespace Portal.Web.Areas.Membership.ModelBinders
{
    /// <summary>
    /// Custom Model Binder Provider that allows us to check if the incoming type is of Member or MemberViewModel
    /// then we can let MVC know it should use the Member Model Binder to bind hte model the the action method
    /// </summary>
    public class MemberModelBinderProvider : IModelBinderProvider
    {
        private IKernel _kernel = null;

        public MemberModelBinderProvider(IKernel kernel)
        {
            this._kernel = kernel;
        }

        #region IModelBinderProvider Members

        public IModelBinder GetBinder(Type modelType)
        {
            if (modelType == typeof(Member))
            {
                return new MemberModelBinder(this._kernel.Get<IMembershipService>());
            }

            return null;
        }

        #endregion
    }
}