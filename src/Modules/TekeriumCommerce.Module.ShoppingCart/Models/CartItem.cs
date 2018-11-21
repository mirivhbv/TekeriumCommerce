using System;
using TekeriumCommerce.Infrastructure.Models;
using TekeriumCommerce.Module.Catalog.Models;

namespace TekeriumCommerce.Module.ShoppingCart.Models
{
    public class CartItem : EntityBase
    {
        public DateTimeOffset CreatedOn { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public long CartId { get; set; }

        public Cart Cart { get; set; }
    }
}