using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Events.Interfaces;

namespace Portal.Events.Events
{
    public class PageEvent : IEvent
    {
        private int _pageId;

        public PageEvent(int pageId)
        {
            this._pageId = pageId;
        }

        public int PageId
        {
            get { return this._pageId; }
        }
    }
}
