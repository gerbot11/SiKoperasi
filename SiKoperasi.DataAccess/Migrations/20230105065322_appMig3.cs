using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class appMig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApvSchemeNodeId",
                table: "ApvReqTask",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ApvReqTask_ApvSchemeNodeId",
                table: "ApvReqTask",
                column: "ApvSchemeNodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApvReqTask_ApvSchemeNode_ApvSchemeNodeId",
                table: "ApvReqTask",
                column: "ApvSchemeNodeId",
                principalTable: "ApvSchemeNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApvReqTask_ApvSchemeNode_ApvSchemeNodeId",
                table: "ApvReqTask");

            migrationBuilder.DropIndex(
                name: "IX_ApvReqTask_ApvSchemeNodeId",
                table: "ApvReqTask");

            migrationBuilder.DropColumn(
                name: "ApvSchemeNodeId",
                table: "ApvReqTask");
        }
    }
}
