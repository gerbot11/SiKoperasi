using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanGuarantees_Loans_LoanId",
                table: "LoanGuarantees");

            migrationBuilder.AddColumn<DateTime>(
                name: "GoLiveDate",
                table: "Loans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextDueDate",
                table: "Loans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoanId",
                table: "LoanGuarantees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanGuarantees_Loans_LoanId",
                table: "LoanGuarantees",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanGuarantees_Loans_LoanId",
                table: "LoanGuarantees");

            migrationBuilder.DropColumn(
                name: "GoLiveDate",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "NextDueDate",
                table: "Loans");

            migrationBuilder.AlterColumn<string>(
                name: "LoanId",
                table: "LoanGuarantees",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanGuarantees_Loans_LoanId",
                table: "LoanGuarantees",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id");
        }
    }
}
