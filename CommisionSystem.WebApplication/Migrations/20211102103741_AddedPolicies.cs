using Microsoft.EntityFrameworkCore.Migrations;

namespace CommisionSystem.WebApplication.Migrations
{
    public partial class AddedPolicies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserPolicies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PolicyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPolicies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserPolicies_Policies_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPolicies_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "ID", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1, "Read Products", "ReadProducts" },
                    { 2, "Read Brands", "ReadBrands" },
                    { 3, "Read Users", "ReadUsers" },
                    { 4, "Disable User Account", "DisableUserAccount" },
                    { 5, "Enable User Account", "EnableUserAccount" },
                    { 6, "Add User Account", "AddUserAccount" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPolicies_PolicyID",
                table: "UserPolicies",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPolicies_UserID",
                table: "UserPolicies",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPolicies");

            migrationBuilder.DropTable(
                name: "Policies");
        }
    }
}
