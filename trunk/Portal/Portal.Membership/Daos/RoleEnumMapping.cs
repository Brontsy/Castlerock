using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Membership.Enums;
using NHibernate.Type;

namespace Portal.Membership.Daos
{
    public class RoleEnumMapping : EnumCharType<RoleType>
    {
        public RoleEnumMapping()
            : base()
        {
        }
    }
}
