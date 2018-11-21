using System.Collections.Generic;
using TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels;

namespace TekeriumCommerce.Module.Search.Areas.Search.ViewModels
{
    public class SearchResult
    {
        public long BrandId { get; set; }

        public string BrandName { get; set; }

        public string BrandSlug { get; set; }

        public int TotalProduct { get; set; }

        public IList<ProductThumbnail> Products { get; set; } = new List<ProductThumbnail>();

        public SearchOption CurrentSearchOption { get; set; }

        // todo: sort
    }
}