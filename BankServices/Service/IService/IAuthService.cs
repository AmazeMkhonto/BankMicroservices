using BankServices.Models;

namespace BankServices.Service.IService
{
	public interface IAuthService
	{
		Task<ResponseDTO?> LoginAsync(LoginRequestDTO loginRequestDto);
		Task<ResponseDTO?> RegisterAsync(RegisterRequestDTO registrationRequestDto);
	}
}
