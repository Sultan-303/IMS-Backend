using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTestColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 27, 19, 51, 55, 593, DateTimeKind.Utc).AddTicks(7638), "$2a$11$S0ZyqPPqG4Bs1vTZu0efC.0at286xGsVjmw353IQmvTtdOfbPrkx." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 27, 18, 39, 59, 581, DateTimeKind.Utc).AddTicks(6021), "$2a$11$4uqBKUpzNrJbVVBD.HWgg.B3soFqXNddxLhQHtxDgHqweEkOTDiiC" });
        }
    }
}
