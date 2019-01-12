using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class BrandForm
    {
        public BrandVm Brand { get; set; }

        public IFormFile BrandImage { get; set; }
    }
}