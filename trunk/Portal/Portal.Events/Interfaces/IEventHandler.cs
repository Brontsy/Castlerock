using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Events.Interfaces
{
    public interface IEventSubscriber
    {

        void Notify(IEvent e);


        T Request<T>(IEvent e);

    }
}
