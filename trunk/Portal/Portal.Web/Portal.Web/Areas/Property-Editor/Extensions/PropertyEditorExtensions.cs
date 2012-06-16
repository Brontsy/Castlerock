using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castlerock.Properties.Models;
using Portal.Web.Areas.PropertyEditor.Models;
using Castlerock.Properties.Interfaces;

namespace Portal.Web.Areas.PropertyEditor.Extensions
{
    public static class PropertyEditorExtensions
    {
        /// <summary>
        /// Converts a IProperty into a property view model
        /// </summary>
        public static PropertyViewModel ToViewModel(this IProperty property)
        {
            return new PropertyViewModel(property);
        }

        /// <summary>
        /// Converts a member view model back into a member object.
        /// </summary>
        /// <param name="member">the member object to copy the properties into</param>
        /// <returns>the member object with its properties updated</returns>
        public static Property ToProperty(this PropertyViewModel viewModel, Property property)
        {
            property.Name = viewModel.Name;
            property.Address = viewModel.Address;
            property.Town = viewModel.Town;
            property.State = viewModel.State;
            property.Tenant = viewModel.Tenant;
            property.Department = viewModel.Department;
            property.FloorArea = viewModel.FloorArea;
            property.LeaseCommenced = viewModel.LeaseCommenced;
            property.ExpectedCompletionDate = viewModel.ExpectedCompletionDate;
            property.EnergyRating = viewModel.EnergyRating;
            property.IsComplete = viewModel.IsComplete;
            property.IsManaged = viewModel.IsManaged;

            return property;
        }
    }
}