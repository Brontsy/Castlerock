using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castlerock.Properties.Models;
using Castlerock.Properties.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Castlerock.Properties.Enums;
using Portal.Web.Models;
using Common.Extensions;

namespace Portal.Web.Areas.PropertyEditor.Models
{
    public class PropertyViewModel
    {
        private IProperty _property = null;

        public PropertyViewModel() { }

        public PropertyViewModel(IProperty property)
        {
            this._property = property;

            // TODO: Is there a better way to do this? Maybe inside the extension class?
            this.Id = property.PropertyId;
            this.Name = property.Name;
            this.Address = property.Address;
            this.Town = property.Town;
            this.State = property.State;
            this.Tenant = property.Tenant;
            this.Department = property.Department;
            this.FloorArea = property.FloorArea;
            this.LeaseCommenced = property.LeaseCommenced;
            this.ExpectedCompletionDate = property.ExpectedCompletionDate;
            this.IsComplete = property.IsComplete;
            this.IsManaged = property.IsManaged;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "* Please enter a name")]
        [DisplayName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The address of the property
        /// </summary>
        [Required(ErrorMessage = "* Please enter a Address")]
        [DisplayName("Address")]
        public string Address { get; set; }

        /// <summary>
        /// The town the property is in
        /// </summary>
        [Required(ErrorMessage = "* Please enter a Town")]
        [DisplayName("Town")]
        public string Town { get; set; }

        /// <summary>
        /// The state the property is in
        /// </summary>
        [Required(ErrorMessage = "* Please enter a State")]
        [DisplayName("State")]
        public State State { get; set; }

        /// <summary>
        /// The tenant this currently is using hte property
        /// </summary>
        [DisplayName("Tenant")]
        public string Tenant { get; set; }

        /// <summary>
        /// The department of the tenant that is using the property
        /// </summary>
        [DisplayName("Department")]
        public string Department { get; set; }

        /// <summary>
        /// The floor area in sqm
        /// TODO: Make this an int
        /// </summary>
        [DisplayName("Floor Area")]
        public string FloorArea { get; set; }

        /// <summary>
        /// When the leased commenced
        /// </summary>
        [DisplayName("Lease Commenced")]
        public DateTime? LeaseCommenced { get; set; }

        /// <summary>
        /// When the expected completion date of the property is
        /// </summary>
        [DisplayName("Expected Completion Date")]
        public DateTime? ExpectedCompletionDate { get; set; }

        /// <summary>
        /// The energy rating for the property
        /// </summary>
        [DisplayName("Energy Rating")]
        public string EnergyRating { get; set; }

        /// <summary>
        /// Has the property / project been completed
        /// </summary>
        [DisplayName("Is Complete")]
        public bool IsComplete { get; set; }

        /// <summary>
        /// Is the property currently managed by castlerock or not
        /// </summary>
        [DisplayName("Is Managed")]
        public bool IsManaged { get; set; }

        /// <summary>
        /// Gets the folder that the image lives in
        /// TODO: Fix so its a list of file names / ids
        /// </summary>
        public string ImageFolder
        {
            get { return this._property.ImageFolder; }
        }

        public ImageUploadViewModel ImageUpload
        {
            get
            {
                return new ImageUploadViewModel()
                {
                    ImagePath = string.Format("properties/{0}/", this.Name.ToUrl())
                };
            }
        }
    }
}