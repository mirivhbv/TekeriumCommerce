using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Core.Models
{
    public class Country : IEntityWithTypedId<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string CountryCode { get; set; }
    }
}