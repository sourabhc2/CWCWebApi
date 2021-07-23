using Microsoft.EntityFrameworkCore.Migrations;

namespace CWC.DAL.Migrations
{
    public partial class modifyforeignkeyschemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRoleClaims_tblRoles_RolesRoleId",
                table: "tblRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserRoles_tblRoles_RolesRoleId",
                table: "tblUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_tblUserRoles_RolesRoleId",
                table: "tblUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_tblRoleClaims_RolesRoleId",
                table: "tblRoleClaims");

            migrationBuilder.DropColumn(
                name: "RolesRoleId",
                table: "tblUserRoles");

            migrationBuilder.DropColumn(
                name: "RolesRoleId",
                table: "tblRoleClaims");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRoles_RoleId",
                table: "tblUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRoleClaims_RoleId",
                table: "tblRoleClaims",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRoleClaims_tblRoles_RoleId",
                table: "tblRoleClaims",
                column: "RoleId",
                principalTable: "tblRoles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserRoles_tblRoles_RoleId",
                table: "tblUserRoles",
                column: "RoleId",
                principalTable: "tblRoles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRoleClaims_tblRoles_RoleId",
                table: "tblRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserRoles_tblRoles_RoleId",
                table: "tblUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_tblUserRoles_RoleId",
                table: "tblUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_tblRoleClaims_RoleId",
                table: "tblRoleClaims");

            migrationBuilder.AddColumn<int>(
                name: "RolesRoleId",
                table: "tblUserRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolesRoleId",
                table: "tblRoleClaims",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRoles_RolesRoleId",
                table: "tblUserRoles",
                column: "RolesRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRoleClaims_RolesRoleId",
                table: "tblRoleClaims",
                column: "RolesRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRoleClaims_tblRoles_RolesRoleId",
                table: "tblRoleClaims",
                column: "RolesRoleId",
                principalTable: "tblRoles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserRoles_tblRoles_RolesRoleId",
                table: "tblUserRoles",
                column: "RolesRoleId",
                principalTable: "tblRoles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
