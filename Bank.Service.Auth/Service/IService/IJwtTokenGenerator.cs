using Bank.Service.Auth.Models;

namespace Bank.Service.Auth.Service.IService
{
	public interface IJwtTokenGenerator
	{
		string GenerateToken(ApplicationUser applicationUser);
	}
}
