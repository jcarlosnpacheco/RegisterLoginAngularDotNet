using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterLoginAPI.Migrations
{
    public partial class removedrelationshipbetweenregister_loginandlogin_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Login_Type",
                table: "register_login");

            migrationBuilder.DropIndex(
                name: "IX_register_login_LoginTypeId",
                table: "register_login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_register_login_LoginTypeId",
                table: "register_login",
                column: "LoginTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Login_Type",
                table: "register_login",
                column: "LoginTypeId",
                principalTable: "login_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
