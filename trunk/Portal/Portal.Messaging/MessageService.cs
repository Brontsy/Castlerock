﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Portal.Messaging.Interfaces;
using Portal.Messaging.Models;
using Portal.Messaging.Enums;

namespace Portal.Messaging
{
    public class MessageService : IMessageService
    {
        private IMessageRepository _messageRepository = null;

        public MessageService(IMessageRepository messageRepository)
        {
            this._messageRepository = messageRepository;
        }

        /// <summary>
        /// Adds a new message into the message system
        /// </summary>
        /// <typeparam name="T">the type of object being saved inside hte message</typeparam>
        /// <param name="content">the object to be saved into the message</param>
        /// <param name="type">the type of object being saved</param>
        /// <param name="action">the action of the message (insert, update etc)</param>
        public void AddMessage<T>(T content, Enums.MessageAction action)
        {
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;

            string messageContent = JsonConvert.SerializeObject(content, Newtonsoft.Json.Formatting.Indented, settings);

            IList<Subscription> subscriptions = this.GetSubsciptions<T>();

            foreach (Subscription subscription in subscriptions)
            {

                IMessage<T> message = new Message<T>()
                {
                    Action = action,
                    Content = content,
                    JsonContent = messageContent,
                    Subscription = subscription
                };

                this._messageRepository.SaveMessage<T>(message);
            }
        }

        /// <summary>
        /// Gets a list of all the messages
        /// </summary>
        /// <typeparam name="T">the type of message to return</typeparam>
        /// <returns>a list of all the messages that matches Type T</returns>
        public IList<IMessage<T>> GetMessages<T>(Subscription subsccription)
        {
            IList<IMessage<T>> messages = this._messageRepository.GetMessages<T>(subsccription);

            foreach (IMessage<T> message in messages.Where(o => !string.IsNullOrEmpty(o.JsonContent)))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.Objects;

                (message as Message<T>).Content = JsonConvert.DeserializeObject<T>(message.JsonContent, settings);
            }

            return messages;
        }

        /// <summary>
        /// Sets all the messages to say they have been processed by the type that is being passed in
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="messages">the list of messages to say were processed</param>
        public void Processed<T>(IList<IMessage<T>> messages)
        {
            foreach (IMessage<T> message in messages)
            {
                this._messageRepository.Processed(message);
            }
        }

        private IList<Subscription> GetSubsciptions<T>()
        {
            IList<Subscription> subscriptions = new List<Subscription>();

            switch (typeof(T).FullName)
            {
                case "Portal.Cms.Interfaces.IControl":
                    subscriptions.Add(Subscription.Cms);
                    break;

            }

            return subscriptions;
        }
    }
}
