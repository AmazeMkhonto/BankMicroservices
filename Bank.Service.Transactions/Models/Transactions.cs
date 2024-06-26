﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bank.Service.Transactions.Models
{
    public class Transactionss
    {
        [Key]
        public int Id { get; set; }
        public long BankAccountId { get; set; }
        public string AccountType { get; set; }
        public string TransactionType { get; set; } // e.g., Withdrawal, Deposit
        public decimal Amount { get; set; }
    }
}
