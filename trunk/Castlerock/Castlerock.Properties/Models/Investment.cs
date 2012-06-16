using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castlerock.Properties.Models
{
    public class Investment
    {

        public int _id;
        public string _name = string.Empty;
        public string _url = string.Empty;
        public bool _isOpen = true;

        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string Url
        {
            get { return this._url; }
            set { this._url = value; }
        }

        public bool IsOpen
        {
            get { return this._isOpen; }
            set { this._isOpen = value; }
        }
    }
}
