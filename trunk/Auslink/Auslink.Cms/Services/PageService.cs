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

        void SavePageContent(PageContent content);

        void PublishPageContent(Guid pageId, Guid contentId);
    }

    internal class PageService : IPageService
    {
        private IPageRepository _repository;

        public PageService(IPageRepository repository)
        {
            this._repository = repository;
        }

        public Page GetPageById(Guid pageId)
        {
            return this._repository.GetPageById(pageId);
        }


        public void SavePageContent(PageContent content)
        {
            this._repository.SavePageContent(content);
        }


        public void PublishPageContent(Guid pageId, Guid contentId)
        {
            Page page = this._repository.GetPageById(pageId);

            foreach(PageContent content in page.Content)
            {
                content.IsPublished = (contentId == content.ContentId);
                this._repository.SavePageContent(content);
            }
        }
    }
}
