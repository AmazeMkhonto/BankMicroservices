﻿namespace Bank.Service.Account.Models.DTO
{
    public class AccountDTO
    {
        public long Id { get; set; } 
        public string AccountType { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public decimal AvailableBalance { get; set; }
        public int AccountHolderId { get; set; }
    }
}
