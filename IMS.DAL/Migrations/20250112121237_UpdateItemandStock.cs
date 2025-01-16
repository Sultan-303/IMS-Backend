using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemandStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 12, 12, 36, 804, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 12, 12, 36, 804, DateTimeKind.Utc).AddTicks(6489));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 5, 12, 12, 36, 804, DateTimeKind.Utc).AddTicks(6492));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 12, 12, 36, 804, DateTimeKind.Utc).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 12, 12, 36, 804, DateTimeKind.Utc).AddTicks(6495));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 12, 12, 36, 804, DateTimeKind.Utc).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 6, 12, 12, 36, 804, DateTimeKind.Utc).AddTicks(6609));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 8, 12, 12, 36, 804, DateTimeKind.Utc).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 12, 12, 36, 804, DateTimeKind.Utc).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 3, 12, 12, 36, 804, DateTimeKind.Utc).AddTicks(6612));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 12, 12, 12, 36, 710, DateTimeKind.Utc).AddTicks(1903), "$2a$11$764SrXO83C1kYUKrggpnveOk4jXDluRtb6hE66kVV2DmqLZ0xKXme" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 12, 12, 12, 36, 804, DateTimeKind.Utc).AddTicks(169), "$2a$11$c1caWY1TuObEk847PVq4D.O9re90Qq2t5viWnc/S1RMx.mwjk/tM." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 11, 52, 9, 236, DateTimeKind.Utc).AddTicks(8713));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 6, 11, 52, 9, 236, DateTimeKind.Utc).AddTicks(8931));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 11, 52, 9, 236, DateTimeKind.Utc).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 11, 52, 9, 236, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 8, 11, 52, 9, 236, DateTimeKind.Utc).AddTicks(8935));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 3, 11, 52, 9, 236, DateTimeKind.Utc).AddTicks(9056));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 5, 11, 52, 9, 236, DateTimeKind.Utc).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 11, 52, 9, 236, DateTimeKind.Utc).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 11, 52, 9, 236, DateTimeKind.Utc).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 11, 52, 9, 236, DateTimeKind.Utc).AddTicks(9061));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 11, 11, 52, 9, 144, DateTimeKind.Utc).AddTicks(2894), "$2a$11$/YxCYIldmpX3Zs8UBZ.cMeOmqv7R7a9I4tNgj0ZqzXU0i7PaU2nXe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 11, 11, 52, 9, 236, DateTimeKind.Utc).AddTicks(3983), "$2a$11$LXTdozlrZ3lAwAMpI836TOneoEfY3yDAwUOIjJidNfAsLkjY7W0Fi" });
        }
    }
}
