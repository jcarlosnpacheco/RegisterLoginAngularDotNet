using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterLoginAPI.Migrations
{
    public partial class newcolumnadjustinregister_login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoginTypeId",
                table: "register_login",
                newName: "login_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "login_type_id",
                table: "register_login",
                newName: "LoginTypeId");
        }
    }
}
