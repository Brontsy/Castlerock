using System.Web.Mvc;

namespace Portal.Web.Areas.CMS
{
    public class CMSAreaRegistration : AreaRegistration
    {
        public const string CmsRouteUrl = "CMS";
        public const string CmsPageRouteUrl = "CMS-Page";
        public const string CmsNewPageRouteUrl = "CMS-New-Page";
        public const string CmsSaveNewPageRouteUrl = "CMS-Save-New-Page";

        public const string CmsAddControlRouteUrl = "CMS-Add-Control";
        public const string CmsAddControlsRouteUrl = "CMS-Add-Controls";
        public const string CmsDeleteControlRouteUrl = "CMS-Delete-Control";
        public const string CmsAddExistingControlRouteUrl = "CMS-Add-Existing-Control";
        public const string CmsSaveControlRouteUrl = "CMS-Save-Control";
        public const string CmsControlRouteUrl = "CMS-Control";

        public const string CmsTemplatesRouteUrl = "CMS-Template";
        public const string CmsAddTemplateRouteUrl = "CMS-Add-Template";
        public const string CmsViewTemplateRouteUrl = "CMS-View-Template";
        public const string CmsEditTemplateRouteUrl = "CMS-Edit-Template";
        public const string CmsSaveTemplateRouteUrl = "CMS-Save-Template";
        public const string CmsSaveNewTemplateRouteUrl = "CMS-Save-New-Template";
        
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

            context.MapRoute(CMSAreaRegistration.CmsAddControlsRouteUrl, "cms/page/{pageName}/{pageId}/add-controls/{location}/{parentControlId}", new { controller = "Pages", action = "AddControls", parentControlId = UrlParameter.Optional });
            context.MapRoute(CMSAreaRegistration.CmsAddExistingControlRouteUrl, "cms/page/{pageName}/{pageId}/add-existing-control/{location}/{controlId}", new { controller = "Pages", action = "AddExistingControl", parentControlId = UrlParameter.Optional });
            context.MapRoute(CMSAreaRegistration.CmsAddControlRouteUrl, "cms/page/{pageName}/{pageId}/add-control/{location}/{assembly}/{className}/{parentControlId}", new { controller = "Pages", action = "AddControl", parentControlId = UrlParameter.Optional });
            context.MapRoute(CMSAreaRegistration.CmsDeleteControlRouteUrl, "cms/page/{pageName}/{pageId}/delete-control/{controlId}", new { controller = "Pages", action = "DeleteControl", parentControlId = UrlParameter.Optional });
            context.MapRoute(CMSAreaRegistration.CmsSaveControlRouteUrl, "cms/page/{pageName}/{pageId}/save-control/{location}/{parentControlId}", new { controller = "Pages", action = "SaveControl", parentControlId = UrlParameter.Optional });


            context.MapRoute(CMSAreaRegistration.CmsTemplatesRouteUrl, "cms/templates", new { controller = "Template", action = "Index", });
            context.MapRoute(CMSAreaRegistration.CmsAddTemplateRouteUrl, "cms/template/add", new { controller = "Template", action = "Add", });
            context.MapRoute(CMSAreaRegistration.CmsEditTemplateRouteUrl, "cms/template/edit/{name}/{templateId}", new { controller = "Template", action = "Edit" });
            context.MapRoute(CMSAreaRegistration.CmsViewTemplateRouteUrl, "cms/template/{name}/{templateId}", new { controller = "Template", action = "Edit" });
            context.MapRoute(CMSAreaRegistration.CmsSaveNewTemplateRouteUrl, "cms/template/save-new", new { controller = "Template", action = "Save" });
            context.MapRoute(CMSAreaRegistration.CmsSaveTemplateRouteUrl, "cms/template/save/{name}/{templateId}", new { controller = "Template", action = "Save", name = UrlParameter.Optional, templateId = UrlParameter.Optional });


            context.MapRoute(CMSAreaRegistration.CmsNewPageRouteUrl, "cms/page/new", new { controller = "Pages", action = "New" });
            context.MapRoute(CMSAreaRegistration.CmsSaveNewPageRouteUrl, "cms/page/save-new", new { controller = "Pages", action = "Save" });

            context.MapRoute(CMSAreaRegistration.CmsControlRouteUrl, "cms/page/{pageName}/{pageId}/control/{controlId}", new { controller = "Pages", action = "Control" });

            context.MapRoute(CMSAreaRegistration.CmsPageRouteUrl, "cms/page/{pageName}/{pageId}", new { controller = "Pages", action = "Page" });
        }
    }
}
