using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castlerock.Properties;
using Castlerock.Properties.Interfaces;
using Castlerock.Properties.Models;
using Castlerock.Web.Models;
using Castlerock.Properties.Enums;

namespace Castlerock.Web.Controllers
{
    public class PropertiesController : CastlerockController
    {
        public ActionResult Index()
        {
            var model = new PageViewModel();
            model.View = "AustralianMap";
            model.Title = "Properties";
            model.SelectedNavigation = "Properties";
            model.Model = new PropertyPageViewModel();

            return View("StandardPageLayout", model);
        }

        public ActionResult State(State state)
        {
            PropertyPageViewModel propertyModel = new PropertyPageViewModel();

            var properties = ServiceLocator.GetPropertyService().GetProperties(state);

            propertyModel.CompleteProperties = properties.ToList().FindAll(o => o.IsComplete);
            propertyModel.InCompleteProperties = properties.ToList().FindAll(o => !o.IsComplete);
            propertyModel.State = state.ToString();

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("PropertiesInState", propertyModel);
            }

            var model = new PageViewModel();
            model.View = "AustralianMap";
            model.Title = "Properties";
            model.SelectedNavigation = "Properties";
            model.Model = propertyModel;

            return View("StandardPageLayout", model);
        }

        public ActionResult Show(int propertyId, string propertyName)
        {

            PropertyPageViewModel propertyModel = new PropertyPageViewModel();

            var property = ServiceLocator.GetPropertyService().GetPropertyById(propertyId);

            var properties = ServiceLocator.GetPropertyService().GetProperties(property.State);

            propertyModel.CompleteProperties = properties.ToList().FindAll(o => o.IsComplete);
            propertyModel.InCompleteProperties = properties.ToList().FindAll(o => !o.IsComplete);
            propertyModel.State = property.State.ToString();
            propertyModel.Property = property;

            var model = new PageViewModel();
            model.View = "Property";
            model.Title = "Properties";
            model.SelectedNavigation = "Properties";
            model.Model = propertyModel;

            return View("StandardPageLayout", model);
        }

    }
}
