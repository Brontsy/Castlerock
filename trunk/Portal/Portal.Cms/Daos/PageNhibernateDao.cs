using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

using Portal.Cms.Interfaces;
using Portal.Cms.Pages;
using Portal.Websites.Interfaces;

namespace Portal.Cms.Persistence
{
    public class PageNhibernateDao : Common.Nhibernate.AbstractNHibernateDao<Page,int>, IPageDao
    {

        public PageNhibernateDao()
        {
        }

        public PageNhibernateDao(NHibernate.ISession session)
            : base(session)
        {
        }

        /// <summary>
        /// Gets a collection of all the pages for the website
        /// </summary>
        /// <returns></returns>
        public IList<IPage> GetPagesForWebsite(IWebsite website)
        {
            IQuery query = this.Session.CreateQuery("Select p From Page p Where p.Website.Id = :websiteId Order By p.Name");
            query.SetParameter("websiteId", website.Id);

            return query.List<IPage>();
        }

        /// <summary>
        /// Gets a specific page by its name
        /// </summary>
        /// <param name="name">the name of the page to return</param>
        /// <returns></returns>
        public IPage GetPageByName(string name)
        {
            IQuery query = this.Session.CreateQuery("From Page Where Name = :name");
            query.SetParameter("name", name);

            query.SetCacheRegion("Cms");
            query.SetCacheable(true);

            return query.UniqueResult<IPage>();
        }

    }
}
