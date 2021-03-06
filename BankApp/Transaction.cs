﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public enum TransactionType
    {
        Credit,
        Debit
    }
    public class Transaction
    
    {
        [Key]
        public int Transactionid  { get; set; }
        public DateTime TransactionsDate { get; set; }
        public String Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TypeOfTransaction { get; set; }
        [ForeignKey("Account")]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }
     }
}
