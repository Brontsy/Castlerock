using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Portal.Cms.Interfaces;

namespace Portal.Cms.Extensions
{
    public static class ParameterExtensions
    {

        /// <summary>
        /// Updates the collection of parameters with the new values that was posted
        /// up through the http request object
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IList<IParameter> Update(this IList<IParameter> parameters, NameValueCollection postedValues)
        {
            foreach (IParameter parameter in parameters)
            {
                parameter.SetFormValue(postedValues);
            }

            return parameters;
        }

        /// <summary>
        /// gets a specific parameter from the collection from the key that is passed in.
        /// Use Ilist<IParameter>.Has(key) to check if the parameter exists
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="key">The key of the parameter to look for</param>
        /// <returns></returns>
        public static IParameter Get(this IList<IParameter> parameters, string key)
        {
            foreach (IParameter parameter in parameters)
            {
                if (parameter.Key == key)
                {
                    return parameter;
                }
            }
            return null;
        }

        public static T Get<T>(this IList<IParameter> parameters, string key)
        {
            foreach (IParameter parameter in parameters)
            {
                if (parameter.Key == key)
                {
                    return (T)parameter;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Does the collection of parameters have a parameter that belongs to the key passed in
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="key">The key of the parameter to look for</param>
        /// <returns></returns>
        public static bool Has(this IList<IParameter> parameters, string key)
        {
            foreach (IParameter parameter in parameters)
            {
                if (parameter.Key == key)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Is the collection of parameters all valid or not
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="key">The key of the parameter to look for</param>
        /// <returns></returns>
        public static bool IsValid(this IList<IParameter> parameters)
        {
            bool result = true;

            foreach (IParameter parameter in parameters)
            {
                if (!parameter.IsValid)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
