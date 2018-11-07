using Microsoft.EntityFrameworkCore.Migrations;

namespace TekeriumCommerce.WebHost.Migrations
{
    public partial class f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Catalog_TyreWidthProfileRimSize",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Catalog_TyreWidthProfileRimSize");
        }
    }
}
