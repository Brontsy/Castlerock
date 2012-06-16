using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Web.Areas.Membership.Models;
using Portal.Membership.Models;

namespace Portal.Web.Areas.Membership.Extensions
{
    public static class MembershipExtensions
    {
        /// <summary>
        /// Converts a member object into a member view model
        /// </summary>
        public static MemberViewModel ToViewModel(this Member member)
        {
            return new MemberViewModel(member);
        }

        /// <summary>
        /// Converts a member view model back into a member object.
        /// </summary>
        /// <param name="member">the member object to copy the properties into</param>
        /// <returns>the member object with its properties updated</returns>
        public static Member ToMember(this MemberViewModel viewModel, Member member)
        {
            member.Name = viewModel.Name;
            member.Username = viewModel.Username;
            member.Company = viewModel.Company;
            member.Email = viewModel.Email;

            return member;
        }
    }
}