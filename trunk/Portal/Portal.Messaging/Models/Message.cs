using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Messaging.Interfaces;
using Portal.Messaging.Enums;

namespace Portal.Messaging.Models
{
    [PetaPoco.TableName("Messages")]
    [PetaPoco.PrimaryKey("MessageId")]
    public class Message<T> : IMessage<T>
    {
        private string _type = null;


        [PetaPoco.Column("MessageId")]
        public int Id { get; internal set; }


        /// <summary>
        /// Gets the type of message this is (page, control etc)
        /// </summary>
        public string Type
        {
            get
            {
                if (this._type == null)
                {
                    this._type = typeof(T).FullName;
                }

                return this._type;
            }
            set { this._type = value; }
        }

        /// <summary>
        /// Gets the action this message is (Insert, Update, Delete etc)
        /// </summary>
        public MessageAction Action { get; internal set; }

        /// <summary>
        /// Gets the 
        /// </summary>
        [PetaPoco.Ignore]
        public T Content { get; internal set; }

        /// <summary>
        /// Gets and sets the content object serialised as json
        /// </summary>
        public string JsonContent { get; internal set; }

        /// <summary>
        /// Gets and sets the subscription that this message is bound to
        /// </summary>
        public Subscription Subscription { get; internal set; }
    }
}
