using System.ComponentModel.DataAnnotations;
using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Shipping.Models
{
    public class City : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Cost { get; set; }
    }
}