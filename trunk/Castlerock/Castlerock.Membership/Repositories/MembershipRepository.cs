using Castlerock.Membership.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castlerock.Membership.Repositories
{
    internal interface IMembershipRepository
    {
        Member GetMemberByUsername(string username);

        Member GetMemberById(int memberId);

        IList<Member> GetMembers();
    }

    internal class MembershipRepository : IMembershipRepository
    {
        private string _connectionString;

        private string _properties = "*";

        public MembershipRepository()
        {
            this._connectionString = ConfigurationManager.ConnectionStrings["Castlerock"].ToString();
        }

        public IList<Member> GetMembers()
        {
            string sql = @"Select " + _properties + @" From Membership.Members
                            Inner Join Membership.MemberWebsites On Membership.Members.MemberId = Membership.MemberWebsites.MemberId
                            Inner Join Websites On Websites.WebsiteId = Membership.MemberWebsites.WebsiteId
                            Inner Join Membership.Profiles On Membership.Profiles.ProfileId = Membership.Members.ProfileId
                            Where Websites.Host = 'castlerockproperty.com.au'";


            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                IList<Member> members = connection.Query<Member>(sql, new { }).ToList();

                foreach(Member member in members)
                {
                    member.Roles = this.GetMemberRoles(member.MemberId);
                }

                return members;
            }
        }

        public Member GetMemberById(int memberId)
        {
            string sql = @"Select " + _properties + @" From Membership.Members
                            Inner Join Membership.MemberWebsites On Membership.Members.MemberId = Membership.MemberWebsites.MemberId
                            Inner Join Websites On Websites.WebsiteId = Membership.MemberWebsites.WebsiteId
                            Inner Join Membership.Profiles On Membership.Profiles.ProfileId = Membership.Members.ProfileId
                            Where Membership.Members.MemberId = @MemberId And Websites.Host = 'castlerockproperty.com.au'";

            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                Member member = connection.Query<Member>(sql, new { MemberId = memberId }).FirstOrDefault();
                member.Roles = this.GetMemberRoles(member.MemberId);

                return member;
            }
        }

        public Member GetMemberByUsername(string username)
        {
            string sql = @"Select " + _properties + @" From Membership.Members
                            Inner Join Membership.MemberWebsites On Membership.Members.MemberId = Membership.MemberWebsites.MemberId
                            Inner Join Websites On Websites.WebsiteId = Membership.MemberWebsites.WebsiteId
                            Inner Join Membership.Profiles On Membership.Profiles.ProfileId = Membership.Members.ProfileId
                            Where Membership.Members.Username = @Username And Websites.Host = 'castlerockproperty.com.au'";

            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                Member member = connection.Query<Member>(sql, new { Username = username }).FirstOrDefault();
                member.Roles = this.GetMemberRoles(member.MemberId);

                return member;
            }
        }

        private IList<Role> GetMemberRoles(int memberId)
        {
            IList<Role> roles = new List<Role>();

            string sql = @"Select Membership.Roles.Name From Membership.MemberRoles 
Inner Join Membership.Roles ON Membership.MemberRoles.RoleId = Membership.Roles.RoleId 
Inner Join Websites ON Membership.Roles.WebsiteId = Membership.Roles.WebsiteId 
Where Membership.MemberRoles.MemberId = @MemberId And Websites.Host = 'castlerockproperty.com.au'";

            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                var dynamicRoles = connection.Query<dynamic>(sql, new { MemberId = memberId });

                foreach (var role in dynamicRoles)
                {
                    roles.Add((Role)Enum.Parse(typeof(Role), role.Name.ToString()));
                }
            }

            return roles;
        }
    }
}
