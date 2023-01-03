using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationTrxes_ShuAllocations_ShuAllocationId",
                table: "ShuAllocationTrxes");

            migrationBuilder.DropColumn(
                name: "AllocationAmt",
                table: "ShuAllocationTrxes");

            migrationBuilder.RenameColumn(
                name: "AllocationPrcnt",
                table: "ShuAllocationTrxes",
                newName: "TotalAllocation");

            migrationBuilder.AlterColumn<string>(
                name: "ShuAllocationId",
                table: "ShuAllocationTrxes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "YearPeriod",
                table: "ShuAllocationTrxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShuAllocationTrxDist",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShuAllocationTrxId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShuAllocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AllocationAmt = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AllocationPrcnt = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UsrCrt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShuAllocationTrxDist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShuAllocationTrxDist_ShuAllocationTrxes_ShuAllocationTrxId",
                        column: x => x.ShuAllocationTrxId,
                        principalTable: "ShuAllocationTrxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShuAllocationTrxDist_ShuAllocations_ShuAllocationId",
                        column: x => x.ShuAllocationId,
                        principalTable: "ShuAllocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShuAllocationLoan",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShuAllocationTrxDistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AllocationAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AllocationPrcnt = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UsrCrt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShuAllocationLoan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShuAllocationLoan_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShuAllocationLoan_ShuAllocationTrxDist_ShuAllocationTrxDistId",
                        column: x => x.ShuAllocationTrxDistId,
                        principalTable: "ShuAllocationTrxDist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShuAllocationLoan_LoanId",
                table: "ShuAllocationLoan",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_ShuAllocationLoan_ShuAllocationTrxDistId",
                table: "ShuAllocationLoan",
                column: "ShuAllocationTrxDistId");

            migrationBuilder.CreateIndex(
                name: "IX_ShuAllocationTrxDist_ShuAllocationId",
                table: "ShuAllocationTrxDist",
                column: "ShuAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShuAllocationTrxDist_ShuAllocationTrxId",
                table: "ShuAllocationTrxDist",
                column: "ShuAllocationTrxId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationTrxes_ShuAllocations_ShuAllocationId",
                table: "ShuAllocationTrxes",
                column: "ShuAllocationId",
                principalTable: "ShuAllocations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationTrxes_ShuAllocations_ShuAllocationId",
                table: "ShuAllocationTrxes");

            migrationBuilder.DropTable(
                name: "ShuAllocationLoan");

            migrationBuilder.DropTable(
                name: "ShuAllocationTrxDist");

            migrationBuilder.DropColumn(
                name: "YearPeriod",
                table: "ShuAllocationTrxes");

            migrationBuilder.RenameColumn(
                name: "TotalAllocation",
                table: "ShuAllocationTrxes",
                newName: "AllocationPrcnt");

            migrationBuilder.AlterColumn<string>(
                name: "ShuAllocationId",
                table: "ShuAllocationTrxes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AllocationAmt",
                table: "ShuAllocationTrxes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationTrxes_ShuAllocations_ShuAllocationId",
                table: "ShuAllocationTrxes",
                column: "ShuAllocationId",
                principalTable: "ShuAllocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
