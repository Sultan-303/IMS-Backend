using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Inventoryupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantityInStock",
                table: "Stocks",
                newName: "Quantity");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Stocks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "ExpiryDate", "ItemName", "Price", "StockQuantity" },
                values: new object[] { new DateTime(2024, 12, 30, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3305), "Admin item nearing expiry", new DateTime(2025, 1, 14, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3085), "Admin Near Expiry Item 1", 20.99m, 15 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "ExpiryDate", "ItemName", "MinimumStockQuantity", "Price", "StockQuantity", "UserId" },
                values: new object[] { new DateTime(2025, 1, 4, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3551), "Admin item with low stock", new DateTime(2025, 2, 8, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3550), "Admin Low Stock Item 1", 10, 5.99m, 3, 1 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "ExpiryDate", "ItemName", "Price", "StockQuantity" },
                values: new object[] { new DateTime(2025, 1, 2, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3553), "Admin item near expiry and low stock", new DateTime(2025, 1, 13, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3553), "Admin Near Expiry & Low Stock Item", 15.99m, 2 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 4,
                columns: new[] { "Category", "CreatedAt", "Description", "ExpiryDate", "ItemName", "Price", "StockQuantity", "UserId" },
                values: new object[] { "Garden Supplies", new DateTime(2025, 1, 7, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3555), "Another admin item nearing expiry", new DateTime(2025, 1, 15, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3554), "Admin Near Expiry Item 2", 12.99m, 20, 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "Category", "CreatedAt", "Description", "ExpiryDate", "ItemName", "MinimumStockQuantity", "Price", "StockQuantity", "Unit", "UserId" },
                values: new object[,]
                {
                    { 5, "Cleaning Supplies", new DateTime(2025, 1, 6, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3556), "Another admin item with low stock", new DateTime(2025, 2, 3, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3556), "Admin Low Stock Item 2", 10, 7.99m, 4, "pcs", 1 },
                    { 6, "Electronics", new DateTime(2025, 1, 1, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3558), "TestUser item nearing expiry", new DateTime(2025, 1, 12, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3558), "TestUser Near Expiry Item 1", 15, 18.99m, 25, "pcs", 2 },
                    { 7, "Office Supplies", new DateTime(2025, 1, 3, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3560), "TestUser item with low stock", new DateTime(2025, 1, 29, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3559), "TestUser Low Stock Item 1", 10, 9.99m, 2, "pcs", 2 },
                    { 8, "Food", new DateTime(2025, 1, 5, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3562), "TestUser item near expiry and low stock", new DateTime(2025, 1, 11, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3561), "TestUser Near Expiry & Low Stock Item", 5, 14.99m, 1, "boxes", 2 },
                    { 9, "Garden Supplies", new DateTime(2025, 1, 8, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3563), "Another TestUser item nearing expiry", new DateTime(2025, 1, 16, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3563), "TestUser Near Expiry Item 2", 20, 11.99m, 30, "pcs", 2 },
                    { 10, "Cleaning Supplies", new DateTime(2024, 12, 31, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3565), "Another TestUser item with low stock", new DateTime(2025, 1, 31, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3564), "TestUser Low Stock Item 2", 10, 8.99m, 5, "pcs", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 9, 11, 39, 32, 470, DateTimeKind.Utc).AddTicks(5371), "$2a$11$hcFvphwA/2iTV5dJjwdDsuLu3p55EZ37umpXQeC26QFge5O8mFY4i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 9, 11, 39, 32, 565, DateTimeKind.Utc).AddTicks(6937), "$2a$11$3GPeYeFH/4oJvKv67JJFNOLgvWXKJb8Xw3QmZgme.gSyXRO0ph6.G" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Stocks",
                newName: "QuantityInStock");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "ExpiryDate", "ItemName", "Price", "StockQuantity" },
                values: new object[] { new DateTime(2025, 1, 8, 10, 14, 40, 303, DateTimeKind.Utc).AddTicks(9886), "Test item with low stock", new DateTime(2025, 1, 14, 10, 14, 40, 303, DateTimeKind.Utc).AddTicks(9663), "Low Stock Item", 10.99m, 5 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "ExpiryDate", "ItemName", "MinimumStockQuantity", "Price", "StockQuantity", "UserId" },
                values: new object[] { new DateTime(2025, 1, 9, 0, 14, 40, 304, DateTimeKind.Utc).AddTicks(147), "Recently added item", new DateTime(2025, 1, 15, 10, 14, 40, 304, DateTimeKind.Utc).AddTicks(147), "Near Expiry Item", 5, 15.99m, 20, 2 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "ExpiryDate", "ItemName", "Price", "StockQuantity" },
                values: new object[] { new DateTime(2024, 12, 30, 10, 14, 40, 304, DateTimeKind.Utc).AddTicks(153), "Item near expiry", new DateTime(2025, 1, 15, 10, 14, 40, 304, DateTimeKind.Utc).AddTicks(152), "Expiring Item", 25.99m, 15 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 4,
                columns: new[] { "Category", "CreatedAt", "Description", "ExpiryDate", "ItemName", "Price", "StockQuantity", "UserId" },
                values: new object[] { "Electronics", new DateTime(2025, 1, 8, 10, 14, 40, 304, DateTimeKind.Utc).AddTicks(155), "Test item with low stock", new DateTime(2025, 1, 14, 10, 14, 40, 304, DateTimeKind.Utc).AddTicks(154), "Low Stock Item", 10.99m, 5, 2 });

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
    }
}
