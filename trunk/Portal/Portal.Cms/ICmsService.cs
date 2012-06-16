using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Common.Nhibernate;
using Portal.Cms.Interfaces;
using Portal.Websites.Interfaces;

namespace Portal.Cms
{
    public interface ICmsService
    {
        /// <summary>
        /// Get all the pages from the database
        /// </summary>
        IList<IPage> GetPages(IWebsite website);
      
        /// <summary>
        /// Get a specific page by its id
        /// </summary>
        /// <param name="pageId">the id of the page to load</param>
        IPage GetPageById(int pageId);
       
        /// <summary>
        /// Gets a sepcific page by its name
        /// </summary>
        /// <param name="pageName">the name of the page to load</param>
        IPage GetPageByName(string pageName);

        /// <summary>
        /// Gets a specific control by its id
        /// </summary>
        /// <param name="controlId">the id of the control to load</param>
        /// <returns></returns>
        IControl GetControlById(int controlId);

        /// <summary>
        /// Adds a new control to a page
        /// </summary>
        /// <param name="pageId">the id of the page to add the control to</param>
        /// <param name="parentControl">the id of the control that should be its parent</param>
        /// <param name="assembly">the name of the assembly our control lives in</param>
        /// <param name="className">the name of the class to create our control from</param>
        /// <param name="parameters">the html form paramaters to populate the control</param>
        /// <param name="transactionManager"></param>
        IControl AddControl(int pageId, int? parentControl, string assembly, string className, NameValueCollection parameters, ITransactionManager transactionManager);
      
    }
}
