namespace TekeriumCommerce.Module.Orders.Areas.Orders.ViewModels
{
    public class OrderItemVm
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public int ShippedQuantity { get; set; }

        public decimal TaxPercent { get; set; }

        public decimal Total => Quantity * ProductPrice;

        public decimal RowTotal => Total;

        public string ProductPriceString => ProductPrice.ToString("C");

        public string TotalString => Total.ToString("C");

        public string RowTotalString => RowTotal.ToString("C");
    }
}