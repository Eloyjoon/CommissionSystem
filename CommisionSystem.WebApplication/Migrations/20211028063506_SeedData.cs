using Microsoft.EntityFrameworkCore.Migrations;

namespace CommissionSystem.WebApplication.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePolicies_UserRoles_RoleID",
                table: "RolePolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_RoleID",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "AccessLevel", "RoleName" },
                values: new object[] { 1, "Expert" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "AccessLevel", "RoleName" },
                values: new object[,]
                {
                    { 1, 4, "Super Admin" },
                    { 2, 3, "Admin" },
                    { 3, 2, "Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "RolePolicies",
                columns: new[] { "ID", "Policy", "RoleID" },
                values: new object[] { 1, "CreateUser", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_RolePolicies_Roles_RoleID",
                table: "RolePolicies",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePolicies_Roles_RoleID",
                table: "RolePolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DeleteData(
                table: "RolePolicies",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "UserRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "AccessLevel", "RoleName" },
                values: new object[] { 5, "Super Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_RolePolicies_UserRoles_RoleID",
                table: "RolePolicies",
                column: "RoleID",
                principalTable: "UserRoles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_RoleID",
                table: "Users",
                column: "RoleID",
                principalTable: "UserRoles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
