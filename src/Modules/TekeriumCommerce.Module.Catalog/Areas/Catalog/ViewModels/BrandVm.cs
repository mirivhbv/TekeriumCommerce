using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class BrandVm
    {
        public BrandVm()
        {
            IsPublished = true;
        }

        public long Id { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsPublished { get; set; }

        public string BrandImageUrl { get; set; }
    }
}