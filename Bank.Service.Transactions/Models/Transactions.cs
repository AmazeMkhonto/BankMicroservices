using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bank.Service.Transactions.Models
{
    public class Transactions
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("BankAccount")]
        public int BankAccountId { get; set; }
        //public virtual Account BankAccount { get; set; } 

        public string TransactionType { get; set; } // e.g., Withdrawal, Deposit
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
