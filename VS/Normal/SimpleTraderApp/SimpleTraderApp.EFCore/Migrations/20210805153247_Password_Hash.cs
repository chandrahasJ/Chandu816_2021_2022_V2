using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleTraderApp.EFCore.Migrations
{
    public partial class Password_Hash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordString");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordString",
                table: "Users",
                newName: "Password");
        }
    }
}
