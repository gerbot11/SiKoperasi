using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShuAllocations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShuName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Descr = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    AllocationAmt = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsExpense = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UsrCrt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShuAllocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShuAllocationTrxes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShuAllocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrxNo = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TrxDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllocationAmt = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AllocationPrcnt = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UsrCrt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShuAllocationTrxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShuAllocationTrxes_ShuAllocations_ShuAllocationId",
                        column: x => x.ShuAllocationId,
                        principalTable: "ShuAllocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShuAllocationTrxes_ShuAllocationId",
                table: "ShuAllocationTrxes",
                column: "ShuAllocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShuAllocationTrxes");

            migrationBuilder.DropTable(
                name: "ShuAllocations");
        }
    }
}
