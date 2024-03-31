using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bank.Service.Account.Migrations
{
    /// <inheritdoc />
    public partial class SeedAccountsDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountHolderId", "AccountType", "AvailableBalance", "Name", "Status" },
                values: new object[,]
                {
                    { 1000000003L, 1, "Cheque", 500.00m, "John Doe's Account", "Active" },
                    { 1000000004L, 2, "Savings", 1000.00m, "Jane Smith's Account", "Active" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1000000003L);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1000000004L);
        }
    }
}
