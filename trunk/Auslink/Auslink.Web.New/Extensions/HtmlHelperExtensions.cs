using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Auslink.Web.New.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString RouteImageLink(this HtmlHelper htmlHelper, string imageUrl, string routeName, object htmlAttributes, object routeValues)
        {
            UrlHelper urlHelper = ((Controller)htmlHelper.ViewContext.Controller).Url;

            string url = urlHelper.RouteUrl(routeName, routeValues);

            var imgtag = new TagBuilder("img");
            imgtag.MergeAttribute("src", imageUrl);

            TagBuilder imglink = new TagBuilder("a");
            imglink.MergeAttribute("href", url);
            imglink.InnerHtml = imgtag.ToString();
            imglink.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);


            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", imageUrl);



            var link = htmlHelper.RouteLink("[ImageTag]", routeName, routeValues, htmlAttributes).ToHtmlString();
            return new MvcHtmlString(link.Replace("[ImageTag]", builder.ToString(TagRenderMode.SelfClosing)));


        }
    }
}
