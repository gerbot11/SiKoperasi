using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class appMig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApvScheme",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ApvType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsrCrt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApvScheme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApvReq",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrxNo = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ApvSchemeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApvStatus = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    ResultNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsrCrt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApvReq", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApvReq_ApvScheme_ApvSchemeId",
                        column: x => x.ApvSchemeId,
                        principalTable: "ApvScheme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApvSchemeNode",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApvSchemeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserRoleCode = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    UsrCrt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApvSchemeNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApvSchemeNode_ApvScheme_ApvSchemeId",
                        column: x => x.ApvSchemeId,
                        principalTable: "ApvScheme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApvReqTask",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApvReqId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    ProcessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    ApvSeq = table.Column<int>(type: "int", nullable: false),
                    UsrCrt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApvReqTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApvReqTask_ApvReq_ApvReqId",
                        column: x => x.ApvReqId,
                        principalTable: "ApvReq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApvReq_ApvSchemeId",
                table: "ApvReq",
                column: "ApvSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApvReqTask_ApvReqId",
                table: "ApvReqTask",
                column: "ApvReqId");

            migrationBuilder.CreateIndex(
                name: "IX_ApvSchemeNode_ApvSchemeId",
                table: "ApvSchemeNode",
                column: "ApvSchemeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApvReqTask");

            migrationBuilder.DropTable(
                name: "ApvSchemeNode");

            migrationBuilder.DropTable(
                name: "ApvReq");

            migrationBuilder.DropTable(
                name: "ApvScheme");
        }
    }
}
