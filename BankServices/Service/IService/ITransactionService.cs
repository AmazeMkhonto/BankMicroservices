using BankServices.Models;

namespace BankServices.Service.IService
{
	public interface ITransactionService
	{
		Task<ResponseDTO?> GetAllTransactionsAsync();
		Task<ResponseDTO?> GetTransactionByIdAsync(int id);
		Task<ResponseDTO?> CreateTransactionAsync(TransactionDTO transactionDTO);
		Task<ResponseDTO?> UpdateTransactionAsync(TransactionDTO transactionDTO);
		Task<ResponseDTO?> DeleteTransactionAsync(int id);
	}
}
