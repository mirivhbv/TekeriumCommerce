using Microsoft.EntityFrameworkCore.Migrations;

namespace TekeriumCommerce.WebHost.Migrations
{
    public partial class againordertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Orders_Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Orders_Order",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OrderTotal",
                table: "Orders_Order",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "OrderTotal",
                table: "Orders_Order");
        }
    }
}
