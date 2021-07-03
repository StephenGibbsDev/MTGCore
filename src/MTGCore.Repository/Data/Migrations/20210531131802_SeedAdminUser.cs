using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MTGCore.Repository.Data.Migrations
{
    public partial class SeedAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b4280b6a-0613-4cbd-a9e6-f1701e926e73"), 0, "8550dc9a-ed46-4cb9-b5af-fa9ad41a85c9", "test@test.test", true, false, null, "TEST@TEST.TEST", "TESTUSER", null, null, false, null, false, "TestUser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4280b6a-0613-4cbd-a9e6-f1701e926e73"));
        }
    }
}
