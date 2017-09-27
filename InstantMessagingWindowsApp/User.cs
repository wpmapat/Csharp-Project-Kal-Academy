using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessagingWindowsApp
{
    class User:Account
    {
        public User(string name, int phNumber, string emailAddress, string password)
        {
            this.Name = name;
            this. PhoneNo = phNumber;
            this.EmailAddress = emailAddress;
            this.CreatedDate = DateTime.Now;
            this.Password = password;
        }
        #region         
        
        /// <summary>
        /// Phone number of the user
        /// </summary>
        public int PhoneNo { get; set; }
        
        /// <summary>
        /// Email Address of the user
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Password which user enters at the login screen
        /// </summary>
        public string Password { get; set; }
        

        

        #endregion
    }
}
