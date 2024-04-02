using BankServices.Models;
using BankServices.Service.IService;
using BankServices.Utility;

namespace BankServices.Service
{
	public class TransactionService : ITransactionService
	{
		private readonly IBaseService _baseService;
		public TransactionService(IBaseService baseService)
		{
			_baseService = baseService;
		}
		public async Task<ResponseDTO?> CreateTransactionAsync(TransactionDTO transactionDTO)
		{
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = transactionDTO,
                Url = SD.TransactionAPIBase + "/api/Transaction"
            });
        }

		public async Task<ResponseDTO?> DeleteTransactionAsync(int id)
		{
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.TransactionAPIBase + "/api/Transaction/" + id
            });
        }

		public async Task<ResponseDTO?> GetAllTransactionsAsync()
		{
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TransactionAPIBase + "/api/Transaction"
                //Url = "https://localhost:7237/api/Transaction"
            });
        }

		public async Task<ResponseDTO?> GetTransactionByIdAsync(int id)
		{
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TransactionAPIBase + "/api/Transaction/" + id
            });
        }

		public async Task<ResponseDTO?> UpdateTransactionAsync(TransactionDTO transactionDTO)
		{
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                Data = transactionDTO,
                Url = SD.TransactionAPIBase + "/api/Transaction"
            });
        }
	}
}
