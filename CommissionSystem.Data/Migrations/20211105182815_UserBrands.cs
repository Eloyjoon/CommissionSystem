using Microsoft.EntityFrameworkCore.Migrations;

namespace CommissionSystem.Data.Migrations
{
    public partial class UserBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePolicies");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.CreateTable(
                name: "UserBrands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBrands", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserBrands_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "AccessLevel",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "AccessLevel", "RoleName" },
                values: new object[] { 20, "Supervisor" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "AccessLevel", "RoleName" },
                values: new object[] { 10, "Expert" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "RoleID",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_UserBrands_UserID",
                table: "UserBrands",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBrands");

            migrationBuilder.CreateTable(
                name: "RolePolicies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Policy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePolicies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RolePolicies_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RolePolicies",
                columns: new[] { "ID", "Policy", "RoleID" },
                values: new object[] { 1, "CreateUser", 1 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "AccessLevel",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "AccessLevel", "RoleName" },
                values: new object[] { 3, "Admin" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "AccessLevel", "RoleName" },
                values: new object[] { 2, "Supervisor" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "AccessLevel", "RoleName" },
                values: new object[] { 4, 1, "Expert" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "RoleID",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_RolePolicies_RoleID",
                table: "RolePolicies",
                column: "RoleID");
        }
    }
}
