using Auslink.Cms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Auslink.Web.New.Areas.Admin.Models.Cms
{
    public class PageContentViewModel
    {
        public Guid ContentId { get; set; }

        public Guid PageId { get; set; }

        [Required]
        [AllowHtml]
        public string Html { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsPublished { get; set; }

        public int Version { get; set; }

        public string LastEditedBy { get; set; }

        public PageContentViewModel() { }

        public PageContentViewModel(PageContent content)
        {
            this.ContentId = content.ContentId;
            this.PageId = content.PageId;
            this.Html = content.Html;
            this.DateCreated = content.DateCreated;
            this.Version = content.Version;
            this.IsPublished = content.IsPublished;
            this.LastEditedBy = content.LastEditedBy;
        }
    }
}
