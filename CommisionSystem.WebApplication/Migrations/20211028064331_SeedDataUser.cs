using Microsoft.EntityFrameworkCore.Migrations;

namespace CommisionSystem.WebApplication.Migrations
{
    public partial class SeedDataUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "FirstName", "HasAccessToProductSearchReport", "HasAccessToQuote", "LastName", "Password", "RoleID", "SupervisorID", "UserName" },
                values: new object[] { 1, "Admin", true, true, "Admin", "123", 1, null, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
