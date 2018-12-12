using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Catalog.Models
{
    public class ProductSeason : IEntityWithTypedId<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}