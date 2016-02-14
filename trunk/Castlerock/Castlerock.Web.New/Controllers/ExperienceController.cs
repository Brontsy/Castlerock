using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Castlerock.Properties.Interfaces;
using Castlerock.Web.New.Models;
using Castlerock.Properties.Enums;
using Castlerock.Properties;

namespace Castlerock.Web.New.Controllers
{
    public class ExperienceController : CastlerockController
    {
        private Dictionary<string, IList<IProperty>> _properties;
        private IPropertyService _propertyService;

        public ExperienceController(IPropertyService propertyService)
        {
            this._propertyService = propertyService;
        }

        public ActionResult Index()
        {
            var model = new PageViewModel();
            ViewBag.Title = "Experience";
            ViewBag.SelectedNavigation = "Experience";
            var viewModel = this.GetProperties(this._propertyService.GetManagedProperties());

            return View("Index", viewModel);
        }

        private Dictionary<string, IList<IProperty>> GetProperties(IList<IProperty> properties)
        {
            this._properties = new Dictionary<string, IList<IProperty>>();

            foreach (IProperty property in properties)
            {
                string state = property.State.GetDescription();
                if (this._properties.ContainsKey(state))
                {
                    this._properties[state].Add(property);
                }
                else
                {
                    this._properties.Add(state, new List<IProperty>() { property });
                }
            }

            return this._properties;
        }

        public string GetState(string state)
        {
            switch (state.ToUpper())
            {
                case "VIC":
                    return "Victoria";
                case "NSW":
                    return "New South Wales";
                case "QLD":
                    return "Queensland";
                case "SA":
                    return "South Australia";
                case "NT":
                    return "Northen Territory";
                case "WA":
                    return "Western Australia";
                case "TAS":
                    return "Tasmania";
                case "ACT":
                    return "ACT";
            }
            return "Victoria";
        }

    }
}
