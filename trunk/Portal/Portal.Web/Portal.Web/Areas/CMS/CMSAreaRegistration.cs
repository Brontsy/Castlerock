using System.Web.Mvc;

namespace Portal.Web.Areas.CMS
{
    public class CMSAreaRegistration : AreaRegistration
    {
        public const string CmsRouteUrl = "CMS";
        public const string CmsPageRouteUrl = "CMS-Page";
        public const string CmsNewPageRouteUrl = "CMS-New-Page";
        
        public override string AreaName
        {
            get
            {
                return "CMS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(CMSAreaRegistration.CmsRouteUrl, "CMS", new { controller = "Pages", action = "Index" });
            context.MapRoute(CMSAreaRegistration.CmsPageRouteUrl, "CMS/Page/{pageName}/{pageId}", new { controller = "Pages", action = "Page" });
            context.MapRoute(CMSAreaRegistration.CmsNewPageRouteUrl, "CMS/Page/New", new { controller = "Pages", action = "New" });
        }
    }
}
