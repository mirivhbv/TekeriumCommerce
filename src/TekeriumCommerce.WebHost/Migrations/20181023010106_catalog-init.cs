using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TekeriumCommerce.WebHost.Migrations
{
    public partial class cataloginit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Core_Content",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OldPrice",
                table: "Core_Content",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Core_Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Core_Content",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SpecialPrice",
                table: "Core_Content",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ThumbnailImageId",
                table: "Core_Content",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TyreBrandId",
                table: "Core_Content",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TyrePofileId",
                table: "Core_Content",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TyreProfileId",
                table: "Core_Content",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TyreRimSizeId",
                table: "Core_Content",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TyreWidthId",
                table: "Core_Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Core_Content",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Catalog_Category",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Slug = table.Column<string>(maxLength: 450, nullable: false),
                    MetaTitle = table.Column<string>(nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    IncludeInMenu = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ParentId = table.Column<long>(nullable: true),
                    ThumbnailImageId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_Category_Catalog_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Catalog_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Catalog_Category_Core_Media_ThumbnailImageId",
                        column: x => x.ThumbnailImageId,
                        principalTable: "Core_Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_ProductMedia",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<long>(nullable: false),
                    MediaId = table.Column<long>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_ProductMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductMedia_Core_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Core_Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductMedia_Core_Content_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Core_Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_TyreProfile",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_TyreProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_TyreRimSize",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_TyreRimSize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_TyreVendor",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_TyreVendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_TyreWidth",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_TyreWidth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_TyreBrand",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Slug = table.Column<string>(maxLength: 450, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TyreVendorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_TyreBrand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_TyreBrand_Catalog_TyreVendor_TyreVendorId",
                        column: x => x.TyreVendorId,
                        principalTable: "Catalog_TyreVendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_TyreWidthProfileRimSize",
                columns: table => new
                {
                    TyreWidthId = table.Column<long>(nullable: false),
                    TyreProfileId = table.Column<long>(nullable: false),
                    TyreRimSizeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_TyreWidthProfileRimSize", x => new { x.TyreProfileId, x.TyreRimSizeId, x.TyreWidthId });
                    table.ForeignKey(
                        name: "FK_Catalog_TyreWidthProfileRimSize_Catalog_TyreProfile_TyreProfileId",
                        column: x => x.TyreProfileId,
                        principalTable: "Catalog_TyreProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_TyreWidthProfileRimSize_Catalog_TyreRimSize_TyreRimSizeId",
                        column: x => x.TyreRimSizeId,
                        principalTable: "Catalog_TyreRimSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_TyreWidthProfileRimSize_Catalog_TyreWidth_TyreWidthId",
                        column: x => x.TyreWidthId,
                        principalTable: "Catalog_TyreWidth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Core_AppSetting",
                columns: new[] { "Id", "IsVisibleInCommonSettingPage", "Module", "Value" },
                values: new object[] { "Catalog.ProductPageSize", true, "Catalog", "10" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_Content_ThumbnailImageId",
                table: "Core_Content",
                column: "ThumbnailImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Content_TyreBrandId",
                table: "Core_Content",
                column: "TyreBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Content_TyreProfileId",
                table: "Core_Content",
                column: "TyreProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Content_TyreRimSizeId",
                table: "Core_Content",
                column: "TyreRimSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Content_TyreWidthId",
                table: "Core_Content",
                column: "TyreWidthId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Category_ParentId",
                table: "Catalog_Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Category_ThumbnailImageId",
                table: "Catalog_Category",
                column: "ThumbnailImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductMedia_MediaId",
                table: "Catalog_ProductMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductMedia_ProductId",
                table: "Catalog_ProductMedia",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_TyreBrand_TyreVendorId",
                table: "Catalog_TyreBrand",
                column: "TyreVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_TyreWidthProfileRimSize_TyreRimSizeId",
                table: "Catalog_TyreWidthProfileRimSize",
                column: "TyreRimSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_TyreWidthProfileRimSize_TyreWidthId",
                table: "Catalog_TyreWidthProfileRimSize",
                column: "TyreWidthId");

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Content_Core_Media_ThumbnailImageId",
                table: "Core_Content",
                column: "ThumbnailImageId",
                principalTable: "Core_Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Content_Catalog_TyreBrand_TyreBrandId",
                table: "Core_Content",
                column: "TyreBrandId",
                principalTable: "Catalog_TyreBrand",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Core_Content_Core_Media_ThumbnailImageId",
                table: "Core_Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Content_Catalog_TyreBrand_TyreBrandId",
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

            migrationBuilder.DropTable(
                name: "Catalog_Category");

            migrationBuilder.DropTable(
                name: "Catalog_ProductMedia");

            migrationBuilder.DropTable(
                name: "Catalog_TyreBrand");

            migrationBuilder.DropTable(
                name: "Catalog_TyreWidthProfileRimSize");

            migrationBuilder.DropTable(
                name: "Catalog_TyreVendor");

            migrationBuilder.DropTable(
                name: "Catalog_TyreProfile");

            migrationBuilder.DropTable(
                name: "Catalog_TyreRimSize");

            migrationBuilder.DropTable(
                name: "Catalog_TyreWidth");

            migrationBuilder.DropIndex(
                name: "IX_Core_Content_ThumbnailImageId",
                table: "Core_Content");

            migrationBuilder.DropIndex(
                name: "IX_Core_Content_TyreBrandId",
                table: "Core_Content");

            migrationBuilder.DropIndex(
                name: "IX_Core_Content_TyreProfileId",
                table: "Core_Content");

            migrationBuilder.DropIndex(
                name: "IX_Core_Content_TyreRimSizeId",
                table: "Core_Content");

            migrationBuilder.DropIndex(
                name: "IX_Core_Content_TyreWidthId",
                table: "Core_Content");

            migrationBuilder.DeleteData(
                table: "Core_AppSetting",
                keyColumn: "Id",
                keyValue: "Catalog.ProductPageSize");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Core_Content");

            migrationBuilder.DropColumn(
                name: "OldPrice",
                table: "Core_Content");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Core_Content");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Core_Content");

            migrationBuilder.DropColumn(
                name: "SpecialPrice",
                table: "Core_Content");

            migrationBuilder.DropColumn(
                name: "ThumbnailImageId",
                table: "Core_Content");

            migrationBuilder.DropColumn(
                name: "TyreBrandId",
                table: "Core_Content");

            migrationBuilder.DropColumn(
                name: "TyrePofileId",
                table: "Core_Content");

            migrationBuilder.DropColumn(
                name: "TyreProfileId",
                table: "Core_Content");

            migrationBuilder.DropColumn(
                name: "TyreRimSizeId",
                table: "Core_Content");

            migrationBuilder.DropColumn(
                name: "TyreWidthId",
                table: "Core_Content");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Core_Content");
        }
    }
}
