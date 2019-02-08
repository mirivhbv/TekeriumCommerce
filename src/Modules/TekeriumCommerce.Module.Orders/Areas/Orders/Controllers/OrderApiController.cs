using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Infrastructure.Helpers;
using TekeriumCommerce.Infrastructure.Models;
using TekeriumCommerce.Infrastructure.Web.SmartTable;
using TekeriumCommerce.Module.Core.Extensions;
using TekeriumCommerce.Module.Orders.Areas.Orders.ViewModels;
using TekeriumCommerce.Module.Orders.Events;
using TekeriumCommerce.Module.Orders.Models;

namespace TekeriumCommerce.Module.Orders.Areas.Orders.Controllers
{
    [Area("Orders")]
    [Authorize(Roles = "admin")]
    [Route("api/orders")]
    public class OrderApiController : Controller
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IWorkContext _workContext;
        private readonly IMediator _mediator;

        public OrderApiController(IRepository<Order> orderRepository, IWorkContext workContext, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _workContext = workContext;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get(int status, int numRecords)
        {
            var orderStatus = (OrderStatus)status;
            if (numRecords <= 0 || numRecords > 100)
            {
                numRecords = 5;
            }

            var query = _orderRepository.Query();
            if (orderStatus != 0)
            {
                query = query.Where(x => x.OrderStatus == orderStatus);
            }

            var model = query.OrderByDescending(x => x.CreatedOn)
                .Take(numRecords)
                .Select(x => new
                {
                    x.Id,
                    x.CustomerName,
                    x.OrderTotal,
                    OrderTotalString = x.OrderTotal.ToString("C"),
                    OrderStatus = x.OrderStatus.ToString(),
                    x.CreatedOn
                });

            return Json(model);
        }

        [HttpPost("grid")]
        public ActionResult List([FromBody] SmartTableParam param)
        {
            var query = _orderRepository.Query();

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;
                if (search.Id != null)
                {
                    long id = search.Id;
                    query = query.Where(x => x.Id == id);
                }

                if (search.Status != null)
                {
                    var status = (OrderStatus)search.Status;
                    query = query.Where(x => x.OrderStatus == status);
                }

                if (search.CustomerName != null)
                {
                    string customerName = search.CustomerName;
                    query = query.Where(x => x.CustomerName.Contains(customerName));
                }

                if (search.CreatedOn != null)
                {
                    if (search.CreatedOn.before != null)
                    {
                        DateTimeOffset before = search.CreatedOn.before;
                        query = query.Where(x => x.CreatedOn <= before);
                    }

                    if (search.CreatedOn.after != null)
                    {
                        DateTimeOffset after = search.CreatedOn.after;
                        query = query.Where(x => x.CreatedOn >= after);
                    }
                }
            }

            var orders = query.ToSmartTableResult(
                param,
                order => new
                {
                    order.Id,
                    order.CustomerName,
                    order.OrderTotal,
                    OrderStatus = order.OrderStatus.ToString(),
                    order.CreatedOn
                });

            return Json(orders);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var order = _orderRepository
                .Query()
                .Include(x => x.ShippingCity)
                .Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.ThumbnailImage)
                .FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            var currentUser = await _workContext.GetCurrentUser();

            if (!User.IsInRole("admin"))
            {
                return BadRequest(new { error = "You don't have permission to manage this order." });
            }

            var model = new OrderDetailVm
            {
                Id = order.Id,
                CreatedOn = order.CreatedOn,
                OrderStatus = (int) order.OrderStatus,
                OrderStatusString = order.OrderStatus.ToString(),
                CustomerId = order.CreatedById,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail,
                Subtotal = order.SubTotal,
                ShippingAmount = order.ShippingFeeAmount,
                ShippingCity = order.ShippingCity.Name,
                OrderTotal = order.OrderTotal,
                OrderItems = order.OrderItems.Select(x => new OrderItemVm
                {
                    Id = x.Id,
                    ProductId = x.Product.Id,
                    ProductName = x.Product.Name,
                    ProductPrice = x.ProductPrice,
                    Quantity = x.Quantity
                }).ToList()
            };

            // TODO: mediator publish

            await _mediator.Publish(new OrderDetailGot { OrderDetailVm = model });

            return Json(model);
        }

        [HttpPost("change-order-status/{id}")]
        public async Task<IActionResult> ChangeStatus(long id, [FromBody] OrderStatusForm model)
        {
            var order = _orderRepository.Query().FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin"))
            {
                return BadRequest(new { error = "You don't have permission to manage this order" });
            }

            if (Enum.IsDefined(typeof(OrderStatus), model.StatusId))
            {
                var oldStatus = order.OrderStatus;
                order.OrderStatus = (OrderStatus)model.StatusId;
                await _orderRepository.SaveChangesAsync();

                var orderStatusChanged = new OrderChanged
                {
                    OrderId = order.Id,
                    OldStatus = oldStatus,
                    NewStatus = order.OrderStatus,
                    Order = order,
                    UserId = currentUser.Id,
                    Note = model.Note
                };

                await _mediator.Publish(orderStatusChanged);
                return Accepted();
            }

            return BadRequest(new { Error = "unsupported order status" });
        }

        [HttpGet("order-status")]
        public IActionResult GetOrderStatus()
        {
            var model = EnumHelper.ToDictionary(typeof(OrderStatus)).Select(x => new {Id = x.Key, Name = x.Value});
            return Json(model);
        }
    }
}