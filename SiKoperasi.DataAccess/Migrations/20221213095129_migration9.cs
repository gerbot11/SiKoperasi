using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PayAmount",
                table: "InstalmentSchedules",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayAmount",
                table: "InstalmentSchedules");
        }
    }
}
