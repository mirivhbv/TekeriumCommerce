using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;

namespace TekeriumCommerce.Module.Shipping.Data
{
    public class ShippingCustomDataBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            ShippingSeedData.SeedData(modelBuilder);
        }
    }
}