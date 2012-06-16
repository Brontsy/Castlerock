using System.Web.Mvc;

namespace Portal.Web.Areas.PropertyEditor
{
    public class PropertyEditorAreaRegistration : AreaRegistration
    {
        public const string ViewAll = "Property-ViewAll";
        public const string New = "Property-New";
        public const string Edit = "Property-Edit";
        public const string Save = "Property-Save";
        public const string SaveNew = "Property-Save-New";

        public override string AreaName
        {
            get
            {
                return "Property-Editor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(PropertyEditorAreaRegistration.ViewAll, "Property-Editor", new { controller = "Properties", action = "Index" });
            context.MapRoute(PropertyEditorAreaRegistration.Edit, "Property-Editor/Edit/{propertyName}/{propertyId}", new { controller = "Properties", action = "Edit" });
            context.MapRoute(PropertyEditorAreaRegistration.New, "Property-Editor/New", new { controller = "Properties", action = "New" });
            context.MapRoute(PropertyEditorAreaRegistration.SaveNew, "Property-Editor/Save", new { controller = "Properties", action = "Save" });
            context.MapRoute(PropertyEditorAreaRegistration.Save, "Property-Editor/Save/{propertyName}/{propertyId}", new { controller = "Properties", action = "Save" });


            context.MapRoute("Blobs", "Property-Editor/Blobs", new { controller = "Properties", action = "Blobs" });
        }
    }
}
