using Bank.Service.Account.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank.Service.Account.Data
{
    public class AccountDbContext : DbContext
    {

        public AccountDbContext(DbContextOptions<AccountDbContext> options)
           : base(options)
        {
        }

        public DbSet<Accounts> Accounts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>().HasData(
                 new Accounts() { AccountType = "Cheque", Name = "John Doe's Account", Status = "Active", AvailableBalance = 500.00M, AccountHolderId = "37f65fd1-4adf-4e70-b152-1e91625ac26d" },
                new Accounts() { AccountType = "Savings", Name = "Jane Smith's Account", Status = "Active", AvailableBalance = 1000.00M, AccountHolderId = "77d2e3ab-469d-469a-b6b9-be14a8ba5a51" }

        );


        }



    }
}
