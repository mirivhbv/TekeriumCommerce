using System;
using System.Collections.Generic;
using TekeriumCommerce.Infrastructure.Models;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.ShoppingCart.Models
{
    public class Cart : EntityBase
    {
        public Cart()
        {
            CreatedOn = DateTimeOffset.Now;
            IsActive = true;
        }

        public long UserId { get; set; }

        public User User { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public bool IsActive { get; set; }

        public decimal? ShippingAmount { get; set; }

        public IList<CartItem> Items { get; set; } = new List<CartItem>();

        /// <summary>
        /// Json serialized of shipping form
        /// </summary>
        public string ShippingData { get; set; }
    }
}