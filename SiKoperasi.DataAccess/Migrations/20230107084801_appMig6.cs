using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class appMig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkerSetting",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RunningInterval = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntervalValue = table.Column<int>(type: "int", nullable: false),
                    UsrCrt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtmCrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUpd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtmUpd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerSetting", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkerSetting");
        }
    }
}
