using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavingTransaction_Savings_SavingId",
                table: "SavingTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavingTransaction",
                table: "SavingTransaction");

            migrationBuilder.DropColumn(
                name: "SavingType",
                table: "Savings");

            migrationBuilder.RenameTable(
                name: "SavingTransaction",
                newName: "SavingTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_SavingTransaction_SavingId",
                table: "SavingTransactions",
                newName: "IX_SavingTransactions_SavingId");

            migrationBuilder.AddColumn<string>(
                name: "RefSavingTypeId",
                table: "Savings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavingTransactions",
                table: "SavingTransactions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RefSavingTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SavingName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MinimalAmountDeposit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CutAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UsrCrt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefSavingTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Savings_RefSavingTypeId",
                table: "Savings",
                column: "RefSavingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_RefSavingTypes_RefSavingTypeId",
                table: "Savings",
                column: "RefSavingTypeId",
                principalTable: "RefSavingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavingTransactions_Savings_SavingId",
                table: "SavingTransactions",
                column: "SavingId",
                principalTable: "Savings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Savings_RefSavingTypes_RefSavingTypeId",
                table: "Savings");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingTransactions_Savings_SavingId",
                table: "SavingTransactions");

            migrationBuilder.DropTable(
                name: "RefSavingTypes");

            migrationBuilder.DropIndex(
                name: "IX_Savings_RefSavingTypeId",
                table: "Savings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavingTransactions",
                table: "SavingTransactions");

            migrationBuilder.DropColumn(
                name: "RefSavingTypeId",
                table: "Savings");

            migrationBuilder.RenameTable(
                name: "SavingTransactions",
                newName: "SavingTransaction");

            migrationBuilder.RenameIndex(
                name: "IX_SavingTransactions_SavingId",
                table: "SavingTransaction",
                newName: "IX_SavingTransaction_SavingId");

            migrationBuilder.AddColumn<string>(
                name: "SavingType",
                table: "Savings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavingTransaction",
                table: "SavingTransaction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingTransaction_Savings_SavingId",
                table: "SavingTransaction",
                column: "SavingId",
                principalTable: "Savings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
