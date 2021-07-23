using Microsoft.EntityFrameworkCore.Migrations;

namespace CWC.DAL.Migrations
{
    public partial class updateforeignkeyschemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblInventory_tblVendors_VendorsID",
                table: "tblInventory");

            migrationBuilder.DropIndex(
                name: "IX_tblInventory_VendorsID",
                table: "tblInventory");

            migrationBuilder.DropColumn(
                name: "VendorsID",
                table: "tblInventory");

            migrationBuilder.CreateIndex(
                name: "IX_tblInventory_VendorID",
                table: "tblInventory",
                column: "VendorID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblInventory_tblVendors_VendorID",
                table: "tblInventory",
                column: "VendorID",
                principalTable: "tblVendors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblInventory_tblVendors_VendorID",
                table: "tblInventory");

            migrationBuilder.DropIndex(
                name: "IX_tblInventory_VendorID",
                table: "tblInventory");

            migrationBuilder.AddColumn<int>(
                name: "VendorsID",
                table: "tblInventory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblInventory_VendorsID",
                table: "tblInventory",
                column: "VendorsID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblInventory_tblVendors_VendorsID",
                table: "tblInventory",
                column: "VendorsID",
                principalTable: "tblVendors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
