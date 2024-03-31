using Bank.Service.Transactions.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Bank.Service.Transactions.Data
{
    public class TransactionDbContext : DbContext
    {

        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
         : base(options)
        {
        }

        public DbSet<Transactionss> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transactionss>().HasData(
                 new Transactionss()
                 {
                     Id = 1,
                     BankAccountId = 1000000003,
                     AccountType = "Cheque",
                     TransactionType = "Withdrawal",
                     Amount = 0.00m
                 },

                new Transactionss()
                {
                    Id = 2,
                    BankAccountId = 1000000004, 
                    AccountType = "Cheque",
                    TransactionType = "Withdrawal",
                    Amount = 50.00m
                },

                 new Transactionss()
                 {
                     Id = 3,
                     BankAccountId = 1000000005,
                     AccountType = "Savings",
                     TransactionType = "Deposit",
                     Amount = 100.00m
                 }

            );
        }


    }
}
