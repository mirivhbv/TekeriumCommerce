using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TekeriumCommerce.Infrastructure.Models;
using TekeriumCommerce.Module.Core.Models;
using TekeriumCommerce.Module.Shipping.Models;

namespace TekeriumCommerce.Module.Orders.Models
{
    public class Order : EntityBase
    {
        public Order()
        {
            CreatedOn = DateTimeOffset.Now;
            UpdateOn = DateTimeOffset.Now;
            OrderStatus = OrderStatus.New;
        }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdateOn { get; set; }

        public long CreatedById { get; set; }

        [JsonIgnore]
        public User CreatedBy { get; set; }

        public decimal SubTotal { get; set; }

        public decimal OrderTotal { get; set; }

        public decimal ShippingFeeAmount { get; set; }

        public City ShippingCity { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        // todo: shipping address 

        public IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public OrderStatus OrderStatus { get; set; }

        public void AddOrderItem(OrderItem item)
        {
            item.Order = this;
            OrderItems.Add(item);
        }
    }
}