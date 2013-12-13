using System.Web.Mvc;

namespace Portal.Web.Areas.Membership
{
    public class MembershipAreaRegistration : AreaRegistration
    {
        public const string MembershipRouteUrl = "Members";
        public const string MembershipNewRouteUrl = "Member-New";
        public const string MembershipEditRouteUrl = "Member-Edit";
        public const string MembershipSaveRouteUrl = "Member-Save";
        public const string MembershipSaveNewRouteUrl = "Member-Save-New";
        public const string MembershipChangePasswordRouteUrl = "Member-Change-Password";

        public override string AreaName
        {
            get
            {
                return "Membership";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(MembershipAreaRegistration.MembershipRouteUrl, "membership", new { controller = "Membership", action = "Index", area = "Membership" });
            context.MapRoute(MembershipAreaRegistration.MembershipNewRouteUrl, "membership/new", new { controller = "Membership", action = "New", memberId = 0 });
            context.MapRoute(MembershipAreaRegistration.MembershipEditRouteUrl, "membership/edit/{username}/{memberId}", new { controller = "Membership", action = "Edit" });
            context.MapRoute(MembershipAreaRegistration.MembershipSaveRouteUrl, "membership/save/{username}/{memberId}", new { controller = "Membership", action = "Save" });
            context.MapRoute(MembershipAreaRegistration.MembershipSaveNewRouteUrl, "membership/save/new-member", new { controller = "Membership", action = "Save" });
            context.MapRoute(MembershipAreaRegistration.MembershipChangePasswordRouteUrl, "membership/change-password/{username}/{memberId}", new { controller = "Membership", action = "ChangePassword" });

        }
    }
}
