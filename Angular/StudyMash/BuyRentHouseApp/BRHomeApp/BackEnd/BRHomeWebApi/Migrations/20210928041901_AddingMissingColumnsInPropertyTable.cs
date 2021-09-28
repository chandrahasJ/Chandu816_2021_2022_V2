using Microsoft.EntityFrameworkCore.Migrations;

namespace BRHomeWebApi.Migrations
{
    public partial class AddingMissingColumnsInPropertyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstPossesionOn",
                table: "Properties",
                newName: "EstPossessionOn");

            migrationBuilder.AddColumn<int>(
                name: "BHK",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Properties",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BHK",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "EstPossessionOn",
                table: "Properties",
                newName: "EstPossesionOn");
        }
    }
}
