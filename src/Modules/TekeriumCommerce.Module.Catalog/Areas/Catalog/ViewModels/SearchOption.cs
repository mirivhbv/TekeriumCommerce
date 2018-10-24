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

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string Sort { get; set; }

        public int? MinPrice { get; set; }

        public int? MaxPrice { get; set; }
    }
}