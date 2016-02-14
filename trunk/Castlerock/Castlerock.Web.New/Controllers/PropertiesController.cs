using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castlerock.Properties;
using Castlerock.Properties.Interfaces;
using Castlerock.Properties.Models;
using Castlerock.Web.New.Models;
using Castlerock.Properties.Enums;

namespace Castlerock.Web.Controllers
{
    public class PropertiesController : Controller
    {
        private IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            this._propertyService = propertyService;
        }


        public ActionResult Index()
        {
            ViewBag.Title = "Properties";
            ViewBag.SelectedNavigation = "Properties";

            return View("Index", new PropertyPageViewModel());
        }

        public ActionResult State(State state)
        {
            PropertyPageViewModel propertyModel = new PropertyPageViewModel();

            var properties = this._propertyService.GetProperties(state);

            propertyModel.CompleteProperties = properties.ToList().FindAll(o => o.IsComplete);
            propertyModel.InCompleteProperties = properties.ToList().FindAll(o => !o.IsComplete);
            propertyModel.State = state.ToString();

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("PropertiesInState", propertyModel);
            }

            ViewBag.Title = "Properties";
            ViewBag.SelectedNavigation = "Properties";

            return View("State", propertyModel);
        }

        public ActionResult Show(int propertyId, string propertyName)
        {

            PropertyPageViewModel propertyModel = new PropertyPageViewModel();

            var property = this._propertyService.GetPropertyById(propertyId);

            var properties = this._propertyService.GetProperties(property.State);

            propertyModel.CompleteProperties = properties.ToList().FindAll(o => o.IsComplete);
            propertyModel.InCompleteProperties = properties.ToList().FindAll(o => !o.IsComplete);
            propertyModel.State = property.State.ToString();
            propertyModel.Property = property;

            ViewBag.Title = "Properties";
            ViewBag.SelectedNavigation = "Properties";

            return View("Show", propertyModel);
        }

    }
}
