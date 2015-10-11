using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.Cms.Models
{
    public class Page
    {
        public int Id { get; set; }

        public Guid PageId { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public IList<PageContent> Content { get; set; }

        public Page()
        {
            this.Content = new List<PageContent>();
        }
    }
}
