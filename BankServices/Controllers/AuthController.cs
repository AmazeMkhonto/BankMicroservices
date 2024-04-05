using BankServices.Models;
using BankServices.Service.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BankServices.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;
		private readonly ITokenProvider _tokenProvider;

		public AuthController(IAuthService authService, ITokenProvider tokenProvider)
		{
			_authService = authService;
			_tokenProvider = tokenProvider;
		}

		[HttpGet]
		public IActionResult Login()
		{
			LoginRequestDTO loginRequestDto = new();
			return View(loginRequestDto);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginRequestDTO obj)
		{
			ResponseDTO responseDto = await _authService.LoginAsync(obj);

			if (responseDto != null && responseDto.IsSuccess)
			{
				LoginResponseDTO loginResponseDto =
					JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(responseDto.Result));

				await SignInUser(loginResponseDto);
				_tokenProvider.SetToken(loginResponseDto.Token);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				TempData["error"] = responseDto.Message;
				return View(obj);
			}
		}



        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestDTO obj)
        {
            ResponseDTO result = await _authService.RegisterAsync(obj);

            if (result != null && result.IsSuccess)
            {
               
                    TempData["success"] = "Registration Successful";
                    return RedirectToAction(nameof(Login));
       
            }
            else
            {
                TempData["error"] = result.Message;
            }
            return View(obj);
        }


        public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			_tokenProvider.ClearToken();
			return RedirectToAction("Index", "Home");
		}


		private async Task SignInUser(LoginResponseDTO model)
		{
			var handler = new JwtSecurityTokenHandler();

			var jwt = handler.ReadJwtToken(model.Token);

			var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
			identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
				jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
			identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
				jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
			identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
				jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));


			identity.AddClaim(new Claim(ClaimTypes.Name,
				jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
	

			var principal = new ClaimsPrincipal(identity);
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
		}

	}
}
