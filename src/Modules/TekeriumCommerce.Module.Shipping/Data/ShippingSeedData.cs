using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Module.Shipping.Models;

namespace TekeriumCommerce.Module.Shipping.Data
{
    public static class ShippingSeedData
    {
        public static void SeedData(ModelBuilder builder)
        {
            builder.Entity<City>().HasData(new City {Id = 1L, Name = "Baku", Cost = 10});
        }
    }
}