using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryInventory.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFKItemtoItemBorrowStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemBorrowStatus_Item_ItemId",
                table: "ItemBorrowStatus");

            migrationBuilder.DropIndex(
                name: "IX_ItemBorrowStatus_ItemId",
                table: "ItemBorrowStatus");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemBorrowStatus");

            migrationBuilder.AddColumn<decimal>(
                name: "FineAmountAccrued",
                table: "ItemBorrowStatus",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ItemBorrowStatusId",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemBorrowStatusId",
                table: "Item",
                column: "ItemBorrowStatusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_ItemBorrowStatus_ItemBorrowStatusId",
                table: "Item",
                column: "ItemBorrowStatusId",
                principalTable: "ItemBorrowStatus",
                principalColumn: "ItemBorrowStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_ItemBorrowStatus_ItemBorrowStatusId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_ItemBorrowStatusId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "FineAmountAccrued",
                table: "ItemBorrowStatus");

            migrationBuilder.DropColumn(
                name: "ItemBorrowStatusId",
                table: "Item");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ItemBorrowStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemBorrowStatus_ItemId",
                table: "ItemBorrowStatus",
                column: "ItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemBorrowStatus_Item_ItemId",
                table: "ItemBorrowStatus",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
