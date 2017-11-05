using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessagingWindowsApp
{
    class Account
    {

        #region Properties

        /// <summary>
        /// This will hold an Account Number which will be our unique identifier
        /// </summary>
        public int AccountNumber { get; set; }
        
        /// <summary>
        /// Date and Time it was created
        /// </summary>
        public DateTime CreatedDate { get; set; }
        
        /// <summary>
        /// Name of the User of App
        /// </summary>
        public string Name { get; set; }
        
        #endregion

        
    }
}