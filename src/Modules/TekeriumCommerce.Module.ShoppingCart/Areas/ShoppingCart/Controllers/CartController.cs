using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Core.Extensions;
using TekeriumCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;
using TekeriumCommerce.Module.ShoppingCart.Models;
using TekeriumCommerce.Module.ShoppingCart.Services;

namespace TekeriumCommerce.Module.ShoppingCart.Areas.ShoppingCart.Controllers
{
    [Area("ShoppingCart")]
    public class CartController : Controller
    {
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly ICartService _cartService;
        private readonly IWorkContext _workContext;

        public CartController(IRepository<CartItem> cartItemRepository, ICartService cartService, IWorkContext workContext)
        {
            _cartItemRepository = cartItemRepository;
            _cartService = cartService;
            _workContext = workContext;
        }

        [HttpPost("cart/addtocart")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartModel model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            await _cartService.AddToCart(currentUser.Id, model.ProductId, model.Quantity);

            return RedirectToAction("AddToCartResult", new {productId = model.ProductId});
        }

        [HttpGet]
        public async Task<IActionResult> AddToCartResult(long productId)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetCart(currentUser.Id);

            var model = new AddToCartResult
            {
                CartItemCount = cart.Items.Count,
                CartAmount = cart.SubTotal
            };

            var addedProduct = cart.Items.First(x => x.ProductId == productId);
            model.ProductName = addedProduct.ProductName;
            model.ProductImage = addedProduct.ProductImage;
            model.ProductPrice = addedProduct.ProductPrice;
            model.Quantity = addedProduct.Quantity;

            return PartialView(model);
        }

        [HttpGet("cart")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("cart/list")]
        public async Task<IActionResult> List()
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetCart(currentUser.Id);

            return Json(cart);
        }

        [HttpPost("cart/update-quantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] CartQuantityUpdate model)
        {
            var cartItem = _cartItemRepository.Query().FirstOrDefault(x => x.Id == model.CartItemId);
            if (cartItem is null)
            {
                return NotFound();
            }

            cartItem.Quantity = model.Quantity;
            _cartItemRepository.SaveChanges();

            return await List();
        }

        [HttpPost("cart/update-shipping-city")]
        public async Task<IActionResult> UpdateCity([FromBody] long cityId)
        {
            var currentUser = await _workContext.GetCurrentUser();
            await _cartService.ChangeShippingAddress(currentUser.Id, cityId);

            // test:
            return await List();
        }

        [HttpPost("cart/remove")]
        public async Task<IActionResult> Remove([FromBody] long itemId)
        {
            var cartItem = _cartItemRepository.Query().FirstOrDefault(x => x.Id == itemId);
            if (cartItem == null)
            {
                return NotFound();
            }

            _cartItemRepository.Remove(cartItem);
            _cartItemRepository.SaveChanges();

            return await List();
        }
    }
}