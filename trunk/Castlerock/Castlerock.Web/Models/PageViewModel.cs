using System;
using System.Collections.Generic;
using System.Web;

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

        /// <summary>
        /// Is the member logged in or not
        /// </summary>
        public bool IsLoggedIn
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }

    }
}
