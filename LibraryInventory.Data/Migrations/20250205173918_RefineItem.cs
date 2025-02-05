using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryInventory.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefineItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Item",
                newName: "ItemLocation");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Item",
                newName: "ItemActive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemLocation",
                table: "Item",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "ItemActive",
                table: "Item",
                newName: "IsActive");
        }
    }
}
