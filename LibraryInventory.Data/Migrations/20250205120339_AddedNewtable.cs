using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryInventory.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FineOccurrence",
                table: "ItemPolicy");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ItemPolicy",
                newName: "ItemFineOccurenceTypeId");

            migrationBuilder.CreateTable(
                name: "ItemFineOccurenceType",
                columns: table => new
                {
                    ItemFineOccurenceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FineOccurenceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemFineOccurenceType", x => x.ItemFineOccurenceTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPolicy_ItemFineOccurenceTypeId",
                table: "ItemPolicy",
                column: "ItemFineOccurenceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPolicy_ItemFineOccurenceType_ItemFineOccurenceTypeId",
                table: "ItemPolicy",
                column: "ItemFineOccurenceTypeId",
                principalTable: "ItemFineOccurenceType",
                principalColumn: "ItemFineOccurenceTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPolicy_ItemFineOccurenceType_ItemFineOccurenceTypeId",
                table: "ItemPolicy");

            migrationBuilder.DropTable(
                name: "ItemFineOccurenceType");

            migrationBuilder.DropIndex(
                name: "IX_ItemPolicy_ItemFineOccurenceTypeId",
                table: "ItemPolicy");

            migrationBuilder.RenameColumn(
                name: "ItemFineOccurenceTypeId",
                table: "ItemPolicy",
                newName: "ItemId");

            migrationBuilder.AddColumn<int>(
                name: "FineOccurrence",
                table: "ItemPolicy",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
