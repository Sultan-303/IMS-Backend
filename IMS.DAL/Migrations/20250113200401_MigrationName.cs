using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemName",
                table: "Items",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 3, 20, 4, 1, 176, DateTimeKind.Utc).AddTicks(4054));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 8, 20, 4, 1, 176, DateTimeKind.Utc).AddTicks(4289));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 6, 20, 4, 1, 176, DateTimeKind.Utc).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 20, 4, 1, 176, DateTimeKind.Utc).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 20, 4, 1, 176, DateTimeKind.Utc).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 5, 20, 4, 1, 176, DateTimeKind.Utc).AddTicks(4403));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 20, 4, 1, 176, DateTimeKind.Utc).AddTicks(4405));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 20, 4, 1, 176, DateTimeKind.Utc).AddTicks(4405));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 12, 20, 4, 1, 176, DateTimeKind.Utc).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 20, 4, 1, 176, DateTimeKind.Utc).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 13, 20, 4, 1, 80, DateTimeKind.Utc).AddTicks(3536), "$2a$11$qvjoNVVLlqn0KjCQWNONveaJTVnL7GpuFqZxbMvopiceTo/YIAf.6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 13, 20, 4, 1, 175, DateTimeKind.Utc).AddTicks(8393), "$2a$11$VzNRsmVLcoczs2Vd1c3S9.kf7KgCPn3dkcpxwqhBZ4ZydgXQBy73W" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Items",
                newName: "ItemName");

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
    }
}
