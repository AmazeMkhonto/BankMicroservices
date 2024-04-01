namespace BankServices.Models
{
	public class TransactionDTO
	{
		public int Id { get; set; }
		public long BankAccountId { get; set; }
		public string AccountType { get; set; }
		public string TransactionType { get; set; } // e.g., Withdrawal, Deposit
		public decimal Amount { get; set; }
	}
}
