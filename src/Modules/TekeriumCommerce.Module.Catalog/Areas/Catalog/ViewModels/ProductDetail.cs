using System.Collections.Generic;
using TekeriumCommerce.Module.Catalog.Models;
using TekeriumCommerce.Module.Core.Areas.Core.ViewModels;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class ProductDetail
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public CalculatedProductPrice CalculatedProductPrice { get; set; }

        public string Description { get; set; }

        public string Specification { get; set; }

        public int StockQuantity { get; set; }

        public ProductSeason ProductSeason { get; set; }

        public IList<MediaViewModel> Images { get; set; } = new List<MediaViewModel>(); // todo

        public ProductDetailBrand Brand { get; set; }

        public ProductDetailCategory Category { get; set; }

        public string Width { get; set; }

        public string Profile { get; set; }

        public string Rim { get; set; }
    }
}