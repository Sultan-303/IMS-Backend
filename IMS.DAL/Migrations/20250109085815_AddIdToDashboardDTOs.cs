using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddIdToDashboardDTOs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 8, 8, 58, 15, 400, DateTimeKind.Utc).AddTicks(6861), new DateTime(2025, 1, 14, 8, 58, 15, 400, DateTimeKind.Utc).AddTicks(6624) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 9, 6, 58, 15, 400, DateTimeKind.Utc).AddTicks(7036), new DateTime(2025, 2, 8, 8, 58, 15, 400, DateTimeKind.Utc).AddTicks(7036) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2024, 12, 30, 8, 58, 15, 400, DateTimeKind.Utc).AddTicks(7045), new DateTime(2025, 1, 15, 8, 58, 15, 400, DateTimeKind.Utc).AddTicks(7045) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 9, 8, 58, 15, 304, DateTimeKind.Utc).AddTicks(1525), "$2a$11$ZfAmMub4Ecoa584WEt/ws.VTfbraN1FVcwofDRtN7WvqJ1X48pe16" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 9, 8, 58, 15, 400, DateTimeKind.Utc).AddTicks(460), "$2a$11$vUZ4SOdBtnUvA1vlkIOM9uPnXXqtGEozrNKAaci2WvYPeq/CxUANG" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 7, 19, 56, 53, 10, DateTimeKind.Utc).AddTicks(808), new DateTime(2025, 1, 13, 19, 56, 53, 10, DateTimeKind.Utc).AddTicks(547) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 8, 17, 56, 53, 10, DateTimeKind.Utc).AddTicks(1000), new DateTime(2025, 2, 7, 19, 56, 53, 10, DateTimeKind.Utc).AddTicks(999) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2024, 12, 29, 19, 56, 53, 10, DateTimeKind.Utc).AddTicks(1009), new DateTime(2025, 1, 14, 19, 56, 53, 10, DateTimeKind.Utc).AddTicks(1008) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 8, 19, 56, 52, 911, DateTimeKind.Utc).AddTicks(2362), "$2a$11$bliERvaBkYNCMIAVPH6IZuh6xUvy9IxGF7j8X64MpyEAiw.o.QT3O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 8, 19, 56, 53, 9, DateTimeKind.Utc).AddTicks(2653), "$2a$11$tATI.jCkkYcz60dHrJ7pB.Gnr9csdsd5Suey6HkPnnd.p5qN0ZfES" });
        }
    }
}
