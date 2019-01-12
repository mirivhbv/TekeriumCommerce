using System.ComponentModel.DataAnnotations;
using TekeriumCommerce.Infrastructure.Models;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Catalog.Models
{
    public class ProductSeason : IEntityWithTypedId<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string MediaUrl { get; set; }
    }
}