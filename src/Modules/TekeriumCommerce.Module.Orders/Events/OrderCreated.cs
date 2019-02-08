using MediatR;
using TekeriumCommerce.Module.Orders.Models;

namespace TekeriumCommerce.Module.Orders.Events
{
    public class OrderCreated : INotification
    {
        public long OrderId { get; set; }

        public Order Order { get; set; }

        public long UserId { get; set; }
    }
}