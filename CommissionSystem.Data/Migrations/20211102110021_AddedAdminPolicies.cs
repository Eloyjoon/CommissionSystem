using Microsoft.EntityFrameworkCore.Migrations;

namespace CommissionSystem.Data.Migrations
{
    public partial class AddedAdminPolicies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Policies",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "UserPolicies",
                columns: new[] { "ID", "PolicyID", "UserID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 },
                    { 6, 6, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Policies_UserID",
                table: "Policies",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_Users_UserID",
                table: "Policies",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Users_UserID",
                table: "Policies");

            migrationBuilder.DropIndex(
                name: "IX_Policies_UserID",
                table: "Policies");

            migrationBuilder.DeleteData(
                table: "UserPolicies",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserPolicies",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserPolicies",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserPolicies",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserPolicies",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserPolicies",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Policies");
        }
    }
}
