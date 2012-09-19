using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Membership.Enums;
using Portal.Websites.Models;

namespace Portal.Membership.Models
{
    public class Role
    {
        private int _id;
        private string _name = string.Empty;
        private RoleType _type = RoleType.Member;
        private Website _website = null;
        private IList<Member> _members = null;

        [PetaPoco.Column("RoleId")]
        public virtual int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public virtual string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public virtual RoleType Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public virtual Website Website
        {
            get { return this._website; }
            set { this._website = value; }
        }

        public virtual IList<Member> Members
        {
            get { return this._members; }
            set { this._members = value; }
        }
    }
}
