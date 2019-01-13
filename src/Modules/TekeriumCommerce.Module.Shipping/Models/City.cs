using System.ComponentModel.DataAnnotations;
using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Shipping.Models
{
    public class City : IEntityWithTypedId<long>
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Cost { get; set; }
    }
}