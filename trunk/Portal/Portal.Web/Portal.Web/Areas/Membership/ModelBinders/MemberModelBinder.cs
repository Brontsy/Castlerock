using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Membership;
using System.Web.Mvc;
using Portal.Membership.Models;
using Portal.Web.ModelBinders;

namespace Portal.Web.Areas.Membership.ModelBinders
{
    /// <summary>
    /// Custom Model Binder for a member. This allows us to only bind certain member attributes that 
    /// we want. If we used the default model binder, people would be able to say post up DateJoined = '1 Jan 1900' and it would add
    /// that value for the date joined property on the member
    /// </summary>
    public class MemberModelBinder : PortalModelBinder
    {
        private IMembershipService _membershipService = null;

        public MemberModelBinder(IMembershipService membershipService)
        {
            this._membershipService = membershipService;
        }

        public override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Member member = new Member();

            // Set the name
            if (bindingContext.ValueProvider.GetValue("memberId") != null && bindingContext.ValueProvider.GetValue("memberId").AttemptedValue != null)
            {
                // attempt to get the member id from the posted values
                string id = bindingContext.ValueProvider.GetValue("memberId").AttemptedValue;
                int memberId;

                // if its a valid member id then load that member from teh database
                if (id != "0" && int.TryParse(id, out memberId))
                {
                    member = this._membershipService.GetMemberById(memberId);
                }
            }

            return member;
        }
    }
}