using System;
using System.Collections.Generic;

namespace TekeriumCommerce.Module.Orders.Areas.Orders.ViewModels
{
    public class OrderDetailVm
    {
        public long Id { get; set; }

        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string OrderStatusString { get; set; }

        public int OrderStatus { get; set; }

        public decimal Subtotal { get; set; }

        public decimal ShippingAmount { get; set; }

        public decimal OrderTotal { get; set; }

        public string ShippingCity { get; set; }

        public string SubtotalString => Subtotal.ToString("C");

        public string ShippingAmountString => ShippingAmount.ToString("C");

        public string OrderTotalString => OrderTotal.ToString("C");

        public IList<OrderItemVm> OrderItems { get; set; } = new List<OrderItemVm>();
    }
}