using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Websites.Models;
using Portal.Websites.Interfaces;
using NHibernate;

namespace Portal.Websites.Daos
{
    public class WebsiteNhibernateDao : Common.Nhibernate.AbstractNHibernateDao<Website, int>, IWebsiteDao
    {
        public WebsiteNhibernateDao(ISession session)
            : base(session)
        {
        }

        public IWebsite GetWebsiteByHostUrl(string hostUrl)
        {
            IQuery query = this.Session.CreateQuery("From Website Where Host = :hostUrl");
            query.SetParameter("hostUrl", hostUrl);

            return query.UniqueResult<Website>();
        }
    }
}
