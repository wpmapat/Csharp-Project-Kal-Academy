using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    /// <summary>
    /// This is about bank account (XML comments)
    /// </summary>
    class Account
    {
        #region Properties
        //Properties definations

        /// <summary>
        ///This hold the account number 
        /// </summary>
        public int AccountNumber { get; set; }
        /// <summary>
        /// this will hold email address
        /// </summary>
        public string EmailAddress { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public DateTime CreatedDate { get; set; }
        # endregion

    }
}
