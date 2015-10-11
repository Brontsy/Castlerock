using Auslink.FileManager.Models;
using Auslink.QuarterlyUpdates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Auslink.Web.New.Areas.Admin.Models.QuarterlyUpdates
{
    public class QuarterlyUpdateViewModel
    {
        public int QuarterlyUpdateId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string DownloadLink { get; set; }

        [Required]
        public int? Month { get; set; }

        [Required]
        public int? Year { get; set; }

        public string FileName { get; set; }

        public IList<SelectListItem> Months { get; set; }

        public IList<SelectListItem> Years { get; set; }

        public QuarterlyUpdateViewModel()
        {
            this.Months = new List<SelectListItem>();
            this.Years = new List<SelectListItem>();

            for (int i = DateTime.Now.Year; i > 2010; i--)
            {
                this.Years.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }

            for (int i = 1; i <= 12; i++)
            {
                this.Months.Add(new SelectListItem() { Text = this.GetMonthName(i), Value = i.ToString() });
            }
        }

        public QuarterlyUpdateViewModel(QuarterlyUpdate quarterlyUpdate)
         :   this()
        {
            this.QuarterlyUpdateId = quarterlyUpdate.Id;
            this.Text = quarterlyUpdate.Text;
            this.DownloadLink = quarterlyUpdate.DownloadLink;
            this.Month = quarterlyUpdate.Month;
            this.Year = quarterlyUpdate.Year;

            if(!string.IsNullOrEmpty(quarterlyUpdate.DownloadLink))
            {
                this.FileName = File.GetFileName(new Uri(quarterlyUpdate.DownloadLink));
            }
        }

        private string GetMonthName(int monthNumber)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber);
        }
    }
}
