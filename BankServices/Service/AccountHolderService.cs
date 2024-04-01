using BankServices.Models;
using BankServices.Service.IService;
using BankServices.Utility;

namespace BankServices.Service
{
    public class AccountHolderService : IAccountHolderService
    {
        private readonly IBaseService _baseService;
        public AccountHolderService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> CreateAccountHolderAsync(AccountHolderDTO accountHolderDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = accountHolderDTO,
                Url = SD.AccountHolderAPIBase + "/api/AccountHolder"
            });
        }

        public async Task<ResponseDTO?> DeleteAccountHolderAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.AccountHolderAPIBase + "/api/AccountHolder/" + id
            });
        }

        public async Task<ResponseDTO?> GetAccountHolderByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AccountHolderAPIBase + "/api/AccountHolder/" + id
            });
        }

        public async Task<ResponseDTO?> GetAllAccountHoldersAsync()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AccountHolderAPIBase + "/api/AccountHolder"
                //Url = "https://localhost:7040/api/AccountHolder"
            });
        }

        public async Task<ResponseDTO?> UpdateAccountHolderAsync(AccountHolderDTO accountHolderDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                Data = accountHolderDTO,
                Url = SD.AccountHolderAPIBase + "/api/AccountHolder"
            });
        }
    }
}
