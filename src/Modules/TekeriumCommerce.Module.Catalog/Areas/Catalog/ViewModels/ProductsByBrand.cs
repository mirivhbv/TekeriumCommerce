using System.Collections.Generic;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class ProductsByBrand
    {
        public long BrandId { get; set; }

        public string BrandName { get; set; }

        public string BrandSlug { get; set; }

        public int TotalProduct { get; set; }

        public IList<ProductThumbnail> Products { get; set; } = new List<ProductThumbnail>();

        public FilterOption FilterOption { get; set; }

        public SearchOption CurrentSearchOption { get; set; }

        // todo: sort option
    }
}