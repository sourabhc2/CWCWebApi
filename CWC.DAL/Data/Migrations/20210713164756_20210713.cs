using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CWC.DAL.Migrations
{
    public partial class _20210713 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Item_Name",
                table: "tblInventory",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Added_Date",
                table: "tblInventory",
                newName: "ItemName");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "tblInventory",
                newName: "InventoryId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsNewApproved",
                table: "tblVendors",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "tblVendors",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "tblVendors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "tblInventory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tblInventory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "tblInventory",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "tblVendors");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "tblInventory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tblInventory");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "tblInventory");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "tblInventory",
                newName: "Item_Name");

            migrationBuilder.RenameColumn(
                name: "ItemName",
                table: "tblInventory",
                newName: "Added_Date");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "tblInventory",
                newName: "ID");

            migrationBuilder.AlterColumn<bool>(
                name: "IsNewApproved",
                table: "tblVendors",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "tblVendors",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
