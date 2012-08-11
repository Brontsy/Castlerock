using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Events
{
    public interface IEventSomething
    {
        T Get<T>();
    }

    public class EventController
    {
        private static EventController _instance = null;

        private IList<IEventSomething> _events = new List<IEventSomething>();

        public static EventController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventController();
                }

                return _instance;
            }
        }

        public IList<IEventSomething> Events
        {
            get { return this._events; }
        }

        public T Get<T>()
        {
            foreach (IEventSomething eventSomething in this.Events)
            {
                T result = eventSomething.Get<T>();
                if (result != null)
                {
                    return result;
                }
            }

            return default(T);
        }
    }
}
