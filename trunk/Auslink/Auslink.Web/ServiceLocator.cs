using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Membership;
using Portal.Membership.Daos;
using Portal.Membership.Interfaces;
using Common.Nhibernate;
using NHibernate;
using Portal.Websites;
using Portal.Websites.Daos;
using Portal.Websites.Interfaces;

namespace Auslink.Web
{
    public static class ServiceLocator
    {

        public static MembershipService GetMembershipService()
        {
            IMemberDao memberDao = new MemberNhibernateDao(GetCurrentSession());

            string host = HttpContext.Current.Request.Url.Host;
            IWebsite website = GetWebsiteService().GetWebsiteByHostUrl(host.Replace("www.", string.Empty).Replace("dev.", string.Empty));

            return new MembershipService(website, memberDao, GetTransactionManager());
        }

        public static ISession GetCurrentSession()
        {
            return NHibernateSessionPerRequest.GetCurrentSession();
        }

        public static ITransactionManager GetTransactionManager()
        {
            return new NhibernateTransactionManager(GetCurrentSession());
        }

        public static IWebsiteService GetWebsiteService()
        {
            return new WebsiteService(new WebsiteNhibernateDao(GetCurrentSession()));
        }
    }
}