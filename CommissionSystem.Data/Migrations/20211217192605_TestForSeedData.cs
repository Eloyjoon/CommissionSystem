using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommissionSystem.Data.Migrations
{
    public partial class TestForSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Users_UserID",
                table: "Policies");

            migrationBuilder.DropIndex(
                name: "IX_Policies_UserID",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Policies");

            migrationBuilder.CreateTable(
                name: "QuoteStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CreatorID = table.Column<int>(type: "int", nullable: false),
                    AssigneeID = table.Column<int>(type: "int", nullable: false),
                    QuoteStatusID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonInCharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Quotes_QuoteStatus_QuoteStatusID",
                        column: x => x.QuoteStatusID,
                        principalTable: "QuoteStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotes_Users_AssigneeID",
                        column: x => x.AssigneeID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Quotes_Users_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QuoteItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuoteID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPriceInRials = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPriceInRials = table.Column<int>(type: "int", nullable: false),
                    Commission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuoteItem_Quotes_QuoteID",
                        column: x => x.QuoteID,
                        principalTable: "Quotes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "QuoteStatus",
                columns: new[] { "ID", "Name", "Title" },
                values: new object[,]
                {
                    { 1, "Open", "Open" },
                    { 2, "Draft", "Draft" },
                    { 3, "WaitingToConfirm", "Waiting To Confirm" },
                    { 4, "Finalized", "Finalized" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItem_QuoteID",
                table: "QuoteItem",
                column: "QuoteID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_AssigneeID",
                table: "Quotes",
                column: "AssigneeID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_CreatorID",
                table: "Quotes",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_QuoteStatusID",
                table: "Quotes",
                column: "QuoteStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuoteItem");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "QuoteStatus");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Policies",
                type: "int",
                nullable: true);

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
    }
}
