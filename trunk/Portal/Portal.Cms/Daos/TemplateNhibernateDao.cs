using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

using Portal.Cms.Interfaces;
using Portal.Cms.Models;
using Portal.Websites.Interfaces;

namespace Portal.Cms.Persistence
{
    public class TemplateNhibernateDao : Common.Nhibernate.AbstractNHibernateDao<Template, int>, ITemplateDao
    {
        public TemplateNhibernateDao(NHibernate.ISession session)
            : base(session)
        {
        }
        
        /// <summary>
        /// Gets all the templates
        /// </summary>
        /// <returns></returns>
        public IList<Template> GetTemplates(IWebsite website)
        {
            IQuery query = this.Session.CreateQuery("Select template From Template template Where template.Website.Id = :websiteId Order By template.Name");
            query.SetParameter("websiteId", website.Id);

            return query.List<Template>();
        }
    }
}
