using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Membership.Models
{
    [PetaPoco.TableName("Membership.Profiles")]
    public class Profile
    {
        private int _id;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;
        private string _company = string.Empty;
        private string _phone = string.Empty;
        private DateTime _dateCreated = DateTime.Now;

        private IList<Member> _members = null;

        public virtual int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public virtual string FirstName
        {
            get { return this._firstName; }
            set { this._firstName = value; }
        }

        public virtual string LastName
        {
            get { return this._lastName; }
            set { this._lastName = value; }
        }

        public virtual string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public virtual string Company
        {
            get { return this._company; }
            set { this._company = value; }
        }

        public virtual string Phone
        {
            get { return this._phone; }
            set { this._phone = value; }
        }

        public virtual DateTime DateCreated
        {
            get { return this._dateCreated; }
            set { this._dateCreated = value; }
        }

        public virtual IList<Member> Members
        {
            get { return this._members; }
            set { this._members = value; }
        }
    }
}
