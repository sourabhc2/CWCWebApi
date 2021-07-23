using Microsoft.EntityFrameworkCore.Migrations;

namespace CWC.DAL.Migrations
{
    public partial class updateforeignkeyschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUsers_tblRoles_RoleId",
                table: "tblUsers");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "tblUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Isactive",
                table: "tblRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUsers_tblRoles_RoleId",
                table: "tblUsers",
                column: "RoleId",
                principalTable: "tblRoles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUsers_tblRoles_RoleId",
                table: "tblUsers");

            migrationBuilder.DropColumn(
                name: "Isactive",
                table: "tblRoles");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "tblUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUsers_tblRoles_RoleId",
                table: "tblUsers",
                column: "RoleId",
                principalTable: "tblRoles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
