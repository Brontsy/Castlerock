using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Messaging;
using Portal.Cms.Interfaces;
using Portal.Cms;
using Portal.Messaging.Enums;
using Portal.Interfaces.Cms;

namespace Portal.Web.Areas.Messages.Controllers
{
    public class MessagesController : Controller
    {
        private IMessageService _messageService = null;
        private ICmsService _cmsService = null;

        public MessagesController(IMessageService messageService, ICmsService cmsService)
        {
            this._messageService = messageService;
            this._cmsService = cmsService;
        }

        public ActionResult Index()
        {
            var messages = this._messageService.GetMessages<IControl>(Subscription.Cms);

            return View(messages);
        }

        public ActionResult ProcessControls()
        {
            this._cmsService.ProcessControls();

            return this.Index();
        }
    }
}
