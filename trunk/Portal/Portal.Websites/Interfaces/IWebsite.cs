using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Websites.Models;

namespace Portal.Websites.Interfaces
{
    public interface IWebsite
    {
        /// <summary>
        /// Gets the id of the website
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets the url for this websites logo
        /// </summary>
        string LogoImageUrl { get; }

        /// <summary>
        /// Gets the domain for this website
        /// eg. castlerockproeprty or auslikproperty
        /// </summary>
        string Domain { get; }

        
        /// <summary>
        /// Gets and sets the name of the website
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets and Sets a list of all the components this website has installed.
        /// Things like CMS, Membership Etc
        /// </summary>
        IList<Component> Components { get; }
    }
}
