using System.ComponentModel.DataAnnotations;
using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Core.Models
{
    public class Entity : EntityBase
    {
        [Required]
        [StringLength(450)]
        public string Slug { get; set; }

        [Required]
        [StringLength(450)]
        public string Name { get; set; }

        // why?
        public long EntityId { get; set; }

        public string EntityTypeId { get; set; }
        public EntityType EntityType { get; set; }
    }
}