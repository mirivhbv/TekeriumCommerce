using TekeriumCommerce.Infrastructure.Models;
using TekeriumCommerce.Module.Catalog.Models;

namespace TekeriumCommerce.Module.Orders.Models
{
    public class OrderItem : EntityBase
    {
        public Order Order { get; set; }

        public long OrderId { get; set; }

        public Product Product { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }
    }
}