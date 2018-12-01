﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TekeriumCommerce.Module.Core.Data;

namespace TekeriumCommerce.WebHost.Migrations
{
    [DbContext(typeof(TekerDbContext))]
    partial class TekerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Core_RoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Core_UserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<long>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("Core_UserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("Core_UserToken");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.ToTable("Catalog_Brand");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("DisplayOrder");

                    b.Property<bool>("IncludeInMenu");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("MetaDescription");

                    b.Property<string>("MetaKeywords");

                    b.Property<string>("MetaTitle");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<long?>("ThumbnailImageId");

                    b.HasKey("Id");

                    b.HasIndex("ThumbnailImageId");

                    b.ToTable("Catalog_Category");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BrandId");

                    b.Property<long?>("CategoryId");

                    b.Property<long?>("CreatedById");

                    b.Property<DateTimeOffset>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<int>("DisplayOrder");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("MetaDescription");

                    b.Property<string>("MetaKeywords");

                    b.Property<string>("MetaTitle");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("NormalizedName");

                    b.Property<decimal?>("OldPrice");

                    b.Property<decimal>("Price");

                    b.Property<DateTimeOffset?>("PublishedOn");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<decimal?>("SpecialPrice");

                    b.Property<DateTimeOffset?>("SpecialPriceEnd");

                    b.Property<DateTimeOffset?>("SpecialPriceStart");

                    b.Property<string>("Specification");

                    b.Property<int>("StockQuantity");

                    b.Property<long?>("ThumbnailImageId");

                    b.Property<long?>("TyreProfileId");

                    b.Property<long?>("TyreRimSizeId");

                    b.Property<long?>("TyreWidthId");

                    b.Property<long?>("UpdatedById");

                    b.Property<DateTimeOffset>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ThumbnailImageId");

                    b.HasIndex("TyreProfileId");

                    b.HasIndex("TyreRimSizeId");

                    b.HasIndex("TyreWidthId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Catalog_Product");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.ProductMedia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DisplayOrder");

                    b.Property<long>("MediaId");

                    b.Property<long>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.HasIndex("ProductId");

                    b.ToTable("Catalog_ProductMedia");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.ProductPriceHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CreatedById");

                    b.Property<DateTimeOffset>("CreatedOn");

                    b.Property<decimal?>("OldPrice");

                    b.Property<decimal?>("Price");

                    b.Property<long?>("ProductId");

                    b.Property<decimal?>("SpecialPrice");

                    b.Property<DateTimeOffset?>("SpecialPriceEnd");

                    b.Property<DateTimeOffset?>("SpecialPriceStart");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ProductId");

                    b.ToTable("Catalog_ProductPriceHistory");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.TyreProfile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CategoryId");

                    b.Property<string>("Size");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Catalog_TyreProfile");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.TyreRimSize", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CategoryId");

                    b.Property<string>("Size");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Catalog_TyreRimSize");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.TyreWidth", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CategoryId");

                    b.Property<string>("Size");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Catalog_TyreWidth");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.TyreWidthProfileRimSize", b =>
                {
                    b.Property<long>("TyreProfileId");

                    b.Property<long>("TyreRimSizeId");

                    b.Property<long>("TyreWidthId");

                    b.Property<long>("Id");

                    b.HasKey("TyreProfileId", "TyreRimSizeId", "TyreWidthId");

                    b.HasIndex("TyreRimSizeId");

                    b.HasIndex("TyreWidthId");

                    b.ToTable("Catalog_TyreWidthProfileRimSize");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Core.Models.AppSetting", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsVisibleInCommonSettingPage");

                    b.Property<string>("Module");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Core_AppSetting");

                    b.HasData(
                        new { Id = "Global.AssetVersion", IsVisibleInCommonSettingPage = true, Module = "Core", Value = "1.0" },
                        new { Id = "Theme", IsVisibleInCommonSettingPage = false, Module = "Core", Value = "Generic" },
                        new { Id = "Catalog.ProductPageSize", IsVisibleInCommonSettingPage = true, Module = "Catalog", Value = "10" }
                    );
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Core.Models.Entity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("EntityId");

                    b.Property<string>("EntityTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("EntityTypeId");

                    b.ToTable("Core_Entity");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Core.Models.EntityType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaName")
                        .HasMaxLength(450);

                    b.Property<bool>("IsMenuable");

                    b.Property<string>("RoutingAction")
                        .HasMaxLength(450);

                    b.Property<string>("RoutingController")
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.ToTable("Core_EntityType");

                    b.HasData(
                        new { Id = "Category", AreaName = "Catalog", IsMenuable = true, RoutingAction = "CategoryDetail", RoutingController = "Category" },
                        new { Id = "Brand", AreaName = "Catalog", IsMenuable = true, RoutingAction = "BrandDetail", RoutingController = "Brand" },
                        new { Id = "Product", AreaName = "Catalog", IsMenuable = false, RoutingAction = "ProductDetail", RoutingController = "Product" }
                    );
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Core.Models.Media", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption");

                    b.Property<string>("FileName");

                    b.Property<int>("FileSize");

                    b.Property<int>("MediaType");

                    b.HasKey("Id");

                    b.ToTable("Core_Media");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Core.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Core_Role");

                    b.HasData(
                        new { Id = 1L, ConcurrencyStamp = "4776a1b2-dbe4-4056-82ec-8bed211d1454", Name = "admin", NormalizedName = "ADMIN" },
                        new { Id = 3L, ConcurrencyStamp = "d4754388-8355-4018-b728-218018836817", Name = "guest", NormalizedName = "GUEST" }
                    );
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Core.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTimeOffset>("CreatedOn");

                    b.Property<string>("Culture");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("RefreshTokenHash");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTimeOffset>("UpdatedOn");

                    b.Property<Guid>("UserGuid");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<long?>("VendorId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Core_User");

                    b.HasData(
                        new { Id = 10L, AccessFailedCount = 0, ConcurrencyStamp = "c83afcbc-312c-4589-bad7-8686bd4754c0", CreatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 190, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), Email = "admin@simplcommerce.com", EmailConfirmed = false, FullName = "Shop Admin", IsDeleted = false, LockoutEnabled = false, NormalizedEmail = "ADMIN@SIMPLCOMMERCE.COM", NormalizedUserName = "ADMIN@SIMPLCOMMERCE.COM", PasswordHash = "AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==", PhoneNumberConfirmed = false, SecurityStamp = "d6847450-47f0-4c7a-9fed-0c66234bf61f", TwoFactorEnabled = false, UpdatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 190, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), UserGuid = new Guid("ed8210c3-24b0-4823-a744-80078cf12eb4"), UserName = "admin@simplcommerce.com" }
                    );
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Core.Models.UserRole", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("Core_UserRole");

                    b.HasData(
                        new { UserId = 10L, RoleId = 1L }
                    );
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Search.Models.Query", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateOn");

                    b.Property<string>("QueryText")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("ResultCount");

                    b.HasKey("Id");

                    b.ToTable("Search_Query");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Shipping.Models.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cost");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Shipping_City");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.ShoppingCart.Models.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<decimal?>("ShippingAmount");

                    b.Property<string>("ShippingData");

                    b.Property<DateTimeOffset?>("UpdatedOn");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCart_Cart");
                });

            modelBuilder.Entity("TekeriumCommerce.Module.ShoppingCart.Models.CartItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CartId");

                    b.Property<DateTimeOffset>("CreatedOn");

                    b.Property<long>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("ShoppingCart_CartItem");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Core.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Core.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Core.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Core.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.Category", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Core.Models.Media", "ThumbnailImage")
                        .WithMany()
                        .HasForeignKey("ThumbnailImageId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.Product", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Catalog.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TekeriumCommerce.Module.Catalog.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TekeriumCommerce.Module.Core.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TekeriumCommerce.Module.Core.Models.Media", "ThumbnailImage")
                        .WithMany()
                        .HasForeignKey("ThumbnailImageId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TekeriumCommerce.Module.Catalog.Models.TyreProfile", "TyreProfile")
                        .WithMany()
                        .HasForeignKey("TyreProfileId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TekeriumCommerce.Module.Catalog.Models.TyreRimSize", "TyreRimSize")
                        .WithMany()
                        .HasForeignKey("TyreRimSizeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TekeriumCommerce.Module.Catalog.Models.TyreWidth", "TyreWidth")
                        .WithMany()
                        .HasForeignKey("TyreWidthId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TekeriumCommerce.Module.Core.Models.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.ProductMedia", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Core.Models.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TekeriumCommerce.Module.Catalog.Models.Product", "Product")
                        .WithMany("Medias")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.ProductPriceHistory", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Core.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TekeriumCommerce.Module.Catalog.Models.Product", "Product")
                        .WithMany("PriceHistories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.TyreProfile", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Catalog.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.TyreRimSize", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Catalog.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.TyreWidth", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Catalog.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Catalog.Models.TyreWidthProfileRimSize", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Catalog.Models.TyreProfile", "TyreProfile")
                        .WithMany("TyreWidthProfileRimSizes")
                        .HasForeignKey("TyreProfileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TekeriumCommerce.Module.Catalog.Models.TyreRimSize", "TyreRimSize")
                        .WithMany("TyreWidthProfileRimSizes")
                        .HasForeignKey("TyreRimSizeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TekeriumCommerce.Module.Catalog.Models.TyreWidth", "TyreWidth")
                        .WithMany("TyreWidthProfileRimSizes")
                        .HasForeignKey("TyreWidthId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Core.Models.Entity", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Core.Models.EntityType", "EntityType")
                        .WithMany()
                        .HasForeignKey("EntityTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TekeriumCommerce.Module.Core.Models.UserRole", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Core.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TekeriumCommerce.Module.Core.Models.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TekeriumCommerce.Module.ShoppingCart.Models.Cart", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.Core.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TekeriumCommerce.Module.ShoppingCart.Models.CartItem", b =>
                {
                    b.HasOne("TekeriumCommerce.Module.ShoppingCart.Models.Cart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TekeriumCommerce.Module.Catalog.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
