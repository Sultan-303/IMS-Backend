using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class testmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 20, 44, 0, 582, DateTimeKind.Utc).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 15, 20, 44, 0, 582, DateTimeKind.Utc).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 13, 20, 44, 0, 582, DateTimeKind.Utc).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 18, 20, 44, 0, 582, DateTimeKind.Utc).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 17, 20, 44, 0, 582, DateTimeKind.Utc).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 12, 20, 44, 0, 582, DateTimeKind.Utc).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 14, 20, 44, 0, 582, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 16, 20, 44, 0, 582, DateTimeKind.Utc).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 19, 20, 44, 0, 582, DateTimeKind.Utc).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 20, 44, 0, 582, DateTimeKind.Utc).AddTicks(4663));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 20, 20, 44, 0, 484, DateTimeKind.Utc).AddTicks(8233), "$2a$11$H6YVjwpSF0XRA6gGnbdMc.PZb.S6x0hgsFlwUsFI.h0MxbihZXaGW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 20, 20, 44, 0, 581, DateTimeKind.Utc).AddTicks(8167), "$2a$11$2SYmgUUg7XS0dcf/cSqlCuDIvkTergwHG.6mb0XVk9gbA0EuBmEPK" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 5, 18, 42, 10, 563, DateTimeKind.Utc).AddTicks(3431));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 18, 42, 10, 563, DateTimeKind.Utc).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 8, 18, 42, 10, 563, DateTimeKind.Utc).AddTicks(3674));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 13, 18, 42, 10, 563, DateTimeKind.Utc).AddTicks(3675));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 12, 18, 42, 10, 563, DateTimeKind.Utc).AddTicks(3677));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 18, 42, 10, 563, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 18, 42, 10, 563, DateTimeKind.Utc).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 18, 42, 10, 563, DateTimeKind.Utc).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 14, 18, 42, 10, 563, DateTimeKind.Utc).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 6, 18, 42, 10, 563, DateTimeKind.Utc).AddTicks(3794));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 15, 18, 42, 10, 468, DateTimeKind.Utc).AddTicks(1946), "$2a$11$YOzrIlrUGgBtKNpGOn51L.StP88zt834xrF3LYwebiQPsZYKC2vp2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 15, 18, 42, 10, 562, DateTimeKind.Utc).AddTicks(6706), "$2a$11$jrqr3zR/WdxMA8yaxTExy.e5OLPbRmbOpIfNWglSSVLq3YFdrOte." });
        }
    }
}
