using System.Collections.Generic;

namespace TekeriumCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels
{
    public class CartVm
    {
        public long Id { get; set; }

        public decimal SubTotal { get; set; }

        public string SubTotalString => SubTotal.ToString("C");

        public decimal Discount { get; set; }

        public string DiscountString => Discount.ToString("C");

        public decimal? ShippingAmount { get; set; }

        public string ShippingAmountString => ShippingAmount.HasValue ? ShippingAmount.Value.ToString("C") : "-";

        public decimal SubTotalWidthDiscount => SubTotal - Discount;

        public decimal OrderTotal => SubTotal + (ShippingAmount ?? 0) - Discount;

        public string OrderTotalString => OrderTotal.ToString("C");

        public IList<CartItemVm> Items { get; set; } = new List<CartItemVm>();
    }
}