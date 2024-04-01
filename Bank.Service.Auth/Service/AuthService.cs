using Bank.Service.Auth.Data;
using Bank.Service.Auth.Models;
using Bank.Service.Auth.Models.DTO;
using Bank.Service.Auth.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace Bank.Service.Auth.Service
{
	public class AuthService : IAuthService
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AuthService(ApplicationDbContext db,
			UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_db = db;
			_userManager = userManager;
			_roleManager = roleManager;
		}


		public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto)
		{
			var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

			bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

			if (user == null || isValid == false)
			{
				return new LoginResponseDTO() { User = null, Token = "" };
			}

			//if user was found , Generate JWT Token
			//var roles = await _userManager.GetRolesAsync(user);
			//var token = _jwtTokenGenerator.GenerateToken(user, roles);

			ApplicationUserDTO userDTO = new()
			{
				Email = user.Email,
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				PhoneNumber = user.PhoneNumber,
				DateOfBirth = user.DateOfBirth,
				IdNumber = user.IdNumber,
				ResidentialAddress = user.ResidentialAddress
			};

			LoginResponseDTO loginResponseDto = new LoginResponseDTO()
			{
				User = userDTO
				//Token = token
			};

			return loginResponseDto;
		}

		
		public async Task<string> Register(RegisterRequestDTO registerRequestDto)
		{
			ApplicationUser user = new()
			{
				UserName = registerRequestDto.Email,
				Email = registerRequestDto.Email,
				NormalizedEmail = registerRequestDto.Email.ToUpper(),
				FirstName = registerRequestDto.FirstName,
				LastName = registerRequestDto.LastName,
				PhoneNumber = registerRequestDto.PhoneNumber,
				DateOfBirth = registerRequestDto.DateOfBirth,
				IdNumber = registerRequestDto.IdNumber,
				ResidentialAddress = registerRequestDto.ResidentialAddress
			};

			try
			{
				var result = await _userManager.CreateAsync(user, registerRequestDto.Password);
				if (result.Succeeded)
				{
					var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registerRequestDto.Email);

					ApplicationUserDTO userDto = new()
					{
						Email = userToReturn.Email,
						Id = userToReturn.Id,
						FirstName = userToReturn.FirstName,
						LastName = userToReturn.LastName,
						PhoneNumber = userToReturn.PhoneNumber,
						DateOfBirth = userToReturn.DateOfBirth,
						IdNumber = userToReturn.IdNumber,
						ResidentialAddress = userToReturn.ResidentialAddress

					};

					return "";

				}
				else
				{
					return result.Errors.FirstOrDefault().Description;
				}

			}
			catch (Exception ex)
			{

			}
			return "Error Encountered";
		}
	}
	
}
