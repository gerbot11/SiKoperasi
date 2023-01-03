using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Loans_MemberId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "TrxDate",
                table: "CashBankTrxes");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeNo",
                table: "Members",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MartialStat",
                table: "Members",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CashBankTrxes",
                type: "nvarchar(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrxNo",
                table: "CashBankTrxes",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_MemberId",
                table: "Loans",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Loans_MemberId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "EmployeeNo",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MartialStat",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CashBankTrxes");

            migrationBuilder.DropColumn(
                name: "TrxNo",
                table: "CashBankTrxes");

            migrationBuilder.AddColumn<DateTime>(
                name: "TrxDate",
                table: "CashBankTrxes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Loans_MemberId",
                table: "Loans",
                column: "MemberId",
                unique: true);
        }
    }
}
