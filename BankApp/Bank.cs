﻿using System;
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
    }
}
