﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBFirst.Migrations
{
    /// <inheritdoc />
    public partial class fistClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "teachers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "teachers");
        }
    }
}
