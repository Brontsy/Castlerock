using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Messaging.Interfaces;
using Portal.Messaging.Models;
using Portal.Messaging.Enums;

namespace Portal.Messaging.Repository
{
    public class MessageRepository : IMessageRepository
    {



        /// <summary>
        /// Saves a message to the database so it can be processed by other services
        /// </summary>
        /// <param name="message">the message to be saved</param>
        public void SaveMessage<T>(IMessage<T> message)
        {
            PetaPoco.Database database = new PetaPoco.Database("Castlerock");

            database.Save(message);
        }

        /// <summary>
        /// Gets all the messages that need to be processed of type T
        /// </summary>
        /// <typeparam name="T">the type of message to be returned</typeparam>
        /// <returns></returns>
        public IList<IMessage<T>> GetMessages<T>(Subscription subsccription)
        {
            PetaPoco.Database database = new PetaPoco.Database("Castlerock");

            IList<Message<T>> messages = database.Fetch<Message<T>>("Select * From Messages Where Type = @Type And Subscription = @Subscription", new { Type = typeof(T).FullName, Subscription = subsccription });
            //IList<Message<T>> messages = database.Fetch<Message<T>>("Select * From Messages Where Type = @Type And Subscription = @Subscription MessageId Not In (Select MessageId From MessagesProcessedItems Where MessageId = Messages.MessageId And MessagesProcessedItems.Type = @ProcessType)", new { Type = typeof(T).FullName, ProcessType = (int)processType });
            
            IList<IMessage<T>> blah = new List<IMessage<T>>();

            foreach (Message<T> message in messages)
            {
                blah.Add(message as IMessage<T>);
            }

            return blah;
        }


        /// <summary>
        /// Updates the message to say it has been processed by the type that is being passed in
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">the message that was processed</param>
        public void Processed<T>(IMessage<T> message)
        {
            PetaPoco.Database database = new PetaPoco.Database("Castlerock");

            database.Delete(message);
        }
    }
}
