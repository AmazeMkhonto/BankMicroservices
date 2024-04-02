using BankServices.Models;

namespace BankServices.Service.IService
{
    public interface IAccountService
    {
        Task<ResponseDTO?> GetAllAccountsAsync();
        Task<ResponseDTO?> GetAccountByIdAsync(long id);
        Task<ResponseDTO?> GetAccountByUserIdAsync(string id);
        Task<ResponseDTO?> CreateAccountAsync(AccountDTO accountDTO);
        Task<ResponseDTO?> UpdateAccountAsync(AccountDTO accountDTO);
        Task<ResponseDTO?> DeleteAccountAsync(long id);
    }
}
