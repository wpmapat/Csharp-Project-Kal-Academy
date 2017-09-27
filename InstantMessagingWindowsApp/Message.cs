using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessagingWindowsApp
{
    class Message
    {
        #region Properties
        /// <summary>
        /// Conversation or text in the message
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// Date and time at which message is created
        /// </summary>
        public DateTime MessgeDateTime { get; set; }
        /// <summary>
        /// Name of the Sender
        /// </summary>
        public User MessageSender { get; set; }
#endregion
    }
}
