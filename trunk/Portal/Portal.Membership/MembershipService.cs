using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Encryption;
using Common.Nhibernate;
using Portal.Membership.Interfaces;
using Portal.Membership.Models;
using Portal.Websites.Interfaces;

namespace Portal.Membership
{
    public class MembershipService : IMembershipService
    {
        private IWebsite _website = null;
        private IMemberDao _memberDao = null;
        private ITransactionManager _transactionManager = null;

        public MembershipService(IWebsite website, IMemberDao memberDao, ITransactionManager transactionManager)
        {
            this._website = website;
            this._memberDao = memberDao;
            this._transactionManager = transactionManager;
        }

        /// <summary>
        /// Authenticates the email address and password passed in
        /// </summary>
        /// <param name="email">the members email address</param>
        /// <param name="password">the members password</param>
        /// <returns>true if the email and password match a record in the database</returns>
        public bool Authenticate(string username, string password)
        {
            try
            {
                Member member = this.GetMemberByUsername(username);

                string encryptedPassword = SimpleHash.ComputeHash(password, "MD5");

                if (member != null && SimpleHash.VerifyHash(password, "MD5", member.PasswordHashed))
                {
                    return true;
                }
            }
            catch (Exception exception)
            {
                // TODO: Log Exception
                throw;
            }

            return false;
        }

        /// <summary>
        /// Authenticates the email address and password passed
        /// </summary>
        /// <param name="email">the members email address</param>
        /// <param name="password">the members password</param>
        /// <returns>true if the email and password match a record in the database</returns>
        public bool AuthenticateEmail(string email, string password)
        {
            try
            {
                Member member = this.GetMemberByEmail(email);

                string encryptedPassword = SimpleHash.ComputeHash(password, "MD5");

                if (member != null && SimpleHash.VerifyHash(password, "MD5", member.PasswordHashed))
                {
                    return true;
                }
            }
            catch (Exception exception)
            {
                throw;
            }

            return false;
        }

        /// <summary>
        /// Resets the password for the member
        /// </summary>
        /// <param name="memberId">the id the member to reset the password for</param>
        public void ResetPassword(int memberId)
        {
        }

        /// <summary>
        /// Gets all the members in the system
        /// </summary>
        public IList<Member> GetAllMembers()
        {
            return this._memberDao.GetAllMembers(this._website);
        }

        /// <summary>
        /// Get a specific member by ther Id
        /// </summary>
        /// <param name="memberId">the Id of the member to return</param>
        public Member GetMemberById(int memberId)
        {
            return this._memberDao.GetMemberById(this._website, memberId);
        }

        /// <summary>
        /// Get a specific member by there username
        /// </summary>
        /// <param name="username">the username of the member to return</param>
        public Member GetMemberByUsername(string username)
        {
            return this._memberDao.GetMemberByUsername(this._website, username);
        }

        /// <summary>
        /// Get a specific member by there email
        /// </summary>
        /// <param name="email">the email of the member to return</param>
        public Member GetMemberByEmail(string email)
        {
            return this._memberDao.GetMemberByEmail(this._website, email);
        }

        /// <summary>
        /// Changes the members password to the password passed in
        /// </summary>
        /// <param name="member">the member to update the password for</param>
        /// <param name="password">the password</param>
        public void ChangePassword(Member member, string password)
        {
            member.Password = password;

            this.SaveMember(member);
        }

        /// <summary>
        /// Saves the member back to the database
        /// </summary>
        /// <param name="member">The member to save</param>
        /// <param name="transactionManager">a transaction manager to commit the save to the database</param>
        public void SaveMember(Member member)
        {
            try
            {
                this._transactionManager.BeginTransaction();

                if (!member.Websites.ToList().Exists(o => o.Id == this._website.Id))
                {
                    member.Websites.Add(this._website);
                }
                
                this._memberDao.SaveOrUpdate(member);

                this._transactionManager.CommitTransaction();
            }
            catch (Exception e)
            {
                if (this._transactionManager.IsInTransaction())
                {
                    this._transactionManager.RollbackTransaction();
                }

                // Add additional data about the member to a new exception
                ApplicationException exception = new ApplicationException("Probelm saving member", e);
                exception.Data.Add("Member Id", member.Id);

                throw exception;
            }
        }
    }
}
