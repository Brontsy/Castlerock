using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Exceptions
{
    public interface IExceptionManager
    {
        /// <summary>
        /// Logs the exception through the exception manager.
        /// The exception manage could have many different implementations, Database, email etc
        /// </summary>
        /// <param name="exception">the exception that was thrown</param>
        /// <param name="message">the custom message to go with the exception</param>
        void LogException(Exception exception, string message);
    }
}
