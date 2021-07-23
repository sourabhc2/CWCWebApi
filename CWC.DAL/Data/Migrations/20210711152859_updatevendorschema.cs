using Microsoft.EntityFrameworkCore.Migrations;

namespace CWC.DAL.Migrations
{
    public partial class updatevendorschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vendor_Last_Name",
                table: "tblVendors",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "Vendor_First_Name",
                table: "tblVendors",
                newName: "First_Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "tblVendors",
                newName: "Vendor_Last_Name");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "tblVendors",
                newName: "Vendor_First_Name");
        }
    }
}
