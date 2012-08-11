using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Messaging.Interfaces;
using Portal.Messaging.Enums;

namespace Portal.Messaging
{
    public interface IMessageService
    {
        /// <summary>
        /// Adds a new message into the message system
        /// </summary>
        /// <typeparam name="T">the type of object being saved inside hte message</typeparam>
        /// <param name="content">the object to be saved into the message</param>
        /// <param name="type">the type of object being saved</param>
        /// <param name="action">the action of the message (insert, update etc)</param>
        void AddMessage<T>(T content, MessageAction action);

        /// <summary>
        /// Gets a list of all the messages
        /// </summary>
        /// <typeparam name="T">the type of message to return</typeparam>
        /// <returns>a list of all the messages that matches Type T</returns>
        IList<IMessage<T>> GetMessages<T>(Subscription subscription);
        
        /// <summary>
        /// Sets all the messages to say they have been processed by the type that is being passed in
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="messages">the list of messages to say were processed</param>
        void Processed<T>(IList<IMessage<T>> messages);
    }
}
