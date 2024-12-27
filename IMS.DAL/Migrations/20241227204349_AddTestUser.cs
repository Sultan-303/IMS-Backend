using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTestUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 27, 20, 43, 48, 658, DateTimeKind.Utc).AddTicks(7843), "$2a$11$rLQ5Fprhg0tEiyqg0whSn.1WW.z5luGWn8BjVLdwfVT2ApduNErN6" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "LastLogin", "PasswordHash", "Role", "Username" },
                values: new object[] { 2, new DateTime(2024, 12, 27, 20, 43, 48, 761, DateTimeKind.Utc).AddTicks(1219), "test@ims.com", true, null, "$2a$11$ZSjUuToLetdpXFTKrp8LM.z28s/lJhI1QSdI6KIR2vu2hhCnvt3ny", "User", "testuser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 12, 27, 20, 3, 48, 16, DateTimeKind.Utc).AddTicks(6907), "$2a$11$WvwM2SgvVED0CUdt7a4xveDdjct3QodJjVt9KDaDw1CIRQAnGtoHC" });
        }
    }
}
