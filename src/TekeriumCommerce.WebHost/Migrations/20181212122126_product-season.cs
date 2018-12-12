using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TekeriumCommerce.WebHost.Migrations
{
    public partial class productseason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProductSeasonId",
                table: "Catalog_Product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Catalog_ProductSeason",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_ProductSeason", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Catalog_ProductSeason",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Summer" });

            migrationBuilder.InsertData(
                table: "Catalog_ProductSeason",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2L, "Winter" });

            migrationBuilder.InsertData(
                table: "Catalog_ProductSeason",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3L, "Universal" });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Product_ProductSeasonId",
                table: "Catalog_Product",
                column: "ProductSeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Catalog_ProductSeason_ProductSeasonId",
                table: "Catalog_Product",
                column: "ProductSeasonId",
                principalTable: "Catalog_ProductSeason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Catalog_ProductSeason_ProductSeasonId",
                table: "Catalog_Product");

            migrationBuilder.DropTable(
                name: "Catalog_ProductSeason");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_Product_ProductSeasonId",
                table: "Catalog_Product");

            migrationBuilder.DropColumn(
                name: "ProductSeasonId",
                table: "Catalog_Product");
        }
    }
}
