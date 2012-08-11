using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Common.Nhibernate;
using Portal.Cms.Controls;
using Portal.Cms.Interfaces;
using Portal.Cms.Pages;
using Portal.Websites.Interfaces;

using Newtonsoft.Json;
using Portal.Cms.Models;
using System.Text.RegularExpressions;
using Portal.Messaging;
using Portal.Messaging.Interfaces;
using Portal.Cms.Extensions;
using Portal.Messaging.Enums;
using Portal.Events;
using Portal.Interfaces.Cms;
using Portal.Events.Interfaces;
using Portal.Events.Events;

namespace Portal.Cms
{
    public class CmsService : ICmsService, IEventSubscriber
    {
        private IPageDao _pageDao;
        private IControlDao _controlDao;
        private ITemplateDao _templateDao;
        private IWebsite _website;
        private ITransactionManager _transactionManager;
        private IMessageService _messageService;

        private IList<IPage> _pages = null;

        public CmsService(IPageDao pageDo, IControlDao controlDao, IWebsite website, ITransactionManager transactionManager, ITemplateDao templateDao, IMessageService messageService)
        {
            this._pageDao = pageDo;
            this._controlDao = controlDao;
            this._templateDao = templateDao;
            this._website = website;
            this._transactionManager = transactionManager;
            this._messageService = messageService;
        }

        /// <summary>
        /// Get all the pages from the database
        /// </summary>
        public IList<IPage> GetPages()
        {
            // Only load the page once!
            if (this._pages == null)
            {
                this._pages = this._pageDao.GetPagesForWebsite(this._website);
            } 

            return this._pages;
        }

        /// <summary>
        /// Get a specific page by its id
        /// </summary>
        /// <param name="pageId">the id of the page to load</param>
        public IPage GetPageById(int pageId)
        {
            return this._pageDao.GetById(pageId);
        }

        /// <summary>
        /// Gets a sepcific page by its name
        /// </summary>
        /// <param name="pageName">the name of the page to load</param>
        public IPage GetPageByName(string pageName)
        {
            return this._pageDao.GetPageByName(this._website, pageName);
        }

        /// <summary>
        /// Deletes a specific control from the page
        /// </summary>
        /// <param name="controlId">the id of the control to delete</param>
        public void DeleteControl(int pageId, Guid controlId)
        {
            IPage page = this.GetPageById(pageId);

            IControl control = page.Controls.Child(controlId);

            page.Controls.Delete(control);

            // Add the parent control because this is the one we need to update on other pages
            this._messageService.AddMessage<IControl>(control, MessageAction.Delete);

            this.SavePage(page);
        }

        /// <summary>
        /// Adds a control that already exists on another page to the page that is passed in
        /// </summary>
        /// <param name="pageId">the id of the page to add the control to</param>
        /// <param name="controlId">the id of the control we are adding</param>
        /// <param name="parentControlId">the id of the parent control we might be adding it to (null if there is no parent)</param>
        /// <param name="location">the location on the page to add the control to</param>
        /// <returns></returns>
        public IControl AddExistingControl(int pageId, Guid controlId, Guid? parentControlId, string location)
        {
            IPage page = this.GetPageById(pageId);
            IControl existingControl = null;
            IList<IPage> pages = this._pageDao.GetPagesWithControl(this._website, controlId);

            foreach (IPage anotherPage in pages)
            {
                existingControl = page.Controls.Child(controlId);
            }

            if (existingControl != null)
            {
                page.Controls.Add(parentControlId, existingControl);
                this.SavePage(page);
            }

            return existingControl;
        }

        public IControl AddControl(int pageId, NameValueCollection parameters, Guid? parentControlId, IControl control, string location)
        {
            IPage page = this.GetPageById(pageId);

            control.Location = location;

            MessageAction action = MessageAction.Update;

            if (control.Id == new Guid())
            {
                control.Id = Guid.NewGuid();
                action = MessageAction.Insert;
            }

            // Add control
            page.Controls.Add(parentControlId, control);

            this.SavePage(page);

            // Add the parent control because this is the one we need to update on other pages
            this._messageService.AddMessage<IControl>(control, action);

            return control;
        }




        /// <summary>
        /// Saves a page back to the database
        /// </summary>
        /// <param name="pageId">the id of the page to save (null means its a new page)</param>
        /// <param name="name">the name of the page</param>
        /// <param name="templateId">the id of the template that this page will use</param>
        /// <returns></returns>
        public IPage SavePage(int? pageId, string name, string url, int templateId)
        {
            IPage page = new Page();

            if (pageId.HasValue)
            {
                page = this.GetPageById(pageId.Value);
            }

            (page as Page).Name = name;
            (page as Page).Url = url;
            (page as Page).Template = this.GetTemplateById(templateId);
            (page as Page).Website = this._website;

            return this.SavePage(page);
        }

        public IPage SavePage(IPage page)
        {
            try
            {
                var settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.Objects;

                ((Page)page).Content = JsonConvert.SerializeObject(page.Controls, Newtonsoft.Json.Formatting.Indented, settings);

                this._transactionManager.BeginTransaction();

                this._pageDao.SaveOrUpdate(page as Page);

                this._transactionManager.CommitTransaction();
            }
            catch (Exception e)
            {
                if (this._transactionManager.IsInTransaction())
                {
                    this._transactionManager.RollbackTransaction();
                }

                throw new ApplicationException(string.Format("Error trying to save page: {0}", page.Id), e);
            }

            return page;
        }







        /// <summary>
        /// Gets all the templates
        /// </summary>
        /// <returns></returns>
        public IList<Template> GetTemplates()
        {
            return this._templateDao.GetTemplates(this._website);
        }

        /// <summary>
        /// Gets a specific template by its id
        /// </summary>
        /// <param name="templateId">the id of the template to return</param>
        public Template GetTemplateById(int templateId)
        {
            return this._templateDao.GetById(templateId);
        }

        /// <summary>
        /// Saves the template + details to the database
        /// </summary>
        /// <param name="templateId">the id of the template to save</param>
        /// <param name="name">the name of the template</param>
        /// <param name="html">the html for the template</param>
        public Template SaveTemplate(int? templateId, string name, string html)
        {
            Template template = new Template();

            if (templateId.HasValue)
            {
                template = this.GetTemplateById(templateId.Value);
            }

            template.Name = name;
            template.Html = html;
            template.Website = this._website;

            Regex re = new Regex(@"\[location=""([a-z0-9\-]+)""\]");
            MatchCollection mc = re.Matches(template.Html);
            foreach (Match m in mc)
            {
                template.Locations.Add(m.Groups[1].Value);
            }

            template.LocationsJson = JsonConvert.SerializeObject(template.Locations, Newtonsoft.Json.Formatting.Indented);

            return this.SaveTemplate(template);
        }

        /// <summary>
        /// Saves the template back to the database
        /// </summary>
        /// <param name="template">the template to be saved</param>
        /// <returns></returns>
        public Template SaveTemplate(Template template)
        {
            try
            {
                this._transactionManager.BeginTransaction();

                this._templateDao.SaveOrUpdate(template);

                this._transactionManager.CommitTransaction();
            }
            catch (Exception e)
            {
                if (this._transactionManager.IsInTransaction())
                {
                    this._transactionManager.RollbackTransaction();
                }

                throw new ApplicationException(string.Format("Error trying to save template: {0}", template.Id), e);
            }

            return template;
        }





        public void ProcessControls()
        {
            IList<IMessage<IControl>> messages = this._messageService.GetMessages<IControl>(Subscription.Cms);

            foreach (IMessage<IControl> message in messages)
            {
                IList<IPage> pages = this._pageDao.GetPagesWithControl(this._website, message.Content.Id);

                foreach (IPage page in pages)
                {
                    if (message.Action == MessageAction.Insert)
                    {
                        IControl parent = page.Controls.Parent(message.Content);

                        // if the control has a parent on this page
                        if (parent != null)
                        {
                            IList<IPage> pagesWithParent = this._pageDao.GetPagesWithControl(this._website, parent.Id);

                            foreach (IPage pageWithParent in pagesWithParent.Where(o => o.Id != page.Id))
                            {
                                pageWithParent.Controls.Add(parent.Id, message.Content);

                                this.SavePage(pageWithParent);
                            }
                        }
                    }

                    if (message.Action == MessageAction.Update)
                    {
                        page.Controls.Update(message.Content);

                        this.SavePage(page);
                    }

                    if (message.Action == MessageAction.Delete)
                    {
                        page.Controls.Delete(message.Content);

                        this.SavePage(page);
                    }
                }
            }

            this._messageService.Processed(messages);
        }

        #region IEventSubscriber Members

        public void Notify(IEvent e)
        {
            throw new NotImplementedException();
        }

        public T Request<T>(IEvent e)
        {
            if (e is PageEvent)
            {
                return (T)this.GetPageById((e as PageEvent).PageId);
            }

            return default(T);
        }

        #endregion
    }
}
