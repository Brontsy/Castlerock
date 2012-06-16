using System;
using System.Collections.Generic;
using System.Text;

using Portal.Cms.Pages;
using Portal.Websites.Interfaces;

namespace Portal.Cms.Interfaces
{
    public interface IPageDao : Common.Nhibernate.IBaseDao<Page, int>
    {
        /// <summary>
        /// Gets a collection of all the pages for the website
        /// </summary>
        /// <returns></returns>
        IList<IPage> GetPagesForWebsite(IWebsite website);

        /// <summary>
        /// Gets a specific page by its name
        /// </summary>
        /// <param name="name">the name of the page to return</param>
        /// <returns></returns>
        IPage GetPageByName(string name);
    }
}
