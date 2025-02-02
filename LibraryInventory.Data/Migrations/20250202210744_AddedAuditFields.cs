using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryInventory.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedAuditFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TransactionType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TransactionType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TransactionType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TransactionType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TransactionPaymentType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TransactionPaymentType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TransactionPaymentType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TransactionPaymentType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TransactionPayment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TransactionPayment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TransactionPayment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TransactionPayment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Transaction",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Member",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Member",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Member",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ItemType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ItemType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ItemType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ItemType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ItemPolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ItemPolicy",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ItemPolicy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ItemPolicy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ItemDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ItemDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ItemDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ItemDetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ItemBorrowStatus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ItemBorrowStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ItemBorrowStatus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ItemBorrowStatus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Item",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Item",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ContactInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ContactInfo",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TransactionType");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TransactionType");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TransactionType");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TransactionType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TransactionPaymentType");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TransactionPaymentType");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TransactionPaymentType");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TransactionPaymentType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TransactionPayment");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TransactionPayment");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TransactionPayment");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TransactionPayment");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ItemType");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ItemType");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ItemType");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ItemType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ItemPolicy");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ItemPolicy");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ItemPolicy");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ItemPolicy");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ItemDetail");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ItemDetail");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ItemDetail");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ItemDetail");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ItemBorrowStatus");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ItemBorrowStatus");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ItemBorrowStatus");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ItemBorrowStatus");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeType");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeType");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeType");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ContactInfo");
        }
    }
}
