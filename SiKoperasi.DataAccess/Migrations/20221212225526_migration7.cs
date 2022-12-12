using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanDocument_Loans_LoanId",
                table: "LoanDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanDocument",
                table: "LoanDocument");

            migrationBuilder.RenameTable(
                name: "LoanDocument",
                newName: "LoanDocuments");

            migrationBuilder.RenameIndex(
                name: "IX_LoanDocument_LoanId",
                table: "LoanDocuments",
                newName: "IX_LoanDocuments_LoanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanDocuments",
                table: "LoanDocuments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanDocuments_Loans_LoanId",
                table: "LoanDocuments",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanDocuments_Loans_LoanId",
                table: "LoanDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanDocuments",
                table: "LoanDocuments");

            migrationBuilder.RenameTable(
                name: "LoanDocuments",
                newName: "LoanDocument");

            migrationBuilder.RenameIndex(
                name: "IX_LoanDocuments_LoanId",
                table: "LoanDocument",
                newName: "IX_LoanDocument_LoanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanDocument",
                table: "LoanDocument",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanDocument_Loans_LoanId",
                table: "LoanDocument",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
