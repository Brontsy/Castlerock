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

        IList<Page> GetPages();

        void SavePageContent(PageContent content, string editedBy);

        void PublishPageContent(Guid pageId, Guid contentId, string publishedBy);

        void SavePage(Guid pageId, string name, string lastEditedBy);
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

        public IList<Page> GetPages()
        {
            return this._repository.GetPages();
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

        public void SavePage(Guid pageId, string name, string lastEditedBy)
        {
            this._repository.SavePage(pageId, name, lastEditedBy);
        }
    }
}
