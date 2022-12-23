using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSavingDefault",
                table: "CashBankAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSavingDefault",
                table: "CashBankAccounts");
        }
    }
}
