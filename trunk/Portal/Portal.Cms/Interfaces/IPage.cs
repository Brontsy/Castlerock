using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Cms.Pages;
using Portal.Cms.Models;
using Portal.Interfaces.Cms;

namespace Portal.Cms.Interfaces
{
    public interface IPage
    {
        /// <summary>
        /// Gest the Id of the page
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets and sets the name of the page
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the key for this page to be used in the url
        /// /Page/{key}/{pageId}
        /// </summary>
        string Key { get; }
        
        /// <summary>
        /// Gets and sets the matching url for this page
        /// </summary>
        string Url { get; }

        /// <summary>
        /// Gets all the controls for this page
        /// </summary>
        IList<IControl> Controls { get; }

        /// <summary>
        /// Gets the template for this page
        /// </summary>
        Template Template { get; }



        //IControl GetParent(IControl control);
        //void UpdateControl(IControl control);
        //IControl GetControl(Guid controlId);
        //void DeleteControl(Guid controlId);
        //void AddControl(Guid? guid, IControl control);
    }
}
