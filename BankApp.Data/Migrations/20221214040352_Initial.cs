using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransitNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbaRoutingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    BalanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.BalanceId);
                    table.ForeignKey(
                        name: "FK_Balances_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactions",
                columns: table => new
                {
                    BankTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactions", x => x.BankTransactionId);
                    table.ForeignKey(
                        name: "FK_BankTransactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankTransactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AbaRoutingNumber", "AccountName", "AccountNumber", "AccountType", "BankNumber", "SwiftCode", "TransitNumber" },
                values: new object[,]
                {
                    { 1, null, "Personal", null, 1, null, null, null },
                    { 2, null, "Visa", null, 2, null, null, null },
                    { 3, null, "MasterCard", null, 2, null, null, null },
                    { 4, null, "Corporate", null, 1, null, null, null },
                    { 5, null, "Corporate MasterCard", null, 2, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Car Insurance" },
                    { 2, "Car Lease" },
                    { 3, "Car Repair" },
                    { 4, "Computer" },
                    { 5, "Electricity" },
                    { 6, "Gas" },
                    { 7, "Home Insurance" },
                    { 8, "Internet" },
                    { 9, "Medical" },
                    { 10, "Office Furniture" },
                    { 11, "Office Supplies" },
                    { 12, "Parking" },
                    { 13, "Phone" },
                    { 14, "Rent" },
                    { 15, "Salary" },
                    { 16, "Dividend" },
                    { 17, "Tuition" }
                });

            migrationBuilder.InsertData(
                table: "BankTransactions",
                columns: new[] { "BankTransactionId", "AccountId", "Amount", "CategoryId", "Date", "Description", "Location", "TransactionType" },
                values: new object[,]
                {
                    { 1, 1, 3000.00m, 14, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rent", "Building", 1 },
                    { 2, 3, 500.00m, 9, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Filling", "Dentist", 1 },
                    { 3, 1, 100.00m, 13, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone", "Fido", 1 },
                    { 4, 1, 100.00m, 8, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internet", "Telus", 1 },
                    { 5, 1, 100.00m, 5, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heat", "BCHydro", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountName",
                table: "Accounts",
                column: "AccountName");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_AccountId",
                table: "Balances",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_AccountId",
                table: "BankTransactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_CategoryId",
                table: "BankTransactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_Description",
                table: "BankTransactions",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_Location",
                table: "BankTransactions",
                column: "Location");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropTable(
                name: "BankTransactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
