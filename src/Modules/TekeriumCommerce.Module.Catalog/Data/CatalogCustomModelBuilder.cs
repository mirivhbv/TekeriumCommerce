using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Catalog.Models;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Catalog.Data
{
    public class CatalogCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TyreWidthProfileRimSize>()
                .HasKey(t => new { t.TyreProfileId, t.TyreRimSizeId, t.TyreWidthId });
            modelBuilder.Entity<TyreWidthProfileRimSize>()
                .HasOne(tp => tp.TyreProfile)
                .WithMany(p => p.TyreWidthProfileRimSizes)
                .HasForeignKey(pt => pt.TyreProfileId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TyreWidthProfileRimSize>()
                .HasOne(tr => tr.TyreRimSize)
                .WithMany(r => r.TyreWidthProfileRimSizes)
                .HasForeignKey(tr => tr.TyreRimSizeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TyreWidthProfileRimSize>()
                .HasOne(tw => tw.TyreWidth)
                .WithMany(t => t.TyreWidthProfileRimSizes)
                .HasForeignKey(tw => tw.TyreWidthId)
                .OnDelete(DeleteBehavior.Cascade);

            // seed data:
            modelBuilder.Entity<AppSetting>().HasData(
                new AppSetting("Catalog.ProductPageSize") { Module = "Catalog", IsVisibleInCommonSettingPage = true, Value = "10" }
            );

            modelBuilder.Entity<EntityType>().HasData(
                new EntityType("Category") { AreaName = "Catalog", RoutingController = "Category", RoutingAction = "CategoryDetail", IsMenuable = true },
                new EntityType("Brand") { AreaName = "Catalog", RoutingController = "Brand", RoutingAction = "BrandDetail", IsMenuable = true },
                new EntityType("Product") { AreaName = "Catalog", RoutingController = "Product", RoutingAction = "ProductDetail", IsMenuable = false }
            );

            modelBuilder.Entity<ProductSeason>().HasData(
                new ProductSeason { Name = "Summer" },
                new ProductSeason { Name = "Winter" },
                new ProductSeason { Name = "Universal" }
            );
        }
    }
}