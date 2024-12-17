using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIsActiveField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 17, 17, 0, 41, 65, DateTimeKind.Utc).AddTicks(7768), "$2a$11$wklEzO1dxjqeTZYrK1vmQeuSYZDtRo2HXi7BKSiZjMd7AjisLuo3q" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 17, 16, 6, 8, 927, DateTimeKind.Utc).AddTicks(5599), "$2a$11$uc8ixRfXWhrhhVyf6bNHbe3/ax04bnv5CAy0Nt/aSmfNzlcH0BNK." });
        }
    }
}
