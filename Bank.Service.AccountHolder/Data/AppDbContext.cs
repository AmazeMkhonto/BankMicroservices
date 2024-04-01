using Microsoft.EntityFrameworkCore;
using Bank.Service.AccountHolder.Models;

namespace Bank.Service.AccountHolder.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<AccountHolders> AccountHolders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountHolders>().HasData(
                new AccountHolders
                {
                    Id=1,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1980, 01, 01),
                    IdNumber = "8001010000000", // Placeholder ID number
                    ResidentialAddress = "123 Main Street, Cape Town",
                    MobileNumber = "0123456789",
                    EmailAddress = "john.doe@example.com"
                },
                new AccountHolders
                {
                    Id=2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1995, 03, 15),
                    IdNumber = "7503150000000", // Placeholder ID number
                    ResidentialAddress = "456 Pine Avenue, Johannesburg",
                    MobileNumber = "987654321",
                    EmailAddress = "jane.smith@example.com"
                },
                new AccountHolders
                {
                    Id=3,
                    FirstName = "Michael",
                    LastName = "Jones",
                    DateOfBirth = new DateTime(1960, 07, 01),
                    IdNumber = "6007010000000", // Placeholder ID number
                    ResidentialAddress = "789 Oak Lane, Durban",
                    MobileNumber = "0009876543",
                    EmailAddress = "michael.jones@example.com"
            } );

        }
    }
}
