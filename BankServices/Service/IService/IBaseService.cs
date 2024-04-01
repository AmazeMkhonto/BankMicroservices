using BankServices.Models;

namespace BankServices.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO requestDto);
    }
}
