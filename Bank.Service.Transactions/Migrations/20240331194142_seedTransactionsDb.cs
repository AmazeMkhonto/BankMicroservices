using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bank.Service.Transactions.Migrations
{
    /// <inheritdoc />
    public partial class seedTransactionsDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountType", "Amount", "BankAccountId", "TransactionType" },
                values: new object[,]
                {
                    { 1, "Cheque", 0.00m, 1000000003L, "Withdrawal" },
                    { 2, "Cheque", 50.00m, 1000000004L, "Withdrawal" },
                    { 3, "Savings", 100.00m, 1000000005L, "Deposit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
