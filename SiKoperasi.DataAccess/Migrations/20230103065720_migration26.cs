﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyDepositAmount",
                table: "Savings",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlyDepositAmount",
                table: "Savings");
        }
    }
}
