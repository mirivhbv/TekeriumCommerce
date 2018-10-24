using TekeriumCommerce.Module.Catalog.Models;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class ProductThumbnail
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public decimal Price { get; set; }

        public Media ThumbnailImage { get; set; }

        public string ThumbnailUrl { get; set; }

        public static ProductThumbnail FromProduct(Product product)
        {
            return new ProductThumbnail
            {
                Id = product.Id,
                Name = product.Name,
                Slug = product.Slug,
                Price = product.Price,
                ThumbnailImage = product.ThumbnailImage
            };
        }
    }
}