using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public static class Bank
    {
        private static BankModel db = new BankModel();


        public static Account CreateAccount(string emailAddress, TypeOfAccount accountType = TypeOfAccount.Checking, decimal initialDeposit = 0)
        {

            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType
            };
            

            if (initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
            }
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }
        public static List<Account>GetAllAccounts(string emailAddress)
        {
            return db.Accounts.Where(a=>a.EmailAddress==emailAddress).ToList();
        }

        /// <summary>
        /// Deposit money into account
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="amount"></param>
        /// <exception cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</exception>
        public static void Deposit(int accountNumber, decimal amount)
        {
            try
            {
                var account = GetAccountbyAccountNumber(accountNumber, amount);
                account.Deposit(amount);
                var transaction = new Transaction
                {
                    TransactionsDate = DateTime.UtcNow,
                    TypeOfTransaction = TransactionType.Credit,
                    Description = "Branch deposit",
                    AccountNumber = account.AccountNumber
                };

                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
            catch
            {
                //log
                throw;
            }
        }
        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = GetAccountbyAccountNumber(accountNumber, amount);
            var transaction = new Transaction
            {
                TransactionsDate = DateTime.UtcNow,
                TypeOfTransaction = TransactionType.Debit,
                Description = "Branch Withdrawl",
                AccountNumber = account.AccountNumber
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        private static Account GetAccountbyAccountNumber(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
                throw new ArgumentOutOfRangeException("Invalid account number");
            account.Withdraw(amount);
            return account;
        }

        public static List<Transaction>GetAllTransactions(int accountNumber)
        {
        return db.Transactions.Where(t=> t.AccountNumber == accountNumber).OrderByDescending(t=>t.TransactionsDate).ToList();
        }

    }
}
