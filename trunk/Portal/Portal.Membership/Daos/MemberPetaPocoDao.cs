using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Membership.Models;
using Portal.Membership.Interfaces;
using NHibernate;
using Portal.Websites.Interfaces;
using PetaPoco.Membership;

namespace Portal.Membership.Daos
{
    public class MemberPetaPocoDao :  IMemberDao
    {
        /// <summary>
        /// Gets a member from the database by there username
        /// </summary>
        /// <param name="email">the username to retrieve the member for</param>
        /// <returns>A Member object if one exists otherwise null</returns>
        public Member GetMemberByUsername(IWebsite website, string username)
        {

            var db = new PetaPoco.Membership.Database("Portal");

            IList<Member> members = db.Fetch<Member, Profile, Member>(new MemberProfileRelator().MapIt,
                                                        @"Select * From Membership.Members m
                                                        Inner Join Membership.MemberWebsites w On m.MemberId = w.MemberId
                                                        Inner Join Membership.Profiles p On m.ProfileId = p.ProfileId
                                                        Where p.Username = @Username And WebsiteId = @WebsiteId", new { WebsiteId = website.Id, Username = username });

            Member member = null;

            if (members.Count > 0)
            {
                member = members.First();
                member.Roles = db.Fetch<Role>("Select * From Membership.Roles r Inner Join Membership.MemberRoles mr On r.RoleId = mr.RoleId Where mr.MemberId = @MemberId", new { MemberId = member.Id });
            }

            return member;
        }



        /// <summary>
        /// Get a specific member by there email
        /// </summary>
        /// <param name="email">the email of the member to return</param>
        public Member GetMemberByEmail(IWebsite website, string email)
        {
            var db = new PetaPoco.Membership.Database("Portal");

            IList<Member> members = db.Fetch<Member, Profile, Member>(new MemberProfileRelator().MapIt,
                                                        @"Select * From Membership.Members m
                                                        Inner Join Membership.MemberWebsites w On m.MemberId = w.MemberId
                                                        Inner Join Membership.Profiles p On m.ProfileId = p.ProfileId
                                                        Where m.Email = @Email And WebsiteId = @WebsiteId", new { WebsiteId = website.Id, Email = email });

            Member member = null;

            if (members.Count > 0)
            {
                member = members.First();
                member.Roles = db.Fetch<Role>("Select * From Membership.Roles r Inner Join Membership.MemberRoles mr On r.RoleId = mr.RoleId Where mr.MemberId = @MemberId", new { MemberId = member.Id });
            }

            return member;
        }



        /// <summary>
        /// Gets all the members in the system
        /// </summary>
        public IList<Member> GetAllMembers(IWebsite website)
        {
            var db = new PetaPoco.Membership.Database("Portal");

            List<Member> members = db.Fetch<Member, Profile, Member>(new MemberProfileRelator().MapIt,
                                                        @"Select * From Membership.Members m
                                                        Inner Join Membership.MemberWebsites w On m.MemberId = w.MemberId
                                                        Inner Join Membership.Profiles p On m.ProfileId = p.ProfileId
                                                        Where WebsiteId = @WebsiteId Order By Username", new { WebsiteId = website.Id });

            return members;
        }

        /// <summary>
        /// Gets a specific member by there id
        /// </summary>
        /// <param name="website">the website this member should belong to</param>
        /// <param name="member">the id of the member</param>
        public Member GetMemberById(IWebsite website, int memberId)
        {
            var db = new PetaPoco.Membership.Database("Portal");

            var members = db.Fetch<Member, Profile, Member>(new MemberProfileRelator().MapIt,
                                                        @"Select * From Membership.Members m
                                                        Inner Join Membership.MemberWebsites w On m.MemberId = w.MemberId
                                                        Inner Join Membership.Profiles p On m.ProfileId = p.ProfileId
                                                        Where m.MemberId = @MemberId And WebsiteId = @WebsiteId", new { WebsiteId = website.Id, MemberId = memberId });

            Member member = null;

            if (members.Count > 0)
            {
                member = members.First();
                member.Roles = db.Fetch<Role>("Select * From Membership.Roles r Inner Join Membership.MemberRoles mr On r.RoleId = mr.RoleId Where mr.MemberId = @MemberId", new { MemberId = memberId });
            }

            return member;
        }

        #region IBaseDao<Member,int> Members

        public Member GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Member Save(Member member)
        {
            var db = new PetaPoco.Membership.Database("Portal");

            db.Insert("Membership.Members", "MemberId", true, member);

            return member;
        }

        public Member SaveOrUpdate(Member member)
        {
            var db = new PetaPoco.Membership.Database("Portal");

            if (member.Id == 0)
            {
                this.Save(member);
            }
            else
            {
                var memberObj = new { MemberId = member.Id, Email = member.Username, Password = member.PasswordHashed };
                db.Save("Membership.Members", "MemberId", memberObj);

                var profile = new
                {
                    FirstName = member.Profile.FirstName,
                    LastName = member.Profile.LastName,
                    Company = member.Profile.Company,
                    Username = member.Profile.Email,
                    Phone = member.Profile.Phone
                };

                db.Save("Membership.Profiles", "ProfileId", profile);

                var delete = new { MemberId = member.Id };

                db.Delete("Membership.MemberRoles", "MemberRoleId", delete);

                foreach (var role in member.Roles)
                {
                    var roleObj = new { RoleId = role.Id, MemberId = member.Id };
                    db.Save("Membership.MemberRoles", "MemberRoleId", roleObj);

                }


                //db.Save("Membership.Members", "Id", member);
            }

            return member;
        }

        public ISession Session
        {
            get { throw new NotImplementedException(); }
        }

        public void Delete(Member entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    class MemberProfileRelator
    {
        public Member MapIt(Member member, Profile profile)
        {
            member.Profile = profile;
            return member;
        }
    }
}
