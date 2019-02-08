using MediatR;
using TekeriumCommerce.Module.Orders.Areas.Orders.ViewModels;

namespace TekeriumCommerce.Module.Orders.Events
{
    public class OrderDetailGot : INotification
    {
        public OrderDetailVm OrderDetailVm { get; set; }
    }
}