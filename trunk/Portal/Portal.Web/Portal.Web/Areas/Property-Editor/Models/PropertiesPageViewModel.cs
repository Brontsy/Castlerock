using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Web.Models;
using Portal.Websites.Interfaces;
using Castlerock.Properties.Models;
using Castlerock.Properties.Interfaces;

namespace Portal.Web.Areas.PropertyEditor.Models
{
    public class PropertiesPageViewModel : PageViewModel
    {
        public PropertiesPageViewModel(IWebsite website, IList<IProperty> properties)
            : base(website)
        {
            this.Properties = properties.Select(o => new PropertyViewModel(o)).ToList();
        }

        public PropertiesPageViewModel(IWebsite website, IProperty property)
            : base(website)
        {
            this.Property = new PropertyViewModel(property);
        }

        public IList<PropertyViewModel> Properties
        {
            get;
            private set;
        }

        public PropertyViewModel Property
        {
            get;
            private set;
        }
    }
}