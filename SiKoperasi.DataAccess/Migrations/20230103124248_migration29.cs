using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationLoan_Loans_LoanId",
                table: "ShuAllocationLoan");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationLoan_ShuAllocationTrxDist_ShuAllocationTrxDistId",
                table: "ShuAllocationLoan");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationTrxDist_ShuAllocationTrxes_ShuAllocationTrxId",
                table: "ShuAllocationTrxDist");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationTrxDist_ShuAllocations_ShuAllocationId",
                table: "ShuAllocationTrxDist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShuAllocationTrxDist",
                table: "ShuAllocationTrxDist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShuAllocationLoan",
                table: "ShuAllocationLoan");

            migrationBuilder.RenameTable(
                name: "ShuAllocationTrxDist",
                newName: "ShuAllocationTrxDists");

            migrationBuilder.RenameTable(
                name: "ShuAllocationLoan",
                newName: "ShuAllocationLoans");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationTrxDist_ShuAllocationTrxId",
                table: "ShuAllocationTrxDists",
                newName: "IX_ShuAllocationTrxDists_ShuAllocationTrxId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationTrxDist_ShuAllocationId",
                table: "ShuAllocationTrxDists",
                newName: "IX_ShuAllocationTrxDists_ShuAllocationId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationLoan_ShuAllocationTrxDistId",
                table: "ShuAllocationLoans",
                newName: "IX_ShuAllocationLoans_ShuAllocationTrxDistId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationLoan_LoanId",
                table: "ShuAllocationLoans",
                newName: "IX_ShuAllocationLoans_LoanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShuAllocationTrxDists",
                table: "ShuAllocationTrxDists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShuAllocationLoans",
                table: "ShuAllocationLoans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationLoans_Loans_LoanId",
                table: "ShuAllocationLoans",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationLoans_ShuAllocationTrxDists_ShuAllocationTrxDistId",
                table: "ShuAllocationLoans",
                column: "ShuAllocationTrxDistId",
                principalTable: "ShuAllocationTrxDists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationTrxDists_ShuAllocationTrxes_ShuAllocationTrxId",
                table: "ShuAllocationTrxDists",
                column: "ShuAllocationTrxId",
                principalTable: "ShuAllocationTrxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationTrxDists_ShuAllocations_ShuAllocationId",
                table: "ShuAllocationTrxDists",
                column: "ShuAllocationId",
                principalTable: "ShuAllocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationLoans_Loans_LoanId",
                table: "ShuAllocationLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationLoans_ShuAllocationTrxDists_ShuAllocationTrxDistId",
                table: "ShuAllocationLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationTrxDists_ShuAllocationTrxes_ShuAllocationTrxId",
                table: "ShuAllocationTrxDists");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationTrxDists_ShuAllocations_ShuAllocationId",
                table: "ShuAllocationTrxDists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShuAllocationTrxDists",
                table: "ShuAllocationTrxDists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShuAllocationLoans",
                table: "ShuAllocationLoans");

            migrationBuilder.RenameTable(
                name: "ShuAllocationTrxDists",
                newName: "ShuAllocationTrxDist");

            migrationBuilder.RenameTable(
                name: "ShuAllocationLoans",
                newName: "ShuAllocationLoan");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationTrxDists_ShuAllocationTrxId",
                table: "ShuAllocationTrxDist",
                newName: "IX_ShuAllocationTrxDist_ShuAllocationTrxId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationTrxDists_ShuAllocationId",
                table: "ShuAllocationTrxDist",
                newName: "IX_ShuAllocationTrxDist_ShuAllocationId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationLoans_ShuAllocationTrxDistId",
                table: "ShuAllocationLoan",
                newName: "IX_ShuAllocationLoan_ShuAllocationTrxDistId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationLoans_LoanId",
                table: "ShuAllocationLoan",
                newName: "IX_ShuAllocationLoan_LoanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShuAllocationTrxDist",
                table: "ShuAllocationTrxDist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShuAllocationLoan",
                table: "ShuAllocationLoan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationLoan_Loans_LoanId",
                table: "ShuAllocationLoan",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationLoan_ShuAllocationTrxDist_ShuAllocationTrxDistId",
                table: "ShuAllocationLoan",
                column: "ShuAllocationTrxDistId",
                principalTable: "ShuAllocationTrxDist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationTrxDist_ShuAllocationTrxes_ShuAllocationTrxId",
                table: "ShuAllocationTrxDist",
                column: "ShuAllocationTrxId",
                principalTable: "ShuAllocationTrxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationTrxDist_ShuAllocations_ShuAllocationId",
                table: "ShuAllocationTrxDist",
                column: "ShuAllocationId",
                principalTable: "ShuAllocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
