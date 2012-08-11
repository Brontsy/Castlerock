using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Portal.Cms.Interfaces;
using Portal.Websites.Interfaces;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Portal.Cms.Controls;
using Portal.Cms.Models;
using Ninject;
using Portal.Interfaces.Cms;

namespace Portal.Cms.Pages
{
    public class Page : IPage
    {
        private int _id;
        private string _name;
        private string _url;
        private string _key;
        public string _content;

        private IWebsite _website = null;

        private IList<IControl> _controls = null;
        private Template _template;
        private IList<string> _controlIds = null;

        public IList<IControl> Controls
        {
            get     
            {
                if (this._controls == null)
                {
                    try
                    {

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.TypeNameHandling = TypeNameHandling.Objects;

                        this._controls = JsonConvert.DeserializeObject<List<IControl>>(this._content, settings);
                    }
                    catch (Exception exception)
                    {
                        this._controls = new List<IControl>();
                    }
                }

                if (this._controls == null)
                {
                    this._controls = new List<IControl>();
                }

                return this._controls; 
            }
        }

        public IList<string> ControlIds
        {
            get
            {
                this._controlIds = new List<string>();

                this.LoadControlIds(this.Controls);

                return this._controlIds;
            }
            internal set { this._controlIds = value; }
        }

        /// <summary>
        /// Gets and sets the id of this page
        /// </summary>
        public int Id
        {
            get { return this._id; }
            internal set { this._id = value; }
        }


        /// <summary>
        /// Gets and sets the template for this page
        /// </summary>
        public Template Template
        {
            get { return this._template; }
            internal set { this._template = value; }
        }

        /// <summary>
        /// Gets and sets the name of this page
        /// </summary>
        public string Name
        {
            get { return this._name; }
            internal set { this._name = value; }
        }

        /// <summary>
        /// Gets and sets all the content for this page. Ie all the json to construct all the controls
        /// </summary>
        public string Content
        {
            get { return this._content; }
            internal set { this._content = value; }
        }

        /// <summary>
        /// Gets the key for this page to be used in the url
        /// /Page/{key}/{pageId}
        /// </summary>
        public string Key
        {
            get 
            {
                if (string.IsNullOrEmpty(this._key))
                {
                    this._key = this.Name.Replace(" ", "-");
                }

                return this._key; 
            }
            internal set { this._key = value; }
        }
        

        /// <summary>
        /// Gets and sets the matching url for this page
        /// </summary>
        public string Url
        {
            get { return this._url; }
            internal set { this._url = value; }
        }

        
        /// <summary>
        /// Gets the website that this page belongs to
        /// </summary>
        public IWebsite Website
        {
            get { return this._website; }
            internal set { this._website = value; }
        }













        //public IControl GetParent(IControl control)
        //{
        //    return this.GetParent(this.Controls, control);
        //}

        //private IControl GetParent(IList<IControl> controls, IControl childControl)
        //{
        //    foreach (IControl control in controls)
        //    {
        //        if (control.Controls.Contains(childControl))
        //        {
        //            return control;
        //        }

        //        if (control.Controls.Count > 0)
        //        {
        //            IControl parentControl = this.GetParent(control.Controls, childControl);
        //            if (parentControl != null)
        //            {
        //                return parentControl;
        //            }
        //        }
        //    }

        //    return null;
        //}









        //public void UpdateControl(IControl control)
        //{
        //    IControl foundControl = this.UpdateControl(this.Controls, control);

        //    if (foundControl != null)
        //    {
        //        this.Controls[this.Controls.IndexOf(foundControl)] = control;
        //    }

        //    this._controlIds = new List<string>();
        //    this.LoadControlIds(this.Controls);
        //}

        //private IControl UpdateControl(IList<IControl> controls, IControl updatedControl)
        //{
        //    foreach (IControl control in controls)
        //    {
        //        if (control.Id == updatedControl.Id)
        //        {
        //            return control;
        //        }

        //        if (control.Controls.Count > 0)
        //        {
        //            IControl foundControl = this.UpdateControl(control.Controls, updatedControl);
        //            if (foundControl != null)
        //            {
        //                control.Controls[control.Controls.IndexOf(foundControl)] = updatedControl;
        //            }
        //        }
        //    }

        //    return null;
        //}



        //public void AddControl(Guid? parentControlId, IControl control)
        //{
        //    if (parentControlId.HasValue)
        //    {
        //        this.GetControl(parentControlId.Value).Controls.Add(control);
        //    }
        //    else
        //    {
        //        this.Controls.Add(control);
        //    }

        //    this._controlIds = new List<string>();
        //    this.LoadControlIds(this.Controls);
        //}

        //public IControl GetControl(Guid controlId)
        //{
        //    return this.GetControl(this.Controls, controlId);
        //}

        //public void DeleteControl(Guid controlId)
        //{
        //    IControl foundControl = this.DeleteControl(this.Controls, controlId);

        //    if (foundControl != null)
        //    {
        //        this.Controls.Remove(foundControl);
        //    }
        //}

        //private IControl DeleteControl(IList<IControl> controls, Guid controlId)
        //{
        //    foreach (IControl control in controls)
        //    {
        //        if (control.Id == controlId)
        //        {
        //            return control;
        //        }

        //        if (control.Controls.Count > 0)
        //        {
        //            IControl foundControl = this.DeleteControl(control.Controls, controlId);
        //            if (foundControl != null)
        //            {
        //                control.Controls.Remove(foundControl);
        //            }
        //        }
        //    }

        //    return null;
        //}

        //private IControl GetControl(IList<IControl> controls, Guid controlId)
        //{
        //    foreach (IControl control in controls)
        //    {
        //        if (control.Id == controlId)
        //        {
        //            return control;
        //        }

        //        if (control.Controls.Count > 0)
        //        {
        //            IControl foundControl = this.GetControl(control.Controls, controlId);
        //            if (foundControl != null)
        //            {
        //                return foundControl;
        //            }
        //        }
        //    }

        //    return null;
        //}

        private void LoadControlIds(IList<IControl> controls)
        {
            foreach (IControl control in controls)
            {
                this._controlIds.Add(control.Id.ToString());

                if (control.Controls.Count > 0)
                {
                    this.LoadControlIds(control.Controls);
                }

            }
        }

    }
}
