using Microsoft.EntityFrameworkCore.Migrations;

namespace CWC.DAL.Migrations
{
    public partial class addvendorsschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "tblInventory");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "tblMenuItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "VendorID",
                table: "tblInventory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorsID",
                table: "tblInventory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblVendors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vendor_First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendor_Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNewApproved = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVendors", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblInventory_tblVendors_VendorsID",
                table: "tblInventory");

            migrationBuilder.DropTable(
                name: "tblVendors");

            migrationBuilder.DropIndex(
                name: "IX_tblInventory_VendorsID",
                table: "tblInventory");

            migrationBuilder.DropColumn(
                name: "VendorsID",
                table: "tblInventory");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "tblMenuItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "VendorID",
                table: "tblInventory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "tblInventory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
