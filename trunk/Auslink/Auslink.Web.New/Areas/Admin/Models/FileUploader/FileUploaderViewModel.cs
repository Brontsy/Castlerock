using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.Web.New.Areas.Admin.Models.FileUploader
{
    public class FileUploaderViewModel
    {
        public int MaxFiles { get; set; }

        public string FieldName { get; set; }

        public string Path { get; set; }

        public string Description { get; set; }

        public FileUploaderViewModel(int maxFiles, string fieldName, string description, string path)
        {
            this.MaxFiles = maxFiles;
            this.FieldName = fieldName;
            this.Description = description;
            this.Path = path;
        }
    }
}
