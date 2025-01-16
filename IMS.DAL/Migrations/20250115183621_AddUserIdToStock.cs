using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 3, 20, 43, 35, 817, DateTimeKind.Utc).AddTicks(602));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 8, 20, 43, 35, 817, DateTimeKind.Utc).AddTicks(843));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 6, 20, 43, 35, 817, DateTimeKind.Utc).AddTicks(846));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 20, 43, 35, 817, DateTimeKind.Utc).AddTicks(847));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 20, 43, 35, 817, DateTimeKind.Utc).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 5, 20, 43, 35, 817, DateTimeKind.Utc).AddTicks(965));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 7, 20, 43, 35, 817, DateTimeKind.Utc).AddTicks(966));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 20, 43, 35, 817, DateTimeKind.Utc).AddTicks(967));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 12, 20, 43, 35, 817, DateTimeKind.Utc).AddTicks(968));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 20, 43, 35, 817, DateTimeKind.Utc).AddTicks(969));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 13, 20, 43, 35, 721, DateTimeKind.Utc).AddTicks(3375), "$2a$11$HjbeyxuuEd4pB9Cyx/coSOx34Ju8jzjgE44oxYhyMBMAFFanUd1Se" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 13, 20, 43, 35, 816, DateTimeKind.Utc).AddTicks(4089), "$2a$11$mnTr7m6MDwC.05AohEXIHuDmQSrLF2bng.Gt0HgEGbK5sKW2uthFW" });
        }
    }
}
