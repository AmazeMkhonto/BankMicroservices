namespace Bank.Service.Auth.Models
{
	public class JWToptions
	{
		public string Issuer { get; set; } = string.Empty;

		public string Audience { get; set; } = string.Empty;

		public string Secret { get; set; } = string.Empty;
	}
}
