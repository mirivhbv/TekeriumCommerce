using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Core.Extensions;
using TekeriumCommerce.Module.Orders.Areas.Orders.ViewModels;
using TekeriumCommerce.Module.Orders.Events;
using TekeriumCommerce.Module.Orders.Models;
using TekeriumCommerce.Module.ShoppingCart.Models;

namespace TekeriumCommerce.Module.Orders.Areas.Orders.Controllers
{
    [Area("Orders")]
    public class CheckoutController : Controller
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IWorkContext _workContext;
        private readonly IMediator _mediator;

        public CheckoutController(IRepository<Cart> cartRepository,
                                IWorkContext workContext,
                                IRepository<Order> orderRepository,
                                IMediator mediator)
        {
            _cartRepository = cartRepository;
            _workContext = workContext;
            _orderRepository = orderRepository;
            _mediator = mediator;
        }

        [HttpGet("checkout")]
        public async Task<IActionResult> Index()
        {
            var model = new OrderInformationVm();

            var currentUser = await _workContext.GetCurrentUser();

            var cart = _cartRepository.Query().Include(x => x.Items).FirstOrDefault(x => x.UserId == currentUser.Id && x.IsActive);

            if (cart == null)
            {
                return Redirect("~/");
            }

            // todo: check cart list, if it is empty, redirect to home page. (have written, but haven't checked yet)
            if (cart.Items.Count < 1)
            {
                return Redirect("~/");
            }

            return View(model);
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Index(OrderInformationVm model)
        {
            var currentUser = await _workContext.GetCurrentUser();

            // check model state
            if (ModelState.IsValid)
            {
                var cart = await _cartRepository.Query()
                    .Include(x => x.Items).ThenInclude(x => x.Product)
                    .Include(x => x.City)
                    .Where(x => x.UserId == currentUser.Id && x.IsActive)
                    .FirstOrDefaultAsync();

                if (cart == null)
                {
                    // todo: check this situation: clear cart and post 
                    throw new ApplicationException($"Cart of user {currentUser.Id} cannot be found");
                }

                if (cart.Items.Count < 1)
                {
                    return Redirect("~/");
                }

                // create order and add to repo
                var order = new Order
                {
                    CreatedById = currentUser.Id,
                    ShippingCity = cart.City,
                    CustomerEmail = model.Email,
                    CustomerName = model.Name
                };

                foreach (var cartItem in cart.Items)
                {
                    //if (cartItem.Product.StockQuantity < cartItem.Quantity)
                    //{
                    //    // maybe later it will be deleted (todo: ask to Ayaz)
                    //    throw new ApplicationException($"There are only {cartItem.Product.StockQuantity} items available for {cartItem.Product.Name}");
                    //}

                    var productPrice = cartItem.Product.Price;

                    var orderItem = new OrderItem
                    {
                        Product = cartItem.Product,
                        ProductPrice = productPrice,
                        Quantity = cartItem.Quantity
                    };

                    order.AddOrderItem(orderItem);
                }

                order.SubTotal = order.OrderItems.Sum(x => x.ProductPrice * x.Quantity);
                order.ShippingFeeAmount = order.ShippingCity.Cost;
                order.OrderTotal = order.SubTotal + order.ShippingFeeAmount;

                // if every thing went fine, de-active the cart
                _orderRepository.Add(order);

                cart.IsActive = false;

                // done(works)! todo: check whether order repo save changes would effect to cart repo or not...

                await _orderRepository.SaveChangesAsync();

                await _mediator.Publish(new OrderCreated { OrderId = order.Id, Order = order, UserId = order.CreatedById });

                return Redirect("~/congratulation");
            }
            // todo: add model errors

            return View(model);
        }

        [HttpGet("congratulation")]
        public IActionResult OrderConfirmation()
        {
            return View();
        }
    }
}