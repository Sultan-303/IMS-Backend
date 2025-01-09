using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpiryDate", "UserId" },
                values: new object[] { new DateTime(2025, 1, 8, 9, 44, 56, 951, DateTimeKind.Utc).AddTicks(4433), new DateTime(2025, 1, 14, 9, 44, 56, 951, DateTimeKind.Utc).AddTicks(4213), 1 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpiryDate", "UserId" },
                values: new object[] { new DateTime(2025, 1, 9, 7, 44, 56, 951, DateTimeKind.Utc).AddTicks(4733), new DateTime(2025, 2, 8, 9, 44, 56, 951, DateTimeKind.Utc).AddTicks(4732), 2 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpiryDate", "UserId" },
                values: new object[] { new DateTime(2024, 12, 30, 9, 44, 56, 951, DateTimeKind.Utc).AddTicks(4739), new DateTime(2025, 1, 15, 9, 44, 56, 951, DateTimeKind.Utc).AddTicks(4739), 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 9, 9, 44, 56, 853, DateTimeKind.Utc).AddTicks(7621), "$2a$11$E160rsbrzKHe9w6VHAN37erwhy/249eG0sWD3gwMd7YRPaM5k9/0u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 9, 9, 44, 56, 950, DateTimeKind.Utc).AddTicks(7905), "$2a$11$RrWXU1Qh1qGNeEm/HOHRje6mEHDK1hlnuHg7DbBCJmfUsmZBA04l6" });

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserId",
                table: "Items",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_UserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Items");

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
    }
}
