using System.Web.Mvc;

namespace Castlerock.Web.Areas.V2
{
    public class V2AreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "V2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute("V2-Privacy-Policy", "V2/PrivacyPolicy", new { controller = "PrivacyPolicy", action = "Index" });

            context.MapRoute("V2-Disclaimer", "V2/Disclaimer", new { controller = "Disclaimer", action = "Index" });

            context.MapRoute("V2-Contact-Us", "V2/ContactUs", new { controller = "ContactUs", action = "Index" });

            context.MapRoute("V2-About-Us", "V2/AboutUs", new { controller = "AboutUs", action = "Index" });

            context.MapRoute("V2-Experience", "V2/Experience", new { controller = "Experience", action = "Index" });


            context.MapRoute("V2-Investors", "V2/Investors", new { controller = "V2Investors", action = "Index" });





            context.MapRoute("V2-Properties", "V2/Properties", new { controller = "Properties", action = "Index" });

            context.MapRoute("V2-PropertiesFromState", "V2/Properties/State/{state}", new { controller = "Properties", action = "State" });

            context.MapRoute("V2-Property", "V2/Properties/Show/{propertyName}/{propertyId}", new { controller = "Properties", action = "Show" });

            context.MapRoute("V2-Error-404", "V2/Error/404", new { controller = "Error", action = "Show404" });
            context.MapRoute("V2-Error-500", "V2/Error/500", new { controller = "Error", action = "Show500" });

            context.MapRoute("V2-Home", "V2", new { controller = "V2Home", action = "Index" });

            context.MapRoute(
                "V2-Default", // Route name
                "V2", // URL with parameters
                new { controller = "V2Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }
    }
}
