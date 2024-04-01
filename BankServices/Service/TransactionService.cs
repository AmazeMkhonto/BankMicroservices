using BankServices.Models;
using BankServices.Service.IService;

namespace BankServices.Service
{
	public class TransactionService : ITransactionService
	{
		private readonly IBaseService _baseService;
		public TransactionService(IBaseService baseService)
		{
			_baseService = baseService;
		}
		public Task<ResponseDTO?> CreateTransactionAsync(TransactionDTO transactionDTO)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseDTO?> DeleteTransactionAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseDTO?> GetAllTransactionsAsync()
		{
			throw new NotImplementedException();
		}

		public Task<ResponseDTO?> GetTransactionByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseDTO?> UpdateTransactionAsync(TransactionDTO transactionDTO)
		{
			throw new NotImplementedException();
		}
	}
}
