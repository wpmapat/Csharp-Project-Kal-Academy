using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessagingApp
{
    class User:Account
    {
#region 
        /// <summary>
        /// Phone number of the user
        /// </summary>
        public int PhoneNo { get; set; }
        /// <summary>
        /// Email Address of the user
        /// </summary>
        public string EmailAddress { get; set; }
#endregion
    }
}
