namespace BankServices.Models
{
	public class RegisterRequestDTO
	{
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Password { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string IdNumber { get; set; }
		public string ResidentialAddress { get; set; }


	}
}
