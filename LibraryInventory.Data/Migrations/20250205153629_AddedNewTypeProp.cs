using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryInventory.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewTypeProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalProperties",
                table: "ItemType");

            migrationBuilder.CreateTable(
                name: "ItemTypeProperties",
                columns: table => new
                {
                    ItemTypePropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    PropertyKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeProperties", x => x.ItemTypePropertyId);
                    table.ForeignKey(
                        name: "FK_ItemTypeProperties_ItemType_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemType",
                        principalColumn: "ItemTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeProperties_ItemTypeId",
                table: "ItemTypeProperties",
                column: "ItemTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTypeProperties");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalProperties",
                table: "ItemType",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
