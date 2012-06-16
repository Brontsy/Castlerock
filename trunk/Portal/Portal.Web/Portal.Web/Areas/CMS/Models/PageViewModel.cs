using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Cms.Interfaces;
using Common.Extensions;
using Portal.Web.Models;
using Portal.Websites.Interfaces;

namespace Portal.Web.Areas.CMS.Models
{
    public class PageViewModel
    {
        private IPage _page = null;
        private IList<IControl> _controls = null;

        public PageViewModel(IPage page)
        {
            this._page = page;
            this._controls = page.Controls;
        }

        /// <summary>
        /// Gets the id of this page
        /// </summary>
        public string Id
        {
            get { return this._page.Id.ToString(); }
        }

        /// <summary>
        /// Gets the name of the page
        /// </summary>
        public string Name
        {
            get { return this._page.Name; }
        }

        /// <summary>
        /// Gets a url friendly version of the name. Replaces the spaces with dashes etc
        /// </summary>
        public string NameUrlFriendly
        {
            get { return this._page.Name.ToUrl(); }
        }

        /// <summary>
        /// Gets all the child controls of this control
        /// </summary>
        public IList<IControl> Controls
        {
            get { return this._controls; }
        }

    }
}