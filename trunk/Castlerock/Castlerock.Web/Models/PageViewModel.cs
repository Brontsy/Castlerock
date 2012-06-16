using System;
using System.Collections.Generic;

namespace Castlerock.Web.Models
{
    public class PageViewModel
    {

        public string Title { get; set; }

        public string View { get; set; }

        public string SelectedNavigation { get; set; }

        /// <summary>
        /// The model object that is going to be passed to the view
        /// </summary>
        public object Model { get; set; }
        
    }
}
