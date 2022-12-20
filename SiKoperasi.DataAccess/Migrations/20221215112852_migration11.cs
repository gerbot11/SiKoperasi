using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentExt",
                table: "LoanDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "LoanDocuments");

            migrationBuilder.RenameColumn(
                name: "TrNo",
                table: "SavingTransactions",
                newName: "TrxNo");

            migrationBuilder.RenameColumn(
                name: "TrMethod",
                table: "SavingTransactions",
                newName: "TrxMethod");

            migrationBuilder.RenameColumn(
                name: "TrDate",
                table: "SavingTransactions",
                newName: "TrxDate");

            migrationBuilder.RenameColumn(
                name: "DocumentType",
                table: "LoanDocuments",
                newName: "FileName");

            migrationBuilder.AddColumn<string>(
                name: "TrxType",
                table: "SavingTransactions",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "FileUrl",
                table: "LoanDocuments",
                type: "nvarchar(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FileExt",
                table: "LoanDocuments",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileSize",
                table: "LoanDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefLoanDocumentId",
                table: "LoanDocuments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RefLoanDocuments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    AcceptedFileExt = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    MaxFileSize = table.Column<int>(type: "int", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UsrCrt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefLoanDocuments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanDocuments_RefLoanDocumentId",
                table: "LoanDocuments",
                column: "RefLoanDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanDocuments_RefLoanDocuments_RefLoanDocumentId",
                table: "LoanDocuments",
                column: "RefLoanDocumentId",
                principalTable: "RefLoanDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanDocuments_RefLoanDocuments_RefLoanDocumentId",
                table: "LoanDocuments");

            migrationBuilder.DropTable(
                name: "RefLoanDocuments");

            migrationBuilder.DropIndex(
                name: "IX_LoanDocuments_RefLoanDocumentId",
                table: "LoanDocuments");

            migrationBuilder.DropColumn(
                name: "TrxType",
                table: "SavingTransactions");

            migrationBuilder.DropColumn(
                name: "FileExt",
                table: "LoanDocuments");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "LoanDocuments");

            migrationBuilder.DropColumn(
                name: "RefLoanDocumentId",
                table: "LoanDocuments");

            migrationBuilder.RenameColumn(
                name: "TrxNo",
                table: "SavingTransactions",
                newName: "TrNo");

            migrationBuilder.RenameColumn(
                name: "TrxMethod",
                table: "SavingTransactions",
                newName: "TrMethod");

            migrationBuilder.RenameColumn(
                name: "TrxDate",
                table: "SavingTransactions",
                newName: "TrDate");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "LoanDocuments",
                newName: "DocumentType");

            migrationBuilder.AlterColumn<string>(
                name: "FileUrl",
                table: "LoanDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentExt",
                table: "LoanDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "LoanDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
