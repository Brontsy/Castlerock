using System;
using System.Collections.Generic;
using System.Text;
using Portal.Cms.Models;
using Portal.Websites.Interfaces;

namespace Portal.Cms.Interfaces
{
    public interface ITemplateDao : Common.Nhibernate.IBaseDao<Template, int>
    {
        
        /// <summary>
        /// Gets all the templates
        /// </summary>
        /// <returns></returns>
        IList<Template> GetTemplates(IWebsite website);
    }
}


