using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessagingWindowsApp
{
    class Message
    {
        public DateTime Messagetime { get; set; }
        public string ToPhoneno { get; set; }
        public string FromPhoneno { get; set; }
        public string MessageText { get; set; }
    }
}
