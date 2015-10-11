using Auslink.Cms.Models;
using Auslink.Cms.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.Cms.Services
{
    public interface IPageService
    {
        Page GetPageById(Guid pageId);

        Page GetPageByName(string name);

        void SavePageContent(PageContent content, string editedBy);

        void PublishPageContent(Guid pageId, Guid contentId, string publishedBy);
    }

    internal class PageService : IPageService
    {
        private IPageRepository _repository;

        public PageService(IPageRepository repository)
        {
            this._repository = repository;
        }

        public Page GetPageByName(string name)
        {
            return this._repository.GetPageByName(name);
        }

        public Page GetPageById(Guid pageId)
        {
            return this._repository.GetPageById(pageId);
        }


        public void SavePageContent(PageContent content, string lastEditedBy)
        {
            content.LastEditedBy = lastEditedBy;
            this._repository.SavePageContent(content);
        }


        public void PublishPageContent(Guid pageId, Guid contentId, string publishedBy)
        {
            Page page = this._repository.GetPageById(pageId);

            foreach(PageContent content in page.Content)
            {
                content.IsPublished = (contentId == content.ContentId);
                content.LastEditedBy = publishedBy;
                this._repository.SavePageContent(content);
            }
        }
    }
}
