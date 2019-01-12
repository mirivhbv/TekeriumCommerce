using Microsoft.EntityFrameworkCore.Migrations;

namespace TekeriumCommerce.WebHost.Migrations
{
    public partial class addsmediatobrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "Catalog_Brand",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Brand_MediaId",
                table: "Catalog_Brand",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Brand_Core_Media_MediaId",
                table: "Catalog_Brand",
                column: "MediaId",
                principalTable: "Core_Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Brand_Core_Media_MediaId",
                table: "Catalog_Brand");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_Brand_MediaId",
                table: "Catalog_Brand");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Catalog_Brand");
        }
    }
}
