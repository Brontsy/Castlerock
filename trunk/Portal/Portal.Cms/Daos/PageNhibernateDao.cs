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
        public IPage GetPageByName(IWebsite website, string name)
        {
            IQuery query = this.Session.CreateQuery("From Page Where Name = :name And Website.Id = :websiteId");
            query.SetParameter("name", name);
            query.SetParameter("websiteId", website.Id);

            query.SetCacheRegion("Cms");
            query.SetCacheable(true);

            return query.UniqueResult<IPage>();
        }


        /// <summary>
        /// Gets all the pages that have that control on it
        /// </summary>
        /// <param name="controlId">the id of the control to search the pages for</param>
        /// <returns></returns>
        public IList<IPage> GetPagesWithControl(IWebsite website, Guid controlId)
        {
            IQuery query = this.Session.CreateSQLQuery("Select PageId From Cms.PageControls pc Where pc.ControlId = :controlId");

            //IQuery query = this.Session.CreateSQLQuery("Select p.* From Cms.Pages p Inner Join Cms.PageControls pc On p.PageId = pc.PageId Where pc.ControlId = :controlId And p.WebsiteId = :websiteId");
            //IQuery query = this.Session.CreateQuery("From Page Where ControlIds  = :name And Website.Id = :websiteId");
            query.SetParameter("controlId", controlId);
            //query.SetParameter("websiteId", website.Id);

            IList<int> pageIds = query.List<int>();

            IList<IPage> pages = new List<IPage>();

            foreach (int pageId in pageIds)
            {
                pages.Add(this.GetById(pageId));
            }

            return pages;
        }

    }
}
