﻿using Castlerock.Membership.Models;
using Castlerock.Membership.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Castlerock.Web.New.Providers
{
    public interface IMemberProvider
    {
        Member GetLoggedInMember();
    }


    public class MemberProvider : IMemberProvider
    {
        private IMembershipService _membershipService;

        public MemberProvider(IMembershipService membershipService)
        {
            this._membershipService = membershipService;
        }


        public Member GetLoggedInMember()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                int memberId;

                if (int.TryParse(HttpContext.Current.User.Identity.Name, out memberId))
                {
                    return this._membershipService.GetMemberById(memberId);
                }
            }

            return null;
        }
    }
}
