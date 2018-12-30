using Microsoft.EntityFrameworkCore.Migrations;

namespace TekeriumCommerce.WebHost.Migrations
{
    public partial class addsmediaurltoproductseason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MediaUrl",
                table: "Catalog_ProductSeason",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Catalog_ProductSeason",
                keyColumn: "Id",
                keyValue: 1L,
                column: "MediaUrl",
                value: "https://tekerstore.az/front/images/ribbon/summer.png");

            migrationBuilder.UpdateData(
                table: "Catalog_ProductSeason",
                keyColumn: "Id",
                keyValue: 2L,
                column: "MediaUrl",
                value: "https://tekerstore.az/front/images/ribbon/winter.png");

            migrationBuilder.UpdateData(
                table: "Catalog_ProductSeason",
                keyColumn: "Id",
                keyValue: 3L,
                column: "MediaUrl",
                value: "https://tekerstore.az/front/images/ribbon/4_seasons.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaUrl",
                table: "Catalog_ProductSeason");
        }
    }
}
