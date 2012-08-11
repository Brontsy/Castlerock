using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Portal.Cms.Extensions;
using Portal.Cms.Interfaces;
using Portal.Cms.Parameters;
using Portal.Events;
using Portal.Events.Interfaces;

namespace Portal.Cms.Controls
{
    public class NavigationItem : Control, IAggregateControl
    {
        private string _name = "Navigation Item";
        private string _url;

        private IPage _page = null;
        private IList<IPage> _pages = null;

        public NavigationItem() { }

        /// <summary>
        /// Gets and sets the url for this navigation item
        /// </summary>
        [Required(ErrorMessage = "* Please enter the url for this navigation item")]
        [DisplayName("Url")]
        public virtual string Url
        {
            get
            {
                if (string.IsNullOrEmpty(this._url) && this.Page != null)
                {
                    this._url = this.Page.Url;
                }

                return this._url;
            }
            set { this._url = value; }
        }

        /// <summary>
        /// Returns the name of this control
        /// </summary>
        [Required(ErrorMessage = "* Please give the link a name")]
        [DisplayName("Name")]
        public override string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// Returns the name of this control
        /// </summary>
        [DisplayName("Css Class")]
        public string CssClass
        {
            get;
            set;
        }

        [DisplayName("Page to Navigate to")]
        public int NavigationPageId { get; set; }

        [JsonIgnoreAttribute]
        public IList<IPage> Pages
        {
            get
            {
                if (this._pages == null)
                {
                    this._pages = Portal.Events.EventBroker.Instance.Request < IList<IPage>>(new Portal.Events.Events.PagesEvent() as Portal.Events.Interfaces.IEvent);
                }

                return this._pages;
            }
        }

        [JsonIgnoreAttribute]
        public IPage Page
        {
            get
            {
                if (this._page == null)
                {
                    this._page = Portal.Events.EventBroker.Instance.Request<IPage>(new Portal.Events.Events.PageEvent(this.NavigationPageId) as Portal.Events.Interfaces.IEvent);
                }

                return this._page;
            }
        }

        [JsonIgnoreAttribute]
        public override string View
        {
            get { return "Controls/AggregateControls/NavigationItem"; }
        }
    }
}
