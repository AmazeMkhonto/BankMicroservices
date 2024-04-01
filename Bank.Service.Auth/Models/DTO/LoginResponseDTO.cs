namespace Bank.Service.Auth.Models.DTO
{
	public class LoginResponseDTO
	{
		public ApplicationUserDTO User { get; set; }
		public string Token { get; set; }
	}
}
