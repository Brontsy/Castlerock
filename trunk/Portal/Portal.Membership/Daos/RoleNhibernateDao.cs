using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Membership.Models;
using Portal.Membership.Interfaces;
using NHibernate;
using Portal.Websites.Interfaces;

namespace Portal.Membership.Daos
{
    public class RoleNhibernateDao : Common.Nhibernate.AbstractNHibernateDao<Role, int>, IRoleDao
    {
        public RoleNhibernateDao(ISession session)
            : base(session)
        {

        }

        public IList<Role> GetRoles(IWebsite website)
        {
            IQuery query = this.Session.CreateQuery("Select r From Role r Inner Join Fetch r.Website w  Where w.Id = :websiteId");

            query.SetParameter("websiteId", website.Id);

            return query.List<Role>();
        }
    }
}
