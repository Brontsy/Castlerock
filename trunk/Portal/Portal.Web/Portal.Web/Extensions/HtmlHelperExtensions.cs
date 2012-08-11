using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Reflection;
using System.Web.Routing;
using System.IO;

namespace Portal.Web.Extensions
{
    public static class HtmlHelperExtensions
    {


        public static string RenderPartialToString(this HtmlHelper htmlHelper, string viewName, object model)
        {
            ControllerContext controllerContext = htmlHelper.ViewContext.Controller.ControllerContext;

            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controllerContext.RouteData.GetRequiredString("action");
            }


            ViewDataDictionary ViewData = new ViewDataDictionary();
            TempDataDictionary TempData = new TempDataDictionary();
            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                ViewContext viewContext = new ViewContext(controllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }

        }


            public static MvcHtmlString RouteImageLink(this HtmlHelper htmlHelper, string imageUrl, string text, string routeName, object htmlAttributes, object routeValues)
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
                return new MvcHtmlString(link.Replace("[ImageTag]", builder.ToString(TagRenderMode.SelfClosing) + "<br />" + text));


            }








        private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
        {
            Type realModelType = modelMetadata.ModelType;

            Type underlyingType = Nullable.GetUnderlyingType(realModelType);
            if (underlyingType != null)
            {
                realModelType = underlyingType;
            }
            return realModelType;
        }

        private static readonly SelectListItem[] SingleEmptyItem = new[] { new SelectListItem { Text = "", Value = "" } };

        public static string GetEnumDescription<TEnum>(TEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if ((attributes != null) && (attributes.Length > 0))
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
        {
            return EnumDropDownListFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            Type enumType = GetNonNullableModelType(metadata);
            IEnumerable<TEnum> values = Enum.GetValues(enumType).Cast<TEnum>();

            IEnumerable<SelectListItem> items = from value in values
                                                select new SelectListItem
                                                {
                                                    Text = GetEnumDescription(value),
                                                    Value = value.ToString(),
                                                    Selected = value.Equals(metadata.Model)
                                                };

            // If the enum is nullable, add an 'empty' item to the collection
            if (metadata.IsNullableValueType)
                items = SingleEmptyItem.Concat(items);

            return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
        }
    }
}