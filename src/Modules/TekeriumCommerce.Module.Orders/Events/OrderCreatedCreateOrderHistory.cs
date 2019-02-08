using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Orders.Models;

namespace TekeriumCommerce.Module.Orders.Events
{
    public class OrderCreatedCreateOrderHistoryHandler : INotificationHandler<OrderCreated>
    {
        private readonly IRepository<OrderHistory> _orderHistoryRepository;

        public OrderCreatedCreateOrderHistoryHandler(IRepository<OrderHistory> orderHistoryRepository)
        {
            _orderHistoryRepository = orderHistoryRepository;
        }

        public async Task Handle(OrderCreated notification, CancellationToken cancellationToken)
        {
            var orderHistory = new OrderHistory
            {
                OrderId = notification.OrderId,
                CreatedOn = DateTimeOffset.Now,
                CreatedById = notification.UserId,
                NewStatus = OrderStatus.New,
            };

            if (notification.Order != null)
            {
                orderHistory.OrderSnapshot = JsonConvert.SerializeObject(notification.Order);
            }

            _orderHistoryRepository.Add(orderHistory);
            await _orderHistoryRepository.SaveChangesAsync();
        }
    }
}