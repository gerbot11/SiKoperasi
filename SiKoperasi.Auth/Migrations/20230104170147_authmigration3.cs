﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.Auth.Migrations
{
    /// <inheritdoc />
    public partial class authmigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "User");
        }
    }
}
