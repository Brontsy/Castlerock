using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Messaging.Enums;

namespace Portal.Messaging.Interfaces
{
    public interface IMessageRepository
    {
        /// <summary>
        /// Saves a message to the database so it can be processed by other services
        /// </summary>
        /// <param name="message">the message to be saved</param>
        void SaveMessage<T>(IMessage<T> message);

        /// <summary>
        /// Gets all the messages that need to be processed of type T
        /// </summary>
        /// <typeparam name="T">the type of message to be returned</typeparam>
        /// <returns></returns>
        IList<IMessage<T>> GetMessages<T>(Subscription subsccription);

        /// <summary>
        /// Updates the message to say it has been processed by the type that is being passed in
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">the message that was processed</param>
        void Processed<T>(IMessage<T> message);
    }
}
