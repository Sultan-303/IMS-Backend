using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddItemSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Items",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Items",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinimumStockQuantity",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "Category", "CreatedAt", "Description", "ExpiryDate", "ItemName", "MinimumStockQuantity", "Price", "StockQuantity", "Unit" },
                values: new object[,]
                {
                    { 1, "Electronics", new DateTime(2025, 1, 7, 18, 21, 49, 730, DateTimeKind.Utc).AddTicks(4976), "Test item with low stock", new DateTime(2025, 1, 13, 18, 21, 49, 730, DateTimeKind.Utc).AddTicks(4742), "Low Stock Item 1", 10, 10.99m, 5, "pcs" },
                    { 2, "Office Supplies", new DateTime(2025, 1, 8, 16, 21, 49, 730, DateTimeKind.Utc).AddTicks(5165), "Recently added item", new DateTime(2025, 2, 7, 18, 21, 49, 730, DateTimeKind.Utc).AddTicks(5164), "New Item", 5, 15.99m, 20, "pcs" },
                    { 3, "Food", new DateTime(2024, 12, 29, 18, 21, 49, 730, DateTimeKind.Utc).AddTicks(5171), "Item near expiry", new DateTime(2025, 1, 14, 18, 21, 49, 730, DateTimeKind.Utc).AddTicks(5171), "Expiring Item", 5, 25.99m, 15, "boxes" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 8, 18, 21, 49, 632, DateTimeKind.Utc).AddTicks(888), "$2a$11$Hq8izQfIu94DzxzDdxU5Lu1dtiB7WeW8Iv20wGoGM0iYXn2CDO7zS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 8, 18, 21, 49, 729, DateTimeKind.Utc).AddTicks(8069), "$2a$11$/04.yIPgev/US.yFelOUwePcPPBhP3lCRrk.8gEV90gdwRSNePdrO" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MinimumStockQuantity",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 27, 20, 43, 48, 658, DateTimeKind.Utc).AddTicks(7843), "$2a$11$rLQ5Fprhg0tEiyqg0whSn.1WW.z5luGWn8BjVLdwfVT2ApduNErN6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 27, 20, 43, 48, 761, DateTimeKind.Utc).AddTicks(1219), "$2a$11$ZSjUuToLetdpXFTKrp8LM.z28s/lJhI1QSdI6KIR2vu2hhCnvt3ny" });
        }
    }
}
