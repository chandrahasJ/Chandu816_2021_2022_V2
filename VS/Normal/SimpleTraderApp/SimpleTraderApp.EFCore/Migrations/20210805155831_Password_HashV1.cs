using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleTraderApp.EFCore.Migrations
{
    public partial class Password_HashV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordString",
                table: "Users",
                newName: "PasswordHash");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "PasswordString");
        }
    }
}
