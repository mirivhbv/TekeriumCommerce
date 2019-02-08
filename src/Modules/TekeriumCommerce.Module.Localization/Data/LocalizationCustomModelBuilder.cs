using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Infrastructure.Localization;

namespace TekeriumCommerce.Module.Localization.Data
{
    public class LocalizationCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Culture>().HasData(
                new Culture(GlobalConfiguration.DefaultCulture) { Name = "English (US)" }
            );
            modelBuilder.Entity<Culture>().ToTable("Localization_Culture");
            modelBuilder.Entity<Resource>().ToTable("Localization_Resource");
        }
    }
}