using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RegisterLoginAPI.Migrations
{
    public partial class adjustrelationshipbetweenlogin_typeeregister_login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Login_Type",
                table: "login_type");

            migrationBuilder.AddColumn<int>(
                name: "LoginTypeId",
                table: "register_login",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "login_type",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Login_Type",
                table: "register_login");

            migrationBuilder.DropIndex(
                name: "IX_register_login_LoginTypeId",
                table: "register_login");

            migrationBuilder.DropColumn(
                name: "LoginTypeId",
                table: "register_login");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "login_type",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Login_Type",
                table: "login_type",
                column: "id",
                principalTable: "register_login",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
