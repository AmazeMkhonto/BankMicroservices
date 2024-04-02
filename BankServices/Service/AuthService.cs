using BankServices.Models;
using BankServices.Service.IService;
using BankServices.Utility;

namespace BankServices.Service
{
	public class AuthService : IAuthService
	{
		private readonly IBaseService _baseService;
		public AuthService(IBaseService baseService)
		{
			_baseService = baseService;
		}

	

		public async Task<ResponseDTO?> LoginAsync(LoginRequestDTO loginRequestDto)
		{
			return await _baseService.SendAsync(new RequestDTO()
			{
				ApiType = SD.ApiType.POST,
				Data = loginRequestDto,
				Url = SD.AuthAPIBase + "/api/auth/login"
			}, withBearer: false);
		}

		public async Task<ResponseDTO?> RegisterAsync(RegisterRequestDTO registrationRequestDto)
		{
			return await _baseService.SendAsync(new RequestDTO()
			{
				ApiType = SD.ApiType.POST,
				Data = registrationRequestDto,
				Url = SD.AuthAPIBase + "/api/auth/register"
			}, withBearer: false);
		}
	}
}
