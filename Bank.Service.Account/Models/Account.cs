using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Bank.Service.Account.Models
{
    public class Accounts
    {
        private static List<long> usedAccountNumbers = new List<long>();

        [Key]
        public long Id { get; set; } // account number

        public Accounts()
        {
            long newAccountNumber = GenerateUniqueAccountNumber();
            while (usedAccountNumbers.Contains(newAccountNumber))
            {
                newAccountNumber++; 
            }
            Id = newAccountNumber;
            usedAccountNumbers.Add(newAccountNumber);
        }

        private long GenerateUniqueAccountNumber()
        {
            return 1000000001;
        }
        public string AccountType { get; set; } 
        public string Name { get; set; }
        public string Status { get; set; }
        public decimal AvailableBalance { get; set; }
        public int AccountHolderId { get; set; }

    }
}
