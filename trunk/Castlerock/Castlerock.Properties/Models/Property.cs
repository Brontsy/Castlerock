using System;
using System.Collections.Generic;
using System.Text;
using Castlerock.Properties.Interfaces;
using Castlerock.Properties.Enums;

namespace Castlerock.Properties.Models
{
    public class Property : IProperty
    {
        private int _propertyId;
        private string _name;
        private string _address;
        private string _town;
        private State _state;
        private string _tenant;
        private string _department;
        private string _floorArea;
        private DateTime? _leaseCommenced;
        private DateTime? _expectedCompletionDate;
        private string _energyRating;
        private bool _isComplete = false;
        private string _imageFolder;
        private bool _isManaged = false;
        private IList<int> _imageIds = null;


        public Property()
        {

        }

        /// <summary>
        /// The id of this property
        /// </summary>
        public int PropertyId 
        {
            get { return _propertyId; }
            internal set { _propertyId = value; }
        }

        /// <summary>
        /// The name of the property
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// The address of the property
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// The town the property is in
        /// </summary>
        public string Town
        {
            get { return _town; }
            set { _town = value; }
        }

        /// <summary>
        /// The state the property is in
        /// </summary>
        public State State
        {
            get { return _state; }
            set { _state = value; }
        }


        /// <summary>
        /// The tenant this currently is using hte property
        /// </summary>
        public string Tenant
        {
            get { return _tenant; }
            set { _tenant = value; }
        }

        /// <summary>
        /// The department of the tenant that is using the property
        /// </summary>
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        /// <summary>
        /// The floor area in sqm
        /// TODO: Make this an int
        /// </summary>
        public string FloorArea
        {
            get { return _floorArea; }
            set { _floorArea = value; }
        }

        /// <summary>
        /// When the leased commenced
        /// </summary>
        public DateTime? LeaseCommenced
        {
            get { return _leaseCommenced; }
            set { _leaseCommenced = value; }
        }

        /// <summary>
        /// When the expected completion date of the property is
        /// </summary>
        public DateTime? ExpectedCompletionDate
        {
            get { return _expectedCompletionDate; }
            set { _expectedCompletionDate = value; }
        }
        
        /// <summary>
        /// The energy rating for the property
        /// </summary>
        public string EnergyRating
        {
            get { return _energyRating; }
            set { _energyRating = value; }
        }

        /// <summary>
        /// Has the property / project been completed
        /// </summary>
        public bool IsComplete
        {
            get { return _isComplete; }
            set { _isComplete = value; }
        }

        /// <summary>
        /// The folder where the image are located for this property
        /// </summary>
        public string ImageFolder
        {
            get { return _imageFolder; }
            internal set { _imageFolder = value; }
        }

        /// <summary>
        /// Is the property currently managed by castlerock or not
        /// </summary>
        public bool IsManaged
        {
            get { return this._isManaged; }
            set { _isManaged = value; }
        }

        /// <summary>
        /// The url needed to navigate to this property
        /// </summary>
        public string NavigationUrl
        {
            get
            {
                return string.Format("/Properties/Show/{0}/{1}", this.Name.Replace(" ", "-"), this.PropertyId);
            }
        }


        /// <summary>
        /// Gets a list of image ids this property has
        /// </summary>
        public IList<int> ImageIds
        {
            get 
            {
                if (this._imageIds == null)
                {
                    this._imageIds = new List<int>();
                }

                return this._imageIds; 
            }
        }
    }
}
