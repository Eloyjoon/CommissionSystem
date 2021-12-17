using Microsoft.EntityFrameworkCore.Migrations;

namespace CommissionSystem.Data.Migrations
{
    public partial class UserPolicies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "ID", "DisplayName", "Name", "UserID" },
                values: new object[] { 7, "Dashboard", "Dashboard", null });

            migrationBuilder.InsertData(
                table: "UserPolicies",
                columns: new[] { "ID", "PolicyID", "UserID" },
                values: new object[] { 7, 7, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserPolicies",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "ID",
                keyValue: 7);
        }
    }
}
