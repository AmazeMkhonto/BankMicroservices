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

       

    }
}
