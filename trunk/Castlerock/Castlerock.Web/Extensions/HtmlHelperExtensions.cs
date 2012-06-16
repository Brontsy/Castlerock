using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.Web.Mvc.Html;

namespace Castlerock.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string PropertiesInStateLink(this HtmlHelper helper, string state)
        {
            string routeName = "PropertiesFromState";
            string imageSrc = string.Format("<img class=\"png\" src=\"/Content/Images/Australia/{0}.png\" />", state.ToLower());

            string link = helper.RouteLink("[ImageUrl]", routeName, new { state = state }, new { @class = "hidden" }).ToString();

            return link.Replace("[ImageUrl]", imageSrc);
        }
    }
}