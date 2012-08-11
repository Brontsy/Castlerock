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
        IPage GetPageByName(IWebsite website, string name);


        /// <summary>
        /// Gets all the pages that have that control on it
        /// </summary>
        /// <param name="controlId">the id of the control to search the pages for</param>
        /// <returns></returns>
        IList<IPage> GetPagesWithControl(IWebsite website, Guid controlId);
    }
}
