using System.ComponentModel.DataAnnotations;

namespace Bank.Service.AccountHolder.Models
{
    public class AccountHolder
    {
      
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            [Required]
            public string IdNumber { get; set; }
            public string ResidentialAddress { get; set; }
            public string MobileNumber { get; set; }
            [Required]
            public string EmailAddress { get; set; }

            // You can add a collection of BankAccounts if relevant to your design
            //public ICollection<BankAccount> BankAccounts { get; set; }
        
    }
}
