using Auslink.Cms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.Web.New.Areas.Admin.Models.Cms
{
    public class EditPageViewModel
    {
        [Required]
        public Guid PageId { get; set; }

        [Required]
        public string Name { get; set; }

        public EditPageViewModel()
        {
            this.PageId = Guid.NewGuid();
        }

        public EditPageViewModel(Page page)
        {
            this.PageId = page.PageId;
            this.Name = page.Name;
        }
    }
}
