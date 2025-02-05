using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryInventory.Data.Migrations
{
    /// <inheritdoc />
    public partial class Adjust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionPaymentId",
                table: "Transaction");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_MemberId",
                table: "Transaction",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Member_MemberId",
                table: "Transaction",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "MemberKeyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Member_MemberId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_MemberId",
                table: "Transaction");

            migrationBuilder.AddColumn<int>(
                name: "TransactionPaymentId",
                table: "Transaction",
                type: "int",
                nullable: true);
        }
    }
}
