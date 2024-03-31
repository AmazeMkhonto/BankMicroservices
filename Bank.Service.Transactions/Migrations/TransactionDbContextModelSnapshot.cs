﻿// <auto-generated />
using Bank.Service.Transactions.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank.Service.Transactions.Migrations
{
    [DbContext(typeof(TransactionDbContext))]
    partial class TransactionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bank.Service.Transactions.Models.Transactionss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("BankAccountId")
                        .HasColumnType("bigint");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountType = "Cheque",
                            Amount = 0.00m,
                            BankAccountId = 1000000003L,
                            TransactionType = "Withdrawal"
                        },
                        new
                        {
                            Id = 2,
                            AccountType = "Cheque",
                            Amount = 50.00m,
                            BankAccountId = 1000000004L,
                            TransactionType = "Withdrawal"
                        },
                        new
                        {
                            Id = 3,
                            AccountType = "Savings",
                            Amount = 100.00m,
                            BankAccountId = 1000000005L,
                            TransactionType = "Deposit"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
