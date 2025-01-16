using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInventoryRepository : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2024, 12, 31, 16, 18, 5, 421, DateTimeKind.Utc).AddTicks(9854), new DateTime(2025, 1, 15, 16, 18, 5, 421, DateTimeKind.Utc).AddTicks(9347) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 5, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(439), new DateTime(2025, 2, 9, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(436) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 3, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(441), new DateTime(2025, 1, 14, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(440) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 8, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(445), new DateTime(2025, 1, 16, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(442) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 7, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(447), new DateTime(2025, 2, 4, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(446) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 2, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(452), new DateTime(2025, 1, 13, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(451) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 4, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(454), new DateTime(2025, 1, 30, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(453) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 6, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(458), new DateTime(2025, 1, 12, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(456) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 9, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(460), new DateTime(2025, 1, 17, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(459) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 1, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(462), new DateTime(2025, 2, 1, 16, 18, 5, 422, DateTimeKind.Utc).AddTicks(461) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2024, 12, 30, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3305), new DateTime(2025, 1, 14, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3085) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 4, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3551), new DateTime(2025, 2, 8, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3550) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 2, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3553), new DateTime(2025, 1, 13, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3553) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 7, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3555), new DateTime(2025, 1, 15, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3554) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 6, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3556), new DateTime(2025, 2, 3, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3556) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 1, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3558), new DateTime(2025, 1, 12, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3558) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 3, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3560), new DateTime(2025, 1, 29, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3559) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 5, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3562), new DateTime(2025, 1, 11, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3561) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 8, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3563), new DateTime(2025, 1, 16, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3563) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2024, 12, 31, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3565), new DateTime(2025, 1, 31, 11, 39, 32, 566, DateTimeKind.Utc).AddTicks(3564) });

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
    }
}
