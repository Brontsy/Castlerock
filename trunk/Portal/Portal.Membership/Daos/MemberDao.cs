//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Portal.Membership.Models;
//using Portal.Membership.Interfaces;
//using NHibernate;
//using Portal.Websites.Interfaces;

//namespace Portal.Membership.Daos
//{
//    public class MemberDao : IMemberDao
//    {
//        public MemberDao(ISession session)
//            : base(session)
//        {

//        }

//        /// <summary>
//        /// Gets a member from the database by there username
//        /// </summary>
//        /// <param name="email">the username to retrieve the member for</param>
//        /// <returns>A Member object if one exists otherwise null</returns>
//        public Member GetMemberByUsername(IWebsite website, string username)
//        {
//            IQuery query = this.Session.CreateQuery("Select m From Member m Inner Join Fetch m.Websites w  Where m.Username = :username And w.Id = :websiteId");

//            query.SetParameter("username", username);
//            query.SetParameter("websiteId", website.Id);

//            return query.UniqueResult<Member>();
//        }



//        /// <summary>
//        /// Get a specific member by there email
//        /// </summary>
//        /// <param name="email">the email of the member to return</param>
//        public Member GetMemberByEmail(IWebsite website, string email)
//        {
//            IQuery query = this.Session.CreateQuery("Select m From Member m Inner Join Fetch m.Profile p Inner Join Fetch m.Websites w  Where p.Email = :email And w.Id = :websiteId");

//            query.SetParameter("email", email);
//            query.SetParameter("websiteId", website.Id);

//            return query.UniqueResult<Member>();
//        }



//        /// <summary>
//        /// Gets all the members in the system
//        /// </summary>
//        public IList<Member> GetAllMembers(IWebsite website)
//        {
//            IQuery query = this.Session.CreateQuery("Select m From Member m Inner Join Fetch m.Websites w  Where w.Id = :websiteId");

//            query.SetParameter("websiteId", website.Id);

//            return query.List<Member>();
//        }

//        /// <summary>
//        /// Gets a specific member by there id
//        /// </summary>
//        /// <param name="website">the website this member should belong to</param>
//        /// <param name="member">the id of the member</param>
//        public Member GetMemberById(IWebsite website, int memberId)
//        {
//            IQuery query = this.Session.CreateQuery("Select m From Member m Inner Join Fetch m.Websites w  Where m.Id = :memberId And w.Id = :websiteId");

//            query.SetParameter("memberId", memberId);
//            query.SetParameter("websiteId", website.Id);

//            return query.UniqueResult<Member>();
//        }
//    }
//}
