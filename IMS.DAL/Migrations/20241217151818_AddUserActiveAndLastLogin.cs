using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserActiveAndLastLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsActive", "LastLogin", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 17, 15, 18, 18, 118, DateTimeKind.Utc).AddTicks(7724), true, null, "$2a$11$V.KcsHW93JpUokmFNithseKjswiIi7rWY6u1b4ZWstVM6JM5E0jWu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 17, 14, 55, 48, 15, DateTimeKind.Utc).AddTicks(6098), "$2a$11$j0b//8OhaglewulRGzGs3.rTCFh3qgrQQKk/De3iNLz7vIYB6ym3i" });
        }
    }
}
