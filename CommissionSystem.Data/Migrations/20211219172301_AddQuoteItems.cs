using Microsoft.EntityFrameworkCore.Migrations;

namespace CommissionSystem.Data.Migrations
{
    public partial class AddQuoteItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItem_Quotes_QuoteID",
                table: "QuoteItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_QuoteStatus_QuoteStatusID",
                table: "Quotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteStatus",
                table: "QuoteStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteItem",
                table: "QuoteItem");

            migrationBuilder.RenameTable(
                name: "QuoteStatus",
                newName: "QuoteStatuses");

            migrationBuilder.RenameTable(
                name: "QuoteItem",
                newName: "QuoteItems");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteItem_QuoteID",
                table: "QuoteItems",
                newName: "IX_QuoteItems_QuoteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteStatuses",
                table: "QuoteStatuses",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteItems",
                table: "QuoteItems",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItems_Quotes_QuoteID",
                table: "QuoteItems",
                column: "QuoteID",
                principalTable: "Quotes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_QuoteStatuses_QuoteStatusID",
                table: "Quotes",
                column: "QuoteStatusID",
                principalTable: "QuoteStatuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItems_Quotes_QuoteID",
                table: "QuoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_QuoteStatuses_QuoteStatusID",
                table: "Quotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteStatuses",
                table: "QuoteStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteItems",
                table: "QuoteItems");

            migrationBuilder.RenameTable(
                name: "QuoteStatuses",
                newName: "QuoteStatus");

            migrationBuilder.RenameTable(
                name: "QuoteItems",
                newName: "QuoteItem");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteItems_QuoteID",
                table: "QuoteItem",
                newName: "IX_QuoteItem_QuoteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteStatus",
                table: "QuoteStatus",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteItem",
                table: "QuoteItem",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItem_Quotes_QuoteID",
                table: "QuoteItem",
                column: "QuoteID",
                principalTable: "Quotes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_QuoteStatus_QuoteStatusID",
                table: "Quotes",
                column: "QuoteStatusID",
                principalTable: "QuoteStatus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
