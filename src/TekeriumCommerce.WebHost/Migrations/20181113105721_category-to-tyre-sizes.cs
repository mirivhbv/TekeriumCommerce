using Microsoft.EntityFrameworkCore.Migrations;

namespace TekeriumCommerce.WebHost.Migrations
{
    public partial class categorytotyresizes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Category_Catalog_Category_ParentId",
                table: "Catalog_Category");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_Category_ParentId",
                table: "Catalog_Category");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Catalog_Category");

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Catalog_TyreWidth",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Catalog_TyreRimSize",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Catalog_TyreProfile",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_TyreWidth_CategoryId",
                table: "Catalog_TyreWidth",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_TyreRimSize_CategoryId",
                table: "Catalog_TyreRimSize",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_TyreProfile_CategoryId",
                table: "Catalog_TyreProfile",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_TyreProfile_Catalog_Category_CategoryId",
                table: "Catalog_TyreProfile",
                column: "CategoryId",
                principalTable: "Catalog_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_TyreRimSize_Catalog_Category_CategoryId",
                table: "Catalog_TyreRimSize",
                column: "CategoryId",
                principalTable: "Catalog_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_TyreWidth_Catalog_Category_CategoryId",
                table: "Catalog_TyreWidth",
                column: "CategoryId",
                principalTable: "Catalog_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_TyreProfile_Catalog_Category_CategoryId",
                table: "Catalog_TyreProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_TyreRimSize_Catalog_Category_CategoryId",
                table: "Catalog_TyreRimSize");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_TyreWidth_Catalog_Category_CategoryId",
                table: "Catalog_TyreWidth");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_TyreWidth_CategoryId",
                table: "Catalog_TyreWidth");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_TyreRimSize_CategoryId",
                table: "Catalog_TyreRimSize");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_TyreProfile_CategoryId",
                table: "Catalog_TyreProfile");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Catalog_TyreWidth");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Catalog_TyreRimSize");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Catalog_TyreProfile");

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "Catalog_Category",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Category_ParentId",
                table: "Catalog_Category",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Category_Catalog_Category_ParentId",
                table: "Catalog_Category",
                column: "ParentId",
                principalTable: "Catalog_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
