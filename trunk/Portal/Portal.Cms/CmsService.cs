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

namespace Portal.Cms
{
    public class CmsService : ICmsService
    {
        private IPageDao _pageDao;
        private IControlDao _controlDao;

        public CmsService(IPageDao pageDo, IControlDao controlDao)
        {
            this._pageDao = pageDo;
            this._controlDao = controlDao;
        }

        public IList<IPage> GetPages(IWebsite website)
        {
            return this._pageDao.GetPagesForWebsite(website);
        }

        public IPage GetPageById(int pageId)
        {
            return this._pageDao.GetById(pageId);
        }

        public IPage GetPageByName(string pageName)
        {
            return this._pageDao.GetPageByName(pageName);
        }

        public IControl GetControlById(int controlId)
        {
            return this._controlDao.GetById(controlId);
        }

        public IControl AddControl(int pageId, int? parentControlId, string assembly, string className, NameValueCollection parameters, ITransactionManager transactionManager)
        {
            // Load the control otherwise set it to null if we are adding a control to a specific location
            IControl control = null;
            if(parentControlId.HasValue) { control = this.GetControlById(parentControlId.Value); }
            IPage page = this.GetPageById(pageId);

            // Create a new instance of our new control
            Cms.Interfaces.IControl newControl = (Cms.Interfaces.IControl)Activator.CreateInstance(Type.GetType(className + ", " + assembly));

            newControl.DisplayOrder = 1;

            if (control != null)
            {
                newControl.ParentControl = control;

                if (control.Controls.Count > 1)
                {
                    newControl.DisplayOrder = control.Controls.Last().DisplayOrder + 1;
                }
            }
            else
            {
                newControl.DisplayOrder = page.Controls.ToList().Last().DisplayOrder + 1;
                    
                newControl.Pages.Add(page);
            }

            this.SaveControl(newControl, parameters, transactionManager);

            return newControl;
        }

        public bool SaveControl(IControl control, NameValueCollection parameters, ITransactionManager transactionManager)
        {
            if (control.Update(parameters))
            {
                return this.SaveControl(control, transactionManager);
            }

            return false;
        }

        public void SetPagesForControl(int controlId, int[] pageIds, ITransactionManager transactionManager)
        {
            IControl control = this.GetControlById(controlId);
            control.Pages = new List<IPage>();

            foreach (int pageId in pageIds)
            {
                if(!control.AlreadyExistsOnPage(pageId))
                {
                    control.Pages.Add(this.GetPageById(pageId));
                }
            }

            this.SaveControl(control, transactionManager);
        }

        public bool SaveControl(IControl control, ITransactionManager transactionManager)
        {
            try
            {
                transactionManager.BeginTransaction();

                this._controlDao.SaveOrUpdate(control as Control);

                transactionManager.CommitTransaction();

                return true;
            }
            catch (Exception e)
            {
                if (transactionManager.IsInTransaction())
                {
                    transactionManager.RollbackTransaction();
                }

                throw new ApplicationException(string.Format("Error trying to save control: {0}", control.Id), e);
            }
        }

        public bool SavePage(IPage page, ITransactionManager transactionManager)
        {
            try
            {
                transactionManager.BeginTransaction();

                this._pageDao.SaveOrUpdate(page as Page);

                transactionManager.CommitTransaction();

                return true;
            }
            catch (Exception e)
            {
                if (transactionManager.IsInTransaction())
                {
                    transactionManager.RollbackTransaction();
                }

                throw new ApplicationException(string.Format("Error trying to save page: {0}", page.Id), e);
            }
        }

        public bool RemoveControl(IControl control, ITransactionManager transactionManager)
        {
            try
            {
                transactionManager.BeginTransaction();

                if (control.ParentControl != null)
                {
                    control.ParentControl.Controls.Remove(control);
                    control.ParentControl = null;
                }

                control.Pages = null;

                this._controlDao.Delete(control as Control);

                transactionManager.CommitTransaction();

            }
            catch (Exception e)
            {
                if (transactionManager.IsInTransaction())
                {
                    transactionManager.RollbackTransaction();
                }

                throw new ApplicationException(string.Format("Error trying to remove control: {0}", control.Id), e);
            }

            return true;
        }
    }
}
