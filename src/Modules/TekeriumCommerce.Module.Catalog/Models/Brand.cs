using System.ComponentModel.DataAnnotations;
using TekeriumCommerce.Infrastructure.Models;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Catalog.Models
{
    public class Brand : EntityBase
    {
        [Required]
        [StringLength(450)]
        public string Name { get; set; }

        [Required]
        [StringLength(450)]
        public string Slug { get; set; }

        public string Description { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public Media Media { get; set; }

        // public long MediaId { get; set; }
    }
}