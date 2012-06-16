using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Portal.Cms.Interfaces;
using System.Xml;

namespace Portal.Cms.Extensions
{
    public static class DictionaryExtensions
    {

        /// <summary>
        /// Gets a specific value out of the data items. 
        /// </summary>
        /// <typeparam name="T">teh type the value returned is (string, int, datetime etc)</typeparam>
        /// <param name="dataItems">the dataitems to look in</param>
        /// <param name="key">the key to use to search inside the data items</param>
        public static T Get<T>(this IDictionary<string, object> dataItems, string key)
        {
            if (dataItems.ContainsKey(key))
            {
                // if the typeof T is a boolean then reset the value as a bool value. This is because C# cannot cast "true" to bool
                if (typeof(T) == true.GetType())
                {
                    dataItems[key] = (dataItems[key].ToString().ToLower() == "true" ? true : false);
                }

                int i = 10;
                if (typeof(T) == i.GetType())
                {
                    dataItems[key] = int.Parse(dataItems[key].ToString());
                }

                DateTime date = DateTime.Now;
                if (typeof(T) == date.GetType())
                {
                    dataItems[key] = DateTime.Parse(dataItems[key].ToString());
                }

                return (T)dataItems[key];
            }

            return default(T);
        }
    }
}
