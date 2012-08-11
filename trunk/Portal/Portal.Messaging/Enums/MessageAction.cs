using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Messaging.Enums
{
    public enum MessageAction
    {
        /// <summary>
        /// This message is a insert (new object)
        /// </summary>
        Insert,

        /// <summary>
        /// A update to an existing object
        /// </summary>
        Update,

        /// <summary>
        /// Deleting a existing object
        /// </summary>
        Delete
    }
}
