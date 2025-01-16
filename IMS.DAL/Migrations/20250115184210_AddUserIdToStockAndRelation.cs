using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToStockAndRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Stocks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_UserId",
                table: "Stocks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Users_UserId",
                table: "Stocks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Users_UserId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_UserId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Stocks");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 5, 18, 36, 21, 336, DateTimeKind.Utc).AddTicks(8292));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 18, 36, 21, 336, DateTimeKind.Utc).AddTicks(8622));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 8, 18, 36, 21, 336, DateTimeKind.Utc).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 13, 18, 36, 21, 336, DateTimeKind.Utc).AddTicks(8626));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 12, 18, 36, 21, 336, DateTimeKind.Utc).AddTicks(8627));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 18, 36, 21, 336, DateTimeKind.Utc).AddTicks(8783));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 18, 36, 21, 336, DateTimeKind.Utc).AddTicks(8785));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 18, 36, 21, 336, DateTimeKind.Utc).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 14, 18, 36, 21, 336, DateTimeKind.Utc).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 6, 18, 36, 21, 336, DateTimeKind.Utc).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 15, 18, 36, 21, 235, DateTimeKind.Utc).AddTicks(5957), "$2a$11$xLaj6oFrFmq1DXLMb9jpxuHwgLM0dGlG8I/RRtoJOq1L2N1iQeV8O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 15, 18, 36, 21, 336, DateTimeKind.Utc).AddTicks(155), "$2a$11$NA8ACmTy.AL1mg0lssCiuuvzaf9ja1MXfhMsk5dJdGvB.fnkCZkVe" });
        }
    }
}
