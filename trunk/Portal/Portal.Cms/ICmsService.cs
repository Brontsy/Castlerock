using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Common.Nhibernate;
using Portal.Cms.Interfaces;
using Portal.Websites.Interfaces;
using Portal.Cms.Models;
using Portal.Interfaces.Cms;

namespace Portal.Cms
{
    public interface ICmsService
    {
        /// <summary>
        /// Get all the pages from the database
        /// </summary>
        IList<IPage> GetPages();
      
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
        /// Saves a page back to the database
        /// </summary>
        /// <param name="pageId">the id of the page to save (null means its a new page)</param>
        /// <param name="name">the name of the page</param>
        /// <param name="templateId">the id of the template that this page will use</param>
        /// <returns></returns>
        IPage SavePage(int? pageId, string name, string url, int templateId);

        /// <summary>
        /// Adds a control that already exists on another page to the page that is passed in
        /// </summary>
        /// <param name="pageId">the id of the page to add the control to</param>
        /// <param name="controlId">the id of the control we are adding</param>
        /// <param name="parentControlId">the id of the parent control we might be adding it to (null if there is no parent)</param>
        /// <param name="location">the location on the page to add the control to</param>
        /// <returns></returns>
        IControl AddExistingControl(int pageId, Guid controlId, Guid? parentControlId, string location);

        IControl AddControl(int pageId, NameValueCollection parameters, Guid? parentControlId, IControl control, string location);

        /// <summary>
        /// Deletes a specific control from the page
        /// </summary>
        /// <param name="controlId">the id of the control to delete</param>
        void DeleteControl(int pageId, Guid controlId);


        /// <summary>
        /// Gets all the templates
        /// </summary>
        /// <returns></returns>
        IList<Template> GetTemplates();

        /// <summary>
        /// Gets a specific template by its id
        /// </summary>
        /// <param name="templateId">the id of the template to return</param>
        Template GetTemplateById(int templateId);
        
        /// <summary>
        /// Saves the template + details to the database
        /// </summary>
        /// <param name="templateId">the id of the template to save</param>
        /// <param name="name">the name of the template</param>
        /// <param name="html">the html for the template</param>
        Template SaveTemplate(int? templateId, string name, string html);



        void ProcessControls();
    }
}
