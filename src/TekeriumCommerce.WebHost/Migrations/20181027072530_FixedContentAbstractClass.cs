using Microsoft.EntityFrameworkCore.Migrations;

namespace TekeriumCommerce.WebHost.Migrations
{
    public partial class FixedContentAbstractClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductMedia_Core_Content_ProductId",
                table: "Catalog_ProductMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Content_Catalog_Brand_BrandId",
                table: "Core_Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Content_Catalog_Category_CategoryId",
                table: "Core_Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Content_Core_Media_ThumbnailImageId",
                table: "Core_Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Content_Catalog_TyreProfile_TyreProfileId",
                table: "Core_Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Content_Catalog_TyreRimSize_TyreRimSizeId",
                table: "Core_Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Content_Catalog_TyreWidth_TyreWidthId",
                table: "Core_Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Content_Core_User_CreatedById",
                table: "Core_Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Content_Core_User_UpdatedById",
                table: "Core_Content");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Core_Content",
                table: "Core_Content");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Core_Content");

            migrationBuilder.RenameTable(
                name: "Core_Content",
                newName: "Catalog_Product");

            migrationBuilder.RenameIndex(
                name: "IX_Core_Content_UpdatedById",
                table: "Catalog_Product",
                newName: "IX_Catalog_Product_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Core_Content_CreatedById",
                table: "Catalog_Product",
                newName: "IX_Catalog_Product_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Core_Content_TyreWidthId",
                table: "Catalog_Product",
                newName: "IX_Catalog_Product_TyreWidthId");

            migrationBuilder.RenameIndex(
                name: "IX_Core_Content_TyreRimSizeId",
                table: "Catalog_Product",
                newName: "IX_Catalog_Product_TyreRimSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Core_Content_TyreProfileId",
                table: "Catalog_Product",
                newName: "IX_Catalog_Product_TyreProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Core_Content_ThumbnailImageId",
                table: "Catalog_Product",
                newName: "IX_Catalog_Product_ThumbnailImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Core_Content_CategoryId",
                table: "Catalog_Product",
                newName: "IX_Catalog_Product_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Core_Content_BrandId",
                table: "Catalog_Product",
                newName: "IX_Catalog_Product_BrandId");

            migrationBuilder.AlterColumn<int>(
                name: "StockQuantity",
                table: "Catalog_Product",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Catalog_Product",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DisplayOrder",
                table: "Catalog_Product",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalog_Product",
                table: "Catalog_Product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Catalog_Brand_BrandId",
                table: "Catalog_Product",
                column: "BrandId",
                principalTable: "Catalog_Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Catalog_Category_CategoryId",
                table: "Catalog_Product",
                column: "CategoryId",
                principalTable: "Catalog_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Core_User_CreatedById",
                table: "Catalog_Product",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Core_Media_ThumbnailImageId",
                table: "Catalog_Product",
                column: "ThumbnailImageId",
                principalTable: "Core_Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Catalog_TyreProfile_TyreProfileId",
                table: "Catalog_Product",
                column: "TyreProfileId",
                principalTable: "Catalog_TyreProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Catalog_TyreRimSize_TyreRimSizeId",
                table: "Catalog_Product",
                column: "TyreRimSizeId",
                principalTable: "Catalog_TyreRimSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Catalog_TyreWidth_TyreWidthId",
                table: "Catalog_Product",
                column: "TyreWidthId",
                principalTable: "Catalog_TyreWidth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Core_User_UpdatedById",
                table: "Catalog_Product",
                column: "UpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductMedia_Catalog_Product_ProductId",
                table: "Catalog_ProductMedia",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Catalog_Brand_BrandId",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Catalog_Category_CategoryId",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Core_User_CreatedById",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Core_Media_ThumbnailImageId",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Catalog_TyreProfile_TyreProfileId",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Catalog_TyreRimSize_TyreRimSizeId",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Catalog_TyreWidth_TyreWidthId",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Core_User_UpdatedById",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductMedia_Catalog_Product_ProductId",
                table: "Catalog_ProductMedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalog_Product",
                table: "Catalog_Product");

            migrationBuilder.RenameTable(
                name: "Catalog_Product",
                newName: "Core_Content");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Product_UpdatedById",
                table: "Core_Content",
                newName: "IX_Core_Content_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Product_TyreWidthId",
                table: "Core_Content",
                newName: "IX_Core_Content_TyreWidthId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Product_TyreRimSizeId",
                table: "Core_Content",
                newName: "IX_Core_Content_TyreRimSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Product_TyreProfileId",
                table: "Core_Content",
                newName: "IX_Core_Content_TyreProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Product_ThumbnailImageId",
                table: "Core_Content",
                newName: "IX_Core_Content_ThumbnailImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Product_CreatedById",
                table: "Core_Content",
                newName: "IX_Core_Content_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Product_CategoryId",
                table: "Core_Content",
                newName: "IX_Core_Content_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Product_BrandId",
                table: "Core_Content",
                newName: "IX_Core_Content_BrandId");

            migrationBuilder.AlterColumn<int>(
                name: "StockQuantity",
                table: "Core_Content",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Core_Content",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "DisplayOrder",
                table: "Core_Content",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Core_Content",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Core_Content",
                table: "Core_Content",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductMedia_Core_Content_ProductId",
                table: "Catalog_ProductMedia",
                column: "ProductId",
                principalTable: "Core_Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Content_Catalog_Brand_BrandId",
                table: "Core_Content",
                column: "BrandId",
                principalTable: "Catalog_Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Content_Catalog_Category_CategoryId",
                table: "Core_Content",
                column: "CategoryId",
                principalTable: "Catalog_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Content_Core_Media_ThumbnailImageId",
                table: "Core_Content",
                column: "ThumbnailImageId",
                principalTable: "Core_Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Content_Catalog_TyreProfile_TyreProfileId",
                table: "Core_Content",
                column: "TyreProfileId",
                principalTable: "Catalog_TyreProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Content_Catalog_TyreRimSize_TyreRimSizeId",
                table: "Core_Content",
                column: "TyreRimSizeId",
                principalTable: "Catalog_TyreRimSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Content_Catalog_TyreWidth_TyreWidthId",
                table: "Core_Content",
                column: "TyreWidthId",
                principalTable: "Catalog_TyreWidth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Content_Core_User_CreatedById",
                table: "Core_Content",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Content_Core_User_UpdatedById",
                table: "Core_Content",
                column: "UpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
