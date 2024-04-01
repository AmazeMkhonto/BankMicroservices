using BankServices.Models;
using BankServices.Service.IService;
using BankServices.Utility;

namespace BankServices.Service
{
    public class AccountService : IAccountService
    {
        private readonly IBaseService _baseService;
        public AccountService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> CreateAccountAsync(AccountDTO accountDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO?> DeleteAccountAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO?> GetAccountByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO?> GetAccountByUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO?> GetAllAccountsAsync()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AccountAPIBase + "/api/Accounts"
				//Url = "https://localhost:7022/api/Accounts"
			});
        }

        public async Task<ResponseDTO?> UpdateAccountAsync(AccountDTO accountDTO)
        {
            throw new NotImplementedException();
        }
    }
}
