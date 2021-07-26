using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleTraderApp.EFCore.Migrations
{
    public partial class StockToAssetAndSpellingCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock_Symbol",
                table: "AssetTrasactions",
                newName: "Asset_Symbol");

            migrationBuilder.RenameColumn(
                name: "Stock_PricePerShare",
                table: "AssetTrasactions",
                newName: "Asset_PricePerShare");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Asset_Symbol",
                table: "AssetTrasactions",
                newName: "Stock_Symbol");

            migrationBuilder.RenameColumn(
                name: "Asset_PricePerShare",
                table: "AssetTrasactions",
                newName: "Stock_PricePerShare");
        }
    }
}
