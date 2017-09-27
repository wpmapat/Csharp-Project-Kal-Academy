using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public enum TypeOfAccount
    {
        Checking,
        Savings,
        Loan,
        CD
    }
    /// <summary>
    /// This is about bank account (XML comments)
    /// </summary>
    public class Account
    {
        //one shared memory for all instance->static means
        private static int lastAccountnumber=0;
        #region Properties
        //Properties definations

        /// <summary>
        ///This hold the account number 
        /// </summary>
        public int AccountNumber { get; }
        /// <summary>
        /// this will hold email address
        /// </summary>
        public string EmailAddress { get; set; }
        public decimal Balance { get; private set; }
        public TypeOfAccount AccountType { get; set; }
        public DateTime CreatedDate { get; set; }
        #endregion

        #region Constructor
        //default constructor
        public Account()
        {
            //lastAccountnumber = +1;
            //AccountNumber = lastAccountnumber;

            AccountNumber = ++lastAccountnumber;
        }

        #endregion

        #region methods
        public decimal Deposit(decimal amount)
        {
            Balance += amount;//Balance=Balance +amount
            return Balance;
        }
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
        #endregion

    }
}
