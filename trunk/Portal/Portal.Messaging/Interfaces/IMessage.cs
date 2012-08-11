using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Messaging.Models;
using Portal.Messaging.Enums;

namespace Portal.Messaging.Interfaces
{
    public interface IMessage<T>
    {
        int Id { get; }

        /// <summary>
        /// Gets the type of message this is (page, control etc)
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the action this message is (Insert, Update, Delete etc)
        /// </summary>
        MessageAction Action { get; }

        /// <summary>
        /// Gets the 
        /// </summary>
        T Content { get; }


        /// <summary>
        /// Gets and sets the content object serialised as json
        /// </summary>
        string JsonContent { get; }

        /// <summary>
        /// Gets and sets the subscription that this message is bound to
        /// </summary>
        Subscription Subscription { get; }
    }
}
