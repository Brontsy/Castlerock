using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Web.Controllers;
using Portal.Websites.Interfaces;
using Portal.Web.Models;
using Castlerock.Properties;
using Castlerock.Properties.Models;
using Castlerock.Properties.Interfaces;
using Portal.Web.Areas.PropertyEditor;
using Portal.Web.Areas.PropertyEditor.Models;
using Portal.Web.Areas.PropertyEditor.Extensions;
using Portal.Web.Attributes;
using Common.Exceptions;
using Microsoft.WindowsAzure.StorageClient;
using Portal.Images;
using Portal.Images.Models;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Portal.Web.Areas.PropertyEditor.Controllers
{
    [AdministratorFilter]
    public class PropertiesController : PortalBaseController
    {
        private IPropertyService _propertyService = null;
        private IExceptionManager _exceptionManager = null;
        private IImageService _imageService = null;

        public PropertiesController(IWebsite website, IPropertyService propertyService, IImageService imageService, IExceptionManager exceptionManager)
            : base(website)
        {
            this._propertyService = propertyService;
            this._imageService = imageService;
        }

        public ActionResult Index()
        {
            IList<IProperty> properties = this._propertyService.GetProperties();
            return View(new PropertiesPageViewModel(this.Website, properties));
        }

        [ImportModelStateFromTempData]
        public ActionResult Edit(int propertyId)
        {
            IProperty property = this._propertyService.GetPropertyById(propertyId);

            return View(new PropertiesPageViewModel(this.Website, property));
        }

        public ActionResult Blobs()
        {
            MyBlobStorageService _myBlobStorageService = new MyBlobStorageService();

            // Retrieve a reference to a container 
            CloudBlobContainer blobContainer = _myBlobStorageService.GetCloudBlobContainer();

            List<string> blobs = new List<string>();

            // Loop over blobs within the container and output the URI to each of them
            foreach (var blobItem in blobContainer.ListBlobs())
            {
                blobs.Add(blobItem.Uri.ToString());
            }

            return View(blobs);
        }

        private T Deserialise<T>(string json)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serialiser = new DataContractJsonSerializer(typeof(T));
                return (T)serialiser.ReadObject(ms);
            }
        }

        [ExportModelStateToTempData]
        public ActionResult Save(PropertyViewModel propertyViewModel, int propertyId, string imageIds)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    IProperty property = this._propertyService.GetPropertyById(propertyId);

                    // Copy the properties from the view model to our member object
                    property = propertyViewModel.ToProperty(property as Property);

                    // convert the json string into a list of image ids
                    List<int> ids = this.Deserialise<List<int>>(imageIds);
                    foreach (int imageId in ids)
                    {
                        property.ImageIds.Add(imageId);
                    }

                    // Save the property back to the database
                    //this._propertyService.SaveProperty(property);

                    this.ConfirmationMessage = "Property was saved.";

                    return this.RedirectToRoute(PropertyEditorAreaRegistration.ViewAll);
                }
                catch (Exception exception)
                {
                    exception.Data.Add("Property Id", propertyId);
                    exception.Data.Add("Name", propertyViewModel.Name);
                    this._exceptionManager.LogException(exception, "Unable to save Member");

                    this.ErrorMessage = "There was a problem saving. Please try again";
                }
            }

            if (propertyId == 0)
            {
                return this.RedirectToRoute(PropertyEditorAreaRegistration.New);
            }

            // If there was a problem then return the edit view
            return this.RedirectToRoute(PropertyEditorAreaRegistration.Edit);
        }
    }
}
