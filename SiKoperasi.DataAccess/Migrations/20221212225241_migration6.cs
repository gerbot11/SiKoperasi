using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoregeUrl",
                table: "MembersDocument",
                newName: "FileUrl");

            migrationBuilder.CreateTable(
                name: "LoanDocument",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DocumentExt = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(3000)", nullable: false),
                    UsrCrt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanDocument_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanDocument_LoanId",
                table: "LoanDocument",
                column: "LoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanDocument");

            migrationBuilder.RenameColumn(
                name: "FileUrl",
                table: "MembersDocument",
                newName: "StoregeUrl");
        }
    }
}
