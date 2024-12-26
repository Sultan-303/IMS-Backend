using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IHATEMIGRATIONS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 35, 24, 665, DateTimeKind.Utc).AddTicks(8771), "$2a$11$xaE/9i78fd7Hwle8ojwyLej9CXCul2GpDxJ0IAtOMMp8dfYg90kDy" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 17, 17, 0, 41, 65, DateTimeKind.Utc).AddTicks(7768), "$2a$11$wklEzO1dxjqeTZYrK1vmQeuSYZDtRo2HXi7BKSiZjMd7AjisLuo3q" });
        }
    }
}
