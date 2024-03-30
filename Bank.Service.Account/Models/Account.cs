using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Bank.Service.Account.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AccountHolder")]
        public int AccountHolderId { get; set; }
        //public virtual AccountHolder AccountHolder { get; set; }

        public string AccountNumber { get; set; }
        public string AccountType { get; set; } // e.g., Cheque, Savings, FixedDeposit
        public string Name { get; set; }
        public string Status { get; set; } // e.g., Active, Inactive
        public decimal AvailableBalance { get; set; }

        // You can add a collection of Transactions if relevant to your design
        //public ICollection<Transaction> Transactions { get; set; }
    }
}
