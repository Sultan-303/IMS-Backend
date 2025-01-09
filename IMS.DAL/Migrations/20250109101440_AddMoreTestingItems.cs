using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreTestingItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpiryDate", "ItemName" },
                values: new object[] { new DateTime(2025, 1, 8, 10, 14, 40, 303, DateTimeKind.Utc).AddTicks(9886), new DateTime(2025, 1, 14, 10, 14, 40, 303, DateTimeKind.Utc).AddTicks(9663), "Low Stock Item" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpiryDate", "ItemName" },
                values: new object[] { new DateTime(2025, 1, 9, 0, 14, 40, 304, DateTimeKind.Utc).AddTicks(147), new DateTime(2025, 1, 15, 10, 14, 40, 304, DateTimeKind.Utc).AddTicks(147), "Near Expiry Item" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2024, 12, 30, 10, 14, 40, 304, DateTimeKind.Utc).AddTicks(153), new DateTime(2025, 1, 15, 10, 14, 40, 304, DateTimeKind.Utc).AddTicks(152) });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "Category", "CreatedAt", "Description", "ExpiryDate", "ItemName", "MinimumStockQuantity", "Price", "StockQuantity", "Unit", "UserId" },
                values: new object[] { 4, "Electronics", new DateTime(2025, 1, 8, 10, 14, 40, 304, DateTimeKind.Utc).AddTicks(155), "Test item with low stock", new DateTime(2025, 1, 14, 10, 14, 40, 304, DateTimeKind.Utc).AddTicks(154), "Low Stock Item", 10, 10.99m, 5, "pcs", 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 9, 10, 14, 40, 209, DateTimeKind.Utc).AddTicks(3114), "$2a$11$ix.yg.3vijVTTpc4juGG6uo8Z0iF.JJHnrXDmJn7vqkljEgKdlS7W" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 9, 10, 14, 40, 303, DateTimeKind.Utc).AddTicks(3223), "$2a$11$p/a22a.bbCTtM7bzCM867.ilTou4Ty9yFpvoYL53VZsPagHvs.r9m" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpiryDate", "ItemName" },
                values: new object[] { new DateTime(2025, 1, 8, 9, 44, 56, 951, DateTimeKind.Utc).AddTicks(4433), new DateTime(2025, 1, 14, 9, 44, 56, 951, DateTimeKind.Utc).AddTicks(4213), "Low Stock Item 1" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpiryDate", "ItemName" },
                values: new object[] { new DateTime(2025, 1, 9, 7, 44, 56, 951, DateTimeKind.Utc).AddTicks(4733), new DateTime(2025, 2, 8, 9, 44, 56, 951, DateTimeKind.Utc).AddTicks(4732), "New Item" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2024, 12, 30, 9, 44, 56, 951, DateTimeKind.Utc).AddTicks(4739), new DateTime(2025, 1, 15, 9, 44, 56, 951, DateTimeKind.Utc).AddTicks(4739) });

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
        }
    }
}
