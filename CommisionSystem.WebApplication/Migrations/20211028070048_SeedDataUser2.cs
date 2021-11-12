using Microsoft.EntityFrameworkCore.Migrations;

namespace CommissionSystem.WebApplication.Migrations
{
    public partial class SeedDataUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "FirstName", "HasAccessToProductSearchReport", "HasAccessToQuote", "LastName", "Password", "RoleID", "SupervisorID", "UserName" },
                values: new object[] { 2, "Alireza", true, false, "Sabouei", "123", 4, null, "ali" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
