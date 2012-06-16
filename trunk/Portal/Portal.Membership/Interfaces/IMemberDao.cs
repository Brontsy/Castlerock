using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Membership.Models;
using Portal.Websites.Interfaces;

namespace Portal.Membership.Interfaces
{
    public interface IMemberDao : Common.Nhibernate.IBaseDao<Member, int>
    {
        /// <summary>
        /// Gets a member from the database by there username
        /// </summary>
        /// <param name="email">the username to retrieve the member for</param>
        /// <returns>A Member object if one exists otherwise null</returns>
        Member GetMemberByUsername(IWebsite website, string username);

        /// <summary>
        /// Gets a specific member by there id
        /// </summary>
        /// <param name="website">the website this member should belong to</param>
        /// <param name="member">the id of the member</param>
        Member GetMemberById(IWebsite website, int memberId);

        /// <summary>
        /// Gets all the members in the system
        /// </summary>
        IList<Member> GetAllMembers(IWebsite website);
    }
}
