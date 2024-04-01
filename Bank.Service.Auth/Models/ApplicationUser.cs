using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bank.Service.Auth.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string IdNumber { get; set; }
		public string ResidentialAddress { get; set; }
	}
}
