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
                 new Accounts() { AccountType = "Cheque", Name = "John Doe's Account", Status = "Active", AvailableBalance = 500.00M, AccountHolderId = 1 },
                new Accounts() { AccountType = "Savings", Name = "Jane Smith's Account", Status = "Active", AvailableBalance = 1000.00M, AccountHolderId = 2 }

        );


        }



    }
}
