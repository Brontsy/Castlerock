using Auslink.Cms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.Web.New.Areas.Admin.Models.Cms
{
    public class EditPageContentViewModel
    {
        public PageViewModel Page { get; set; }

        public PageContentViewModel Content { get; set; }

        public EditPageContentViewModel(Page page, Guid contentId)
        {
            this.Page = new PageViewModel(page);
            this.Content = new PageContentViewModel(page.Content.First(o => o.ContentId == contentId));
        }
    }
}
