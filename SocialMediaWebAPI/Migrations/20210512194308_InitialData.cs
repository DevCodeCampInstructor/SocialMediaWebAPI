using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaWebAPI.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "David", "Lagrange" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 2, "Michael", "Terrill" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Likes", "PostDate", "Title", "UserId" },
                values: new object[] { 2, "Mine is Groundhog Day", 0, new DateTime(2021, 5, 12, 14, 43, 7, 975, DateTimeKind.Local).AddTicks(6496), "Whats your favorite movie?", 1 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Likes", "PostDate", "Title", "UserId" },
                values: new object[] { 1, "I found a buffalo nickel!", 0, new DateTime(2021, 5, 12, 14, 43, 7, 971, DateTimeKind.Local).AddTicks(6216), "Look what I found!", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
