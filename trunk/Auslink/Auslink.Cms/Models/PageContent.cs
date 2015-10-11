using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.Cms.Models
{
    public class PageContent
    {
        public Guid ContentId { get; set; }

        public Guid PageId { get; set; }

        public string Html { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsPublished { get; set; }

        public int Version { get; set; }

        public string LastEditedBy { get; set; }
    }
}
