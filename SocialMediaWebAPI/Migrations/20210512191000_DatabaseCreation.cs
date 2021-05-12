using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaWebAPI.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Likes", "PostDate", "Title" },
                values: new object[] { 1, "I found a buffalo nickel!", 0, new DateTime(2021, 5, 12, 14, 9, 59, 947, DateTimeKind.Local).AddTicks(5278), "Look what I found!" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Likes", "PostDate", "Title" },
                values: new object[] { 2, "Mine is Groundhog Day", 0, new DateTime(2021, 5, 12, 14, 9, 59, 953, DateTimeKind.Local).AddTicks(2502), "Whats your favorite movie?" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
