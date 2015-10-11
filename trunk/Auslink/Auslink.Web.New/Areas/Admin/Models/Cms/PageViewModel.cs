using Auslink.Cms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.Web.New.Areas.Admin.Models.Cms
{
    public class PageViewModel
    {
        public int Id { get; set; }

        public Guid PageId { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public int Version { get; set; }

        public IList<PageContentViewModel> Content { get; set; }

        public PageViewModel(Page page)
        {
            this.Id = page.Id;
            this.PageId = page.PageId;
            this.Name = page.Name;
            this.DateCreated = page.DateCreated;
            this.DateLastUpdated = page.DateLastUpdated;
            this.Content = page.Content.Select(o => new PageContentViewModel(o)).ToList();
        }
    }
}
