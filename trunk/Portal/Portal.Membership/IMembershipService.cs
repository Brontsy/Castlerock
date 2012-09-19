using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Nhibernate;
using Portal.Membership.Models;

namespace Portal.Membership
{
    public interface IMembershipService
    {
        /// <summary>
        /// Authenticates the email address and password passed in
        /// </summary>
        /// <param name="email">the members email address</param>
        /// <param name="password">the members password</param>
        /// <returns>true if the email and password match a record in the database</returns>
        bool Authenticate(string email, string password);
        
        /// <summary>
        /// Authenticates the email address and password passed
        /// </summary>
        /// <param name="email">the members email address</param>
        /// <param name="password">the members password</param>
        /// <returns>true if the email and password match a record in the database</returns>
        bool AuthenticateEmail(string email, string password);


        IList<Role> GetRoles();

        /// <summary>
        /// Gets all the members in the system
        /// </summary>
        IList<Member> GetAllMembers();

        /// <summary>
        /// Get a specific member by ther Id
        /// </summary>
        /// <param name="memberId">the Id of the member to return</param>
        Member GetMemberById(int memberId);

        /// <summary>
        /// Get a specific member by there username
        /// </summary>
        /// <param name="username">the username of the member to return</param>
        Member GetMemberByUsername(string username);

        /// <summary>
        /// Changes the members password to the password passed in
        /// </summary>
        /// <param name="member">the member to update the password for</param>
        /// <param name="password">the password</param>
        void ChangePassword(Member member, string password);

        /// <summary>
        /// Saves the member back to the database
        /// </summary>
        /// <param name="member">The member to save</param>
        void SaveMember(Member member);
    }
}
