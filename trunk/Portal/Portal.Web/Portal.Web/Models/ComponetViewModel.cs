using Portal.Websites.Models;
using System.Web;
using System.Web.Mvc;

namespace Portal.Web.Models
{
    public class ComponentViewModel
    {
        private Component _component = null;

        public ComponentViewModel(Component component)
        {
            this._component = component;
        }

        /// <summary>
        /// Gets the name of this component
        /// </summary>
        public string Name
        {
            get { return this._component.Name; }
        }

        /// <summary>
        /// Gets the url of this component
        /// </summary>
        public string Url
        {
            get { return this._component.Url; }
        }

        public bool IsSelected
        {
            get 
            {
                if (HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"] != null)
                {
                    if (HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"].ToString() == this._component.Area)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}