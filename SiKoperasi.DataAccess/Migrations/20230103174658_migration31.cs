using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationTrx_ShuAllocation_ShuAllocationId",
                table: "ShuAllocationTrx");

            migrationBuilder.DropTable(
                name: "ShuAllocationLoan");

            migrationBuilder.DropIndex(
                name: "IX_ShuAllocationTrx_ShuAllocationId",
                table: "ShuAllocationTrx");

            migrationBuilder.DropColumn(
                name: "ShuAllocationId",
                table: "ShuAllocationTrx");

            migrationBuilder.CreateTable(
                name: "ShuAllocationMember",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShuAllocationTrxDistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MemberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AllocationAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AllocationPrcnt = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UsrCrt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShuAllocationMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShuAllocationMember_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShuAllocationMember_ShuAllocationTrxDist_ShuAllocationTrxDistId",
                        column: x => x.ShuAllocationTrxDistId,
                        principalTable: "ShuAllocationTrxDist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShuAllocationMember_MemberId",
                table: "ShuAllocationMember",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ShuAllocationMember_ShuAllocationTrxDistId",
                table: "ShuAllocationMember",
                column: "ShuAllocationTrxDistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShuAllocationMember");

            migrationBuilder.AddColumn<string>(
                name: "ShuAllocationId",
                table: "ShuAllocationTrx",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShuAllocationLoan",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShuAllocationTrxDistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AllocationAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AllocationPrcnt = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrCrt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShuAllocationLoan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShuAllocationLoan_Loan_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan",
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
                name: "IX_ShuAllocationTrx_ShuAllocationId",
                table: "ShuAllocationTrx",
                column: "ShuAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShuAllocationLoan_LoanId",
                table: "ShuAllocationLoan",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_ShuAllocationLoan_ShuAllocationTrxDistId",
                table: "ShuAllocationLoan",
                column: "ShuAllocationTrxDistId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationTrx_ShuAllocation_ShuAllocationId",
                table: "ShuAllocationTrx",
                column: "ShuAllocationId",
                principalTable: "ShuAllocation",
                principalColumn: "Id");
        }
    }
}
