using System;
using System.Collections.Generic;
using System.Text;
using Portal.Cms.Controls;

namespace Portal.Cms.Interfaces
{
    public interface IControlDao : Common.Nhibernate.IBaseDao<Control, int>
    {

        /// <summary>
        /// Gets all the controls for a specific page
        /// </summary>
        /// <param name="pageId">The id of the page to load all the controls for</param>
        /// <returns></returns>
        IList<IControl> GetControlsForPage(int pageId);
    }
}


