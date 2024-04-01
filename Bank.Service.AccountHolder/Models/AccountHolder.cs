using System.ComponentModel.DataAnnotations;

namespace Bank.Service.AccountHolder.Models
{
    public class AccountHolders
    {
            [Key]
            public int Id { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public DateTime DateOfBirth { get; set; }
            [Required]
            public string IdNumber { get; set; }
            public string ResidentialAddress { get; set; }
            [Required]
            public string MobileNumber { get; set; }
            public string EmailAddress { get; set; }
    }
}
