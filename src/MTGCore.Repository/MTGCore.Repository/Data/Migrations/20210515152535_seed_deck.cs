using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MTGCore.Data.Migrations
{
    public partial class seed_deck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "404ca27f-19e7-48dc-99c7-76d8b63396d9", "6bc49ac0-b923-466a-9feb-67ebee73148a" });

            migrationBuilder.InsertData(
                table: "Deck",
                columns: new[] { "Id", "Title", "UserID" },
                values: new object[] { 1, "Test Deck", new Guid("b4280b6a-0613-4cbd-a9e6-f1701e926e73") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Deck",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ca4c3c06-8b3b-4366-be7a-f130a9c59a58", "a58a642a-737c-4f36-9068-ba153ef1bd79" });
        }
    }
}
