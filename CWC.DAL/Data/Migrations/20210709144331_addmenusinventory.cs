using Microsoft.EntityFrameworkCore.Migrations;

namespace CWC.DAL.Migrations
{
    public partial class addmenusinventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblInventory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    VendorID = table.Column<int>(type: "int", nullable: true),
                    Added_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblInventory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblMenuItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Food_Item_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemApprvFrmSuperAdm = table.Column<bool>(type: "bit", nullable: false),
                    ItemDelFromSuperAdm = table.Column<bool>(type: "bit", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMenuItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblMenuItems_tblInventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "tblInventory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblMenuItems_InventoryID",
                table: "tblMenuItems",
                column: "InventoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblMenuItems");

            migrationBuilder.DropTable(
                name: "tblInventory");
        }
    }
}
