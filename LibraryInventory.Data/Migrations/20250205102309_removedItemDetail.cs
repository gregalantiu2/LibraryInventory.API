using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryInventory.Data.Migrations
{
    /// <inheritdoc />
    public partial class removedItemDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_ItemBorrowStatus_ItemBorrowStatusId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_ItemDetail_ItemDetailId",
                table: "Item");

            migrationBuilder.DropTable(
                name: "ItemDetail");

            migrationBuilder.DropIndex(
                name: "IX_Item_ItemBorrowStatusId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemsBorrowed",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "IsCheckedOut",
                table: "ItemBorrowStatus");

            migrationBuilder.DropColumn(
                name: "ItemBorrowStatusId",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "ItemDetailId",
                table: "Item",
                newName: "ItemTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_ItemDetailId",
                table: "Item",
                newName: "IX_Item_ItemTypeId");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ItemBorrowStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MemberKeyId",
                table: "ItemBorrowStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ItemDescription",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemTitle",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBorrowStatus_ItemId",
                table: "ItemBorrowStatus",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemBorrowStatus_MemberKeyId",
                table: "ItemBorrowStatus",
                column: "MemberKeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_ItemType_ItemTypeId",
                table: "Item",
                column: "ItemTypeId",
                principalTable: "ItemType",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemBorrowStatus_Item_ItemId",
                table: "ItemBorrowStatus",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemBorrowStatus_Member_MemberKeyId",
                table: "ItemBorrowStatus",
                column: "MemberKeyId",
                principalTable: "Member",
                principalColumn: "MemberKeyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_ItemType_ItemTypeId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemBorrowStatus_Item_ItemId",
                table: "ItemBorrowStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemBorrowStatus_Member_MemberKeyId",
                table: "ItemBorrowStatus");

            migrationBuilder.DropIndex(
                name: "IX_ItemBorrowStatus_ItemId",
                table: "ItemBorrowStatus");

            migrationBuilder.DropIndex(
                name: "IX_ItemBorrowStatus_MemberKeyId",
                table: "ItemBorrowStatus");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemBorrowStatus");

            migrationBuilder.DropColumn(
                name: "MemberKeyId",
                table: "ItemBorrowStatus");

            migrationBuilder.DropColumn(
                name: "ItemDescription",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemTitle",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "ItemTypeId",
                table: "Item",
                newName: "ItemDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_ItemTypeId",
                table: "Item",
                newName: "IX_Item_ItemDetailId");

            migrationBuilder.AddColumn<string>(
                name: "ItemsBorrowed",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCheckedOut",
                table: "ItemBorrowStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ItemBorrowStatusId",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ItemDetail",
                columns: table => new
                {
                    ItemDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDetail", x => x.ItemDetailId);
                    table.ForeignKey(
                        name: "FK_ItemDetail_ItemType_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemType",
                        principalColumn: "ItemTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemBorrowStatusId",
                table: "Item",
                column: "ItemBorrowStatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetail_ItemTypeId",
                table: "ItemDetail",
                column: "ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_ItemBorrowStatus_ItemBorrowStatusId",
                table: "Item",
                column: "ItemBorrowStatusId",
                principalTable: "ItemBorrowStatus",
                principalColumn: "ItemBorrowStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_ItemDetail_ItemDetailId",
                table: "Item",
                column: "ItemDetailId",
                principalTable: "ItemDetail",
                principalColumn: "ItemDetailId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
