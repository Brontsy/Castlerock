using Auslink.Membership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.Web.New.Areas.Admin.Models.Membership
{
    public class MemberListViewModel
    {
        public IList<MemberViewModel> Members { get; private set; }

        public MemberListViewModel(IList<Member> members)
        {
            this.Members = members.Select(o => new MemberViewModel(o)).ToList();
        }
    }
}
