using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Membership.Models;
using Portal.Websites.Interfaces;

namespace Portal.Membership.Interfaces
{
    public interface IRoleDao : Common.Nhibernate.IBaseDao<Role, int>
    {

        IList<Role> GetRoles(IWebsite website);
    }
}
