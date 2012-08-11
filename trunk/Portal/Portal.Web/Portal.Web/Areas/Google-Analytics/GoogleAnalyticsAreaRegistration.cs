using System.Web.Mvc;

namespace Portal.Web.Areas.GoogleAnalytics
{
    public class GoogleAnalyticsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Google-Analytics";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("GoogleAnalytics_default", "Google-Analytics", new { controller = "GoogleAnalytics", action = "Index", id = UrlParameter.Optional });
        }
    }
}
