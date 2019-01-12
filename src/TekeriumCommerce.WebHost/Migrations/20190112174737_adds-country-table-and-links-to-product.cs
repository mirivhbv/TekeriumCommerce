using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TekeriumCommerce.WebHost.Migrations
{
    public partial class addscountrytableandlinkstoproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "Catalog_Product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Core_Country",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Country", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Core_Country",
                columns: new[] { "Id", "CountryCode", "Name" },
                values: new object[,]
                {
                    { 1L, "AZ", "Azerbaijan" },
                    { 2L, "CN", "China" },
                    { 3L, "FL", "Finland" },
                    { 4L, "RU", "Russia" },
                    { 5L, "TR", "Turkey" },
                    { 6L, "JP", "Japan" },
                    { 7L, "ID", "Indonesia" },
                    { 8L, "KR", "Korea" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Product_CountryId",
                table: "Catalog_Product",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Core_Country_CountryId",
                table: "Catalog_Product",
                column: "CountryId",
                principalTable: "Core_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Core_Country_CountryId",
                table: "Catalog_Product");

            migrationBuilder.DropTable(
                name: "Core_Country");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_Product_CountryId",
                table: "Catalog_Product");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Catalog_Product");
        }
    }
}
