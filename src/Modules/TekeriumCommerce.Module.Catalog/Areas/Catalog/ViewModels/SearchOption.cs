using System.Collections.Generic;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class SearchOption
    {
        public string Query { get; set; } // no need

        public string Width { get; set; }

        public string Profile { get; set; }

        public string RimSize { get; set; }

        public string Brand { get; set; }

        public string Category { get; set; }

        public string ProductSeason { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string Sort { get; set; }

        public int? MinPrice { get; set; }

        public int? MaxPrice { get; set; }

        public Dictionary<string, string> ToDictionary()
        {
            var dict = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(Query))
                dict.Add("query", Query);

            if (!string.IsNullOrWhiteSpace(Brand))
                dict.Add("brand", Brand);

            if (!string.IsNullOrWhiteSpace(Category))
                dict.Add("category", Category);

            if (MinPrice.HasValue)
                dict.Add("minPrice", MinPrice.Value.ToString());

            if (MaxPrice.HasValue)
                dict.Add("maxPrice", MaxPrice.Value.ToString());

            if (!string.IsNullOrWhiteSpace(Sort))
                dict.Add("sort", Sort);

            return dict;
        }
    }
}