using Castlerock.Membership.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castlerock.Membership.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name { get { return this.FirstName + " " + this.LastName;  } }

        public string Company { get; set; }

        public string Phone { get; set; }

        public string Password { get; internal set; }

        public string PasswordHashed { get; internal set; }

        public IList<Role> Roles { get; set; }
        

        public void UpdatePassword(string password)
        {
            //this.Password = password;
            this.Password = SimpleHash.ComputeHash(password, "MD5");
        }
    }
}
