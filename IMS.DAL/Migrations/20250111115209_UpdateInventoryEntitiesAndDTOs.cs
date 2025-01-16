using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInventoryEntitiesAndDTOs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
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

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "UserId" },
                values: new object[,]
                {
                    { 1, "Electronics", 1 },
                    { 2, "Office Supplies", 1 },
                    { 3, "Food", 1 },
                    { 4, "Garden Supplies", 1 },
                    { 5, "Cleaning Supplies", 1 },
                    { 6, "Electronics", 2 },
                    { 7, "Office Supplies", 2 },
                    { 8, "Food", 2 },
                    { 9, "Garden Supplies", 2 },
                    { 10, "Cleaning Supplies", 2 }
                });

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

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "CategoryID", "ItemID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UserId",
                table: "Categories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UserId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryID", "ItemID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryID", "ItemID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryID", "ItemID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryID", "ItemID" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryID", "ItemID" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryID", "ItemID" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryID", "ItemID" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryID", "ItemID" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryID", "ItemID" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumns: new[] { "CategoryID", "ItemID" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryID");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                columns: new[] { "Category", "CreatedAt", "ExpiryDate", "MinimumStockQuantity", "StockQuantity" },
                values: new object[] { "Electronics", new DateTime(2024, 12, 31, 16, 18, 5, 421, DateTimeKind.Utc).AddTicks(9854), new DateTime(2025, 1, 15, 16, 18, 5, 421, DateTimeKind.Utc).AddTicks(9347), 10, 15 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                columns: new[] { "Category", "CreatedAt", "ExpiryDate", "MinimumStockQuantity", "StockQuantity" },
                values: new object[] { "Office Supplies", new DateTime(2025, 1, 5, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(439), new DateTime(2025, 2, 9, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(436), 10, 3 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                columns: new[] { "Category", "CreatedAt", "ExpiryDate", "MinimumStockQuantity", "StockQuantity" },
                values: new object[] { "Food", new DateTime(2025, 1, 3, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(441), new DateTime(2025, 1, 14, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(440), 5, 2 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 4,
                columns: new[] { "Category", "CreatedAt", "ExpiryDate", "MinimumStockQuantity", "StockQuantity" },
                values: new object[] { "Garden Supplies", new DateTime(2025, 1, 8, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(445), new DateTime(2025, 1, 16, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(442), 10, 20 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 5,
                columns: new[] { "Category", "CreatedAt", "ExpiryDate", "MinimumStockQuantity", "StockQuantity" },
                values: new object[] { "Cleaning Supplies", new DateTime(2025, 1, 7, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(447), new DateTime(2025, 2, 4, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(446), 10, 4 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 6,
                columns: new[] { "Category", "CreatedAt", "ExpiryDate", "MinimumStockQuantity", "StockQuantity" },
                values: new object[] { "Electronics", new DateTime(2025, 1, 2, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(452), new DateTime(2025, 1, 13, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(451), 15, 25 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 7,
                columns: new[] { "Category", "CreatedAt", "ExpiryDate", "MinimumStockQuantity", "StockQuantity" },
                values: new object[] { "Office Supplies", new DateTime(2025, 1, 4, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(454), new DateTime(2025, 1, 30, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(453), 10, 2 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 8,
                columns: new[] { "Category", "CreatedAt", "ExpiryDate", "MinimumStockQuantity", "StockQuantity" },
                values: new object[] { "Food", new DateTime(2025, 1, 6, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(458), new DateTime(2025, 1, 12, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(456), 5, 1 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 9,
                columns: new[] { "Category", "CreatedAt", "ExpiryDate", "MinimumStockQuantity", "StockQuantity" },
                values: new object[] { "Garden Supplies", new DateTime(2025, 1, 9, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(460), new DateTime(2025, 1, 17, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(459), 20, 30 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 10,
                columns: new[] { "Category", "CreatedAt", "ExpiryDate", "MinimumStockQuantity", "StockQuantity" },
                values: new object[] { "Cleaning Supplies", new DateTime(2025, 1, 1, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(462), new DateTime(2025, 2, 1, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(461), 10, 5 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 10, 16, 18, 5, 303, DateTimeKind.Utc).AddTicks(442), "$2a$11$TMjFOWCYwcUK/UvZ4HfuE.ZSPloyfZM8J.CDy71MbAP54pyfUXqZ6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 10, 16, 18, 5, 420, DateTimeKind.Utc).AddTicks(5925), "$2a$11$nwt7ZQ8jd7Yioqt6zirY1uc9zlVZAfvVZZYADynjqhk1SXBD1Kpcm" });
        }
    }
}
