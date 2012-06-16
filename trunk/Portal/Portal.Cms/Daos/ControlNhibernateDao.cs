using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

using Portal.Cms.Interfaces;
using Portal.Cms.Controls;

namespace Portal.Cms.Persistence
{
    public class ControlNhibernateDao : Common.Nhibernate.AbstractNHibernateDao<Control, int>, IControlDao
    {

        public ControlNhibernateDao()
        {

        }

        public ControlNhibernateDao(NHibernate.ISession session)
            : base(session)
        {
        }

        /// <summary>
        /// Gets all the controls for a specific page
        /// </summary>
        /// <param name="pageId">The id of the page to load all the controls for</param>
        /// <returns></returns>
        public IList<IControl> GetControlsForPage(int pageId)
        {
            IQuery query = this.Session.CreateQuery("From Controls Where PageId = :pageId");
            query.SetParameter("pageId", pageId);

            return query.List<IControl>();
        }
    }
}
