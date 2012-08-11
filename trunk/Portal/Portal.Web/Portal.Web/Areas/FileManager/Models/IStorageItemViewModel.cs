using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Web.Areas.FileManager.Models
{
    public interface IStorageItemViewModel
    {
        /// <summary>
        /// Gets the name of the view to render this storage item
        /// </summary>
        string View { get; }
    }
}
