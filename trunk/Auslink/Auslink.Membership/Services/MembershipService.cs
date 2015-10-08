using Auslink.Membership.Encryption;
using Auslink.Membership.Models;
using Auslink.Membership.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.Membership.Services
{
    public interface IMembershipService
    {
        bool Authenticate(string username, string password);

        Member GetMemberByUsername(string username);

        Member GetMemberById(int memberId);
        
        IList<Member> GetMembers();

        void SaveMember(Member member);
    }

    internal class MembershipService : IMembershipService
    {
        private IMembershipRepository _memberRepository;

        public MembershipService(IMembershipRepository memberRepository)
        {
            this._memberRepository = memberRepository;
        }

        public IList<Member> GetMembers()
        {
            return this._memberRepository.GetMembers();
        }

        public bool Authenticate(string username, string password)
        {
            try
            {
                Member member = this._memberRepository.GetMemberByUsername(username);

                string encryptedPassword = SimpleHash.ComputeHash(password, "MD5");

                if (member != null && SimpleHash.VerifyHash(password, "MD5", member.Password))
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


        public Member GetMemberByUsername(string username)
        {
            return this._memberRepository.GetMemberByUsername(username);
        }

        public Member GetMemberById(int memberId)
        {
            return this._memberRepository.GetMemberById(memberId);
        }


        public void SaveMember(Member member)
        {
            
        }
    }
}
