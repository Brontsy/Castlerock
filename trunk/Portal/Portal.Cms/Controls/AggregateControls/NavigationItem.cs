using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Portal.Cms.Extensions;
using Portal.Cms.Interfaces;
using Portal.Cms.Parameters;

namespace Portal.Cms.Controls
{
    public class NavigationItem : AggregateControl, IAggregateControl
    {
        public NavigationItem() { }

        /// <summary>
        /// Gets and sets the url for this navigation item
        /// </summary>
        public virtual string Url
        {
            get { return this.HtmlProperties.Get<string>("url"); }
            set { this.HtmlProperties["url"] = value; }
        }
    }
}
