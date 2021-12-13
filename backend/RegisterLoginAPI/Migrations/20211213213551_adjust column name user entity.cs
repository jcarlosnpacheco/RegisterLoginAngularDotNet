using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterLoginAPI.Migrations
{
    public partial class adjustcolumnnameuserentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_role",
                table: "user",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "user_password",
                table: "user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "user",
                newName: "username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "user",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "user",
                newName: "user_role");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "user",
                newName: "user_password");
        }
    }
}
