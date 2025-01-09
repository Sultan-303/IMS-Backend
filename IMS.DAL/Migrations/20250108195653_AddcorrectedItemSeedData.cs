using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddcorrectedItemSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 7, 19, 56, 53, 10, DateTimeKind.Utc).AddTicks(808), new DateTime(2025, 1, 13, 19, 56, 53, 10, DateTimeKind.Utc).AddTicks(547) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 8, 17, 56, 53, 10, DateTimeKind.Utc).AddTicks(1000), new DateTime(2025, 2, 7, 19, 56, 53, 10, DateTimeKind.Utc).AddTicks(999) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2024, 12, 29, 19, 56, 53, 10, DateTimeKind.Utc).AddTicks(1009), new DateTime(2025, 1, 14, 19, 56, 53, 10, DateTimeKind.Utc).AddTicks(1008) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 8, 19, 56, 52, 911, DateTimeKind.Utc).AddTicks(2362), "$2a$11$bliERvaBkYNCMIAVPH6IZuh6xUvy9IxGF7j8X64MpyEAiw.o.QT3O" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 1, 8, 19, 56, 53, 9, DateTimeKind.Utc).AddTicks(2653), "$2a$11$tATI.jCkkYcz60dHrJ7pB.Gnr9csdsd5Suey6HkPnnd.p5qN0ZfES" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 7, 18, 21, 49, 730, DateTimeKind.Utc).AddTicks(4976), new DateTime(2025, 1, 13, 18, 21, 49, 730, DateTimeKind.Utc).AddTicks(4742) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 1, 8, 16, 21, 49, 730, DateTimeKind.Utc).AddTicks(5165), new DateTime(2025, 2, 7, 18, 21, 49, 730, DateTimeKind.Utc).AddTicks(5164) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2024, 12, 29, 18, 21, 49, 730, DateTimeKind.Utc).AddTicks(5171), new DateTime(2025, 1, 14, 18, 21, 49, 730, DateTimeKind.Utc).AddTicks(5171) });

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
    }
}
