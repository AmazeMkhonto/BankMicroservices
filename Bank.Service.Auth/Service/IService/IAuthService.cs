using Bank.Service.Auth.Models.DTO;

namespace Bank.Service.Auth.Service.IService
{
	public interface IAuthService
	{
		Task<string> Register(RegisterRequestDTO registerRequestDto);
		Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto);
	}
}
