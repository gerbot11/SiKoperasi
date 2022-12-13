using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Savings");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Savings",
                newName: "TotalAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "CutAmount",
                table: "Savings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "EffectiveDate",
                table: "Loans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LoanDueNum",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SavingTransaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SavingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrNo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TrDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrMethod = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsrCrt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingTransaction_Savings_SavingId",
                        column: x => x.SavingId,
                        principalTable: "Savings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavingTransaction_SavingId",
                table: "SavingTransaction",
                column: "SavingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavingTransaction");

            migrationBuilder.DropColumn(
                name: "CutAmount",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "EffectiveDate",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "LoanDueNum",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Savings",
                newName: "Amount");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "Savings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                table: "Savings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
