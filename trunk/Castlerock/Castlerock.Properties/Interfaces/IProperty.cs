using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castlerock.Properties.Enums;
using Portal.Images.Models;

namespace Castlerock.Properties.Interfaces
{
    public interface IProperty
    {
        /// <summary>
        /// The id of this property
        /// </summary>
        int PropertyId { get; }

        /// <summary>
        /// The name of the property
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The address of the property
        /// </summary>
        string Address { get; }

        /// <summary>
        /// The town the property is in
        /// </summary>
        string Town { get; }

        /// <summary>
        /// The state the property is in
        /// </summary>
        State State { get; }

        /// <summary>
        /// The tenant this currently is using hte property
        /// </summary>
        string Tenant { get; }

        /// <summary>
        /// The department of the tenant that is using the property
        /// </summary>
        string Department { get; }

        /// <summary>
        /// The floor area in sqm
        /// TODO: Make this an int
        /// </summary>
        string FloorArea { get; }

        /// <summary>
        /// When the leased commenced
        /// </summary>
        DateTime? LeaseCommenced { get; }

        /// <summary>
        /// When the expected completion date of the property is
        /// </summary>
        DateTime? ExpectedCompletionDate { get; }

        /// <summary>
        /// The energy rating for the property
        /// </summary>
        string EnergyRating { get; }

        /// <summary>
        /// Has the property / project been completed
        /// </summary>
        bool IsComplete { get; }

        /// <summary>
        /// The folder where the image are located for this property
        /// </summary>
        string ImageFolder { get; }

        /// <summary>
        /// Is the property currently managed by castlerock or not
        /// </summary>
        bool IsManaged { get; }

        /// <summary>
        /// The url needed to navigate to this property
        /// </summary>
        string NavigationUrl { get; }

        /// <summary>
        /// Gets a list of image ids this property has
        /// </summary>
        IList<int> ImageIds { get; }
    }
}
