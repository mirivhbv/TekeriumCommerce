namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class ProductDetail
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        //public string MetaTitle { get; set; }

        //public string MetaKeywords { get; set; }

        //public string MetaDescription { get; set; }

        // todo: change it to calcprice after
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Specification { get; set; }

        public int StockQuantity { get; set; }

    }
}