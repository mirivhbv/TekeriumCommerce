using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TekeriumCommerce.WebHost.Migrations
{
    public partial class firstProductSeedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalog_Brand",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Slug = table.Column<string>(maxLength: 450, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_Brand", x => x.Id);
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
                name: "Core_AppSetting",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Module = table.Column<string>(nullable: true),
                    IsVisibleInCommonSettingPage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_AppSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_EntityType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsMenuable = table.Column<bool>(nullable: false),
                    AreaName = table.Column<string>(maxLength: 450, nullable: true),
                    RoutingController = table.Column<string>(maxLength: 450, nullable: true),
                    RoutingAction = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_EntityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Media",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Caption = table.Column<string>(nullable: true),
                    FileSize = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    MediaType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Role",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserGuid = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(maxLength: 450, nullable: false),
                    VendorId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    RefreshTokenHash = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Search_Query",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QueryText = table.Column<string>(maxLength: 500, nullable: false),
                    ResultCount = table.Column<int>(nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Search_Query", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Core_Entity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Slug = table.Column<string>(maxLength: 450, nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    EntityId = table.Column<long>(nullable: false),
                    EntityTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_Entity_Core_EntityType_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "Core_EntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "Core_RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_RoleClaim_Core_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Core_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_UserClaim_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_Core_UserLogin_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserRole",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Core_UserRole_Core_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Core_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_UserRole_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserToken",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_Core_UserToken_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_Content",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Slug = table.Column<string>(maxLength: 450, nullable: false),
                    MetaTitle = table.Column<string>(nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    PublishedOn = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Specification = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    OldPrice = table.Column<decimal>(nullable: true),
                    SpecialPrice = table.Column<decimal>(nullable: true),
                    SpecialPriceStart = table.Column<DateTimeOffset>(nullable: true),
                    SpecialPriceEnd = table.Column<DateTimeOffset>(nullable: true),
                    StockQuantity = table.Column<int>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    ThumbnailImageId = table.Column<long>(nullable: true),
                    BrandId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<long>(nullable: true),
                    TyrePofileId = table.Column<long>(nullable: true),
                    TyreProfileId = table.Column<long>(nullable: true),
                    TyreWidthId = table.Column<long>(nullable: true),
                    TyreRimSizeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Content", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_Content_Catalog_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Catalog_Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_Content_Catalog_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Catalog_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_Content_Core_Media_ThumbnailImageId",
                        column: x => x.ThumbnailImageId,
                        principalTable: "Core_Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_Content_Catalog_TyreProfile_TyreProfileId",
                        column: x => x.TyreProfileId,
                        principalTable: "Catalog_TyreProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_Content_Catalog_TyreRimSize_TyreRimSizeId",
                        column: x => x.TyreRimSizeId,
                        principalTable: "Catalog_TyreRimSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_Content_Catalog_TyreWidth_TyreWidthId",
                        column: x => x.TyreWidthId,
                        principalTable: "Catalog_TyreWidth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_Content_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_Content_Core_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Core_User",
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

            migrationBuilder.InsertData(
                table: "Core_AppSetting",
                columns: new[] { "Id", "IsVisibleInCommonSettingPage", "Module", "Value" },
                values: new object[,]
                {
                    { "Global.AssetVersion", true, "Core", "1.0" },
                    { "Theme", false, "Core", "Generic" },
                    { "Catalog.ProductPageSize", true, "Catalog", "10" }
                });

            migrationBuilder.InsertData(
                table: "Core_EntityType",
                columns: new[] { "Id", "AreaName", "IsMenuable", "RoutingAction", "RoutingController" },
                values: new object[,]
                {
                    { "Category", "Catalog", true, "CategoryDetail", "Category" },
                    { "Brand", "Catalog", true, "BrandDetail", "Brand" },
                    { "Product", "Catalog", false, "ProductDetail", "Product" }
                });

            migrationBuilder.InsertData(
                table: "Core_Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1L, "4776a1b2-dbe4-4056-82ec-8bed211d1454", "admin", "ADMIN" },
                    { 3L, "d4754388-8355-4018-b728-218018836817", "guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "Core_User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Culture", "Email", "EmailConfirmed", "FullName", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshTokenHash", "SecurityStamp", "TwoFactorEnabled", "UpdatedOn", "UserGuid", "UserName", "VendorId" },
                values: new object[] { 10L, 0, "c83afcbc-312c-4589-bad7-8686bd4754c0", new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 190, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), null, "admin@simplcommerce.com", false, "Shop Admin", false, false, null, "ADMIN@SIMPLCOMMERCE.COM", "ADMIN@SIMPLCOMMERCE.COM", "AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==", null, false, null, "d6847450-47f0-4c7a-9fed-0c66234bf61f", false, new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 190, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("ed8210c3-24b0-4823-a744-80078cf12eb4"), "admin@simplcommerce.com", null });

            migrationBuilder.InsertData(
                table: "Core_UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 10L, 1L });

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
                name: "IX_Catalog_TyreWidthProfileRimSize_TyreRimSizeId",
                table: "Catalog_TyreWidthProfileRimSize",
                column: "TyreRimSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_TyreWidthProfileRimSize_TyreWidthId",
                table: "Catalog_TyreWidthProfileRimSize",
                column: "TyreWidthId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Content_BrandId",
                table: "Core_Content",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Content_CategoryId",
                table: "Core_Content",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Content_ThumbnailImageId",
                table: "Core_Content",
                column: "ThumbnailImageId");

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
                name: "IX_Core_Content_CreatedById",
                table: "Core_Content",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Content_UpdatedById",
                table: "Core_Content",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Entity_EntityTypeId",
                table: "Core_Entity",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Core_Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Core_RoleClaim_RoleId",
                table: "Core_RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Core_User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Core_User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserClaim_UserId",
                table: "Core_UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserLogin_UserId",
                table: "Core_UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserRole_RoleId",
                table: "Core_UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog_ProductMedia");

            migrationBuilder.DropTable(
                name: "Catalog_TyreWidthProfileRimSize");

            migrationBuilder.DropTable(
                name: "Core_AppSetting");

            migrationBuilder.DropTable(
                name: "Core_Entity");

            migrationBuilder.DropTable(
                name: "Core_RoleClaim");

            migrationBuilder.DropTable(
                name: "Core_UserClaim");

            migrationBuilder.DropTable(
                name: "Core_UserLogin");

            migrationBuilder.DropTable(
                name: "Core_UserRole");

            migrationBuilder.DropTable(
                name: "Core_UserToken");

            migrationBuilder.DropTable(
                name: "Search_Query");

            migrationBuilder.DropTable(
                name: "Core_Content");

            migrationBuilder.DropTable(
                name: "Core_EntityType");

            migrationBuilder.DropTable(
                name: "Core_Role");

            migrationBuilder.DropTable(
                name: "Catalog_Brand");

            migrationBuilder.DropTable(
                name: "Catalog_Category");

            migrationBuilder.DropTable(
                name: "Catalog_TyreProfile");

            migrationBuilder.DropTable(
                name: "Catalog_TyreRimSize");

            migrationBuilder.DropTable(
                name: "Catalog_TyreWidth");

            migrationBuilder.DropTable(
                name: "Core_User");

            migrationBuilder.DropTable(
                name: "Core_Media");
        }
    }
}
