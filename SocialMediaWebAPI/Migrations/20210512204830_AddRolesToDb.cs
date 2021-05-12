using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaWebAPI.Migrations
{
    public partial class AddRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07c8ae14-4db8-4ee5-aff2-f579fd38a12b", "2640470f-eb50-43e8-833f-341c45b99e40", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e82538cf-cb47-45ae-960a-f28aa8e89f47", "501fe259-aebd-431c-af2a-eb34a5c954e3", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07c8ae14-4db8-4ee5-aff2-f579fd38a12b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e82538cf-cb47-45ae-960a-f28aa8e89f47");
        }
    }
}
