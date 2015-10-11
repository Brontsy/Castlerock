using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.QuarterlyUpdates.Models
{
    public class QuarterlyUpdate
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string DownloadLink { get; set; }

        public int? Month { get; set; }

        public int? Year { get; set; }
    }
}
