using System;
using System.Collections.Generic;
using Castlerock.Properties.Interfaces;

namespace Castlerock.Web.Models
{
    public class PropertyPageViewModel
    {
        private string _state = string.Empty;
        public string State
        {
            get { return this._state; }
            set { this._state = value; }
        }

        public IProperty Property { get; set; }

        public IList<IProperty> CompleteProperties { get; set; }

        public IList<IProperty> InCompleteProperties { get; set; }

        public string getState()
        {
            switch(this.State.ToUpper())
            {
                case "VIC":
                    return "Victoria";
                case "NSW":
                    return "New South Wales";
                case "QLD":
                    return "Queensland";
                case "SA":
                    return "South Australia";
                case "NT":
                    return "Northen Territory";
                case "WA":
                    return "Western Australia";
                case "TAS":
                    return "Tasmania";
            }
            return "Victoria";
        }

        public Dictionary<string, string> States
        {
            get
            {
                Dictionary<string, string> _states = new Dictionary<string, string>();

                _states.Add("NSW", "New South Whales");
                _states.Add("NT", "Northern Territory");
                _states.Add("QLD", "Queensland");
                _states.Add("SA", "South Australia");
                _states.Add("TAS", "Tasmania");
                _states.Add("VIC", "Victoria");
                _states.Add("WA", "Western Australia");

                return _states;
            }
        }

    }
}
