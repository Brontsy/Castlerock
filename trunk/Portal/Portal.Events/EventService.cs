using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Interfaces;
using Portal.Events.Interfaces;

namespace Portal.Events
{
    public class EventService : IEventService
    {
        public static EventBroker EventBroker;

        public EventService(IList<IEventSubscriber> handlers)
        {
            EventBroker.Instance.Subscribers = handlers;
        }
         
    }


    public class EventBroker
    {
        private static EventBroker _instance = null;

        private IList<IEventSubscriber> _eventHandlers = null;

        public static EventBroker Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventBroker();
                }

                return _instance;
            }
        }

        public IEnumerable<IEventSubscriber> Subscribers { get; set; }



        public void Notify(IEvent e)
        {

        }


        public T Request<T>(IEvent e)
        {
            foreach (IEventSubscriber subscriber in this.Subscribers)
            {
                return subscriber.Request<T>(e);
            }

            return default(T);
        }
    }

}
