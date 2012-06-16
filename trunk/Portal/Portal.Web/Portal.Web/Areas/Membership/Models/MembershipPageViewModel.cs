using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Web.Models;
using Portal.Web.Areas.Membership.Extensions;
using Portal.Websites.Interfaces;
using Portal.Membership.Models;

namespace Portal.Web.Areas.Membership.Models
{
    public class MembershipPageViewModel : PageViewModel
    {
        /// <summary>
        /// Creates a new view model to view / edit / create a member
        /// </summary>
        /// <param name="website">the website portal we are in</param>
        /// <param name="member">the member to view / edit or create</param>
        public MembershipPageViewModel(IWebsite website, Member member)
            : base(website)
        {
            this.Member = member.ToViewModel();
        }

        /// <summary>
        /// Creates a view model to render a list of members onto the page
        /// </summary>
        /// <param name="website">the website portal we are in</param>
        /// <param name="members">the members to render on the page</param>
        public MembershipPageViewModel(IWebsite website, IList<Member> members)
            : base(website)
        {
            this.Members = members.Select(o => o.ToViewModel()).ToList();
        }

        public IList<MemberViewModel> Members { get; set; }

        public MemberViewModel Member { get; set; }
    }
}