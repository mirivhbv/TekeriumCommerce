using Microsoft.EntityFrameworkCore.Migrations;

namespace TekeriumCommerce.WebHost.Migrations
{
    public partial class cityandcarttablechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "ShoppingCart_Cart",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Shipping_City",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.InsertData(
                table: "Shipping_City",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[] { 1L, 10m, "Baku" });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_Cart_CityId",
                table: "ShoppingCart_Cart",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Cart_Shipping_City_CityId",
                table: "ShoppingCart_Cart",
                column: "CityId",
                principalTable: "Shipping_City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Cart_Shipping_City_CityId",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_Cart_CityId",
                table: "ShoppingCart_Cart");

            migrationBuilder.DeleteData(
                table: "Shipping_City",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "ShoppingCart_Cart");

            migrationBuilder.AlterColumn<double>(
                name: "Cost",
                table: "Shipping_City",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
