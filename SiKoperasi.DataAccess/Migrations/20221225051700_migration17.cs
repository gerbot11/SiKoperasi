using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUseGuarantee",
                table: "LoanSchemes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LoanPurpose",
                table: "Loans",
                type: "nvarchar(1500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobDepartment",
                table: "Jobs",
                type: "nvarchar(100)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUseGuarantee",
                table: "LoanSchemes");

            migrationBuilder.DropColumn(
                name: "LoanPurpose",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "JobDepartment",
                table: "Jobs");
        }
    }
}
