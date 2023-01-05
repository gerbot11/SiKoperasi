using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class appMig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResultNotes",
                table: "ApvReq");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessDate",
                table: "ApvReqTask",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApproveDate",
                table: "ApvReqTask",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultNotes",
                table: "ApvReqTask",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "ApvReq",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproveDate",
                table: "ApvReqTask");

            migrationBuilder.DropColumn(
                name: "ResultNotes",
                table: "ApvReqTask");

            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "ApvReq");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessDate",
                table: "ApvReqTask",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultNotes",
                table: "ApvReq",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
