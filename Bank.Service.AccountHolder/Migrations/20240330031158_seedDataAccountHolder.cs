using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bank.Service.AccountHolder.Migrations
{
    /// <inheritdoc />
    public partial class seedDataAccountHolder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountHolders",
                columns: new[] { "Id", "DateOfBirth", "EmailAddress", "FirstName", "IdNumber", "LastName", "MobileNumber", "ResidentialAddress" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "8001010000000", "Doe", "0123456789", "123 Main Street, Cape Town" },
                    { 2, new DateTime(1995, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "7503150000000", "Smith", "987654321", "456 Pine Avenue, Johannesburg" },
                    { 3, new DateTime(1960, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.jones@example.com", "Michael", "6007010000000", "Jones", "0009876543", "789 Oak Lane, Durban" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountHolders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountHolders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccountHolders",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
