using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Interfaces.Cms;

namespace Portal.FileManager.Controls
{
    public class FileBrowser : IControl
    {
        private IList<IControl> _controls = new List<IControl>();

        public Guid Id { get; set; }

        public string Name
        {
            get { return "File Browser"; }
        }

        public int FolderId { get; set; }

        public string Location { get; set; }

        public string View
        {
            get { return "Controls/FileBrowser"; }
        }

        public int DisplayOrder { get; set; }

        public IList<IControl> Controls
        {
            get { return this._controls; }
            set { this._controls = value; }
        }
    }
}
