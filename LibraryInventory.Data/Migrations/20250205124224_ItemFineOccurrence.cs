using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryInventory.Data.Migrations
{
    /// <inheritdoc />
    public partial class ItemFineOccurrence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FineOccurenceTypeName",
                table: "ItemFineOccurenceType",
                newName: "ItemFineOccurenceTypeDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemFineOccurenceTypeDescription",
                table: "ItemFineOccurenceType",
                newName: "FineOccurenceTypeName");
        }
    }
}
