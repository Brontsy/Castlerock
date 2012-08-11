using System.Web.Mvc;

namespace Portal.Web.Areas.Messages
{
    public class MessagesAreaRegistration : AreaRegistration
    {
        public const string Messages = "Messages";
        public const string ProcessControls = "Process-Controls";

        public override string AreaName
        {
            get
            {
                return "Messages";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(MessagesAreaRegistration.ProcessControls, "messages/process-controls", new { controller = "Messages", action = "ProcessControls" });
            context.MapRoute(MessagesAreaRegistration.Messages, "messages", new { controller = "Messages", action = "Index" });
        }
    }
}
