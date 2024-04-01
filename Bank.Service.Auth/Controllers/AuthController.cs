using Bank.Service.Auth.Models.DTO;
using Bank.Service.Auth.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Service.Auth.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;
		private readonly IConfiguration _configuration;
		protected ResponseDTO _response;
		public AuthController(IAuthService authService, IConfiguration configuration)
		{
			_authService = authService;
			_configuration = configuration;
			_response = new();
		}



		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequestDTO model)
		{

			var errorMessage = await _authService.Register(model);
			if (!string.IsNullOrEmpty(errorMessage))
			{
				_response.IsSuccess = false;
				_response.Message = errorMessage;
				return BadRequest(_response);
			}
			return Ok(_response);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
		{
			var loginResponse = await _authService.Login(model);
			if (loginResponse.User == null)
			{
				_response.IsSuccess = false;
				_response.Message = "Username or password is incorrect";
				return BadRequest(_response);
			}
			_response.Result = loginResponse;
			return Ok(_response);

		}

	}
}

