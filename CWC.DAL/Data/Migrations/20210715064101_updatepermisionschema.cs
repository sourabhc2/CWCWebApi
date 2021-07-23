using Microsoft.EntityFrameworkCore.Migrations;

namespace CWC.DAL.Migrations
{
    public partial class updatepermisionschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RolesRoleId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblRoleClaims_tblRoles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "tblRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblUserRoles",
                columns: table => new
                {
                    UserRolesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RolesRoleId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserRoles", x => x.UserRolesId);
                    table.ForeignKey(
                        name: "FK_tblUserRoles_tblRoles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "tblRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblUserRoles_tblUsers_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "tblUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblRoleClaims_RolesRoleId",
                table: "tblRoleClaims",
                column: "RolesRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRoles_RolesRoleId",
                table: "tblUserRoles",
                column: "RolesRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRoles_UsersUserId",
                table: "tblUserRoles",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblRoleClaims");

            migrationBuilder.DropTable(
                name: "tblUserRoles");
        }
    }
}
