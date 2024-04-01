using BankServices.Models;

namespace BankServices.Service.IService
{
    public interface IAccountHolderService
    {
        Task<ResponseDTO?> GetAllAccountHoldersAsync();
        Task<ResponseDTO?> GetAccountHolderByIdAsync(int id);
        Task<ResponseDTO?> CreateAccountHolderAsync(AccountHolderDTO accountHolderDTO);
        Task<ResponseDTO?> UpdateAccountHolderAsync(AccountHolderDTO accountHolderDTO);
        Task<ResponseDTO?> DeleteAccountHolderAsync(int id);
    }
}

