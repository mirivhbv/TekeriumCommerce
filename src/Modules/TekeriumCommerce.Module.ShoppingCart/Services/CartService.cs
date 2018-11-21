using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Core.Services;
using TekeriumCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;
using TekeriumCommerce.Module.ShoppingCart.Models;

namespace TekeriumCommerce.Module.ShoppingCart.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly IMediaService _mediaService;

        public CartService(IRepository<Cart> cartRepository, IRepository<CartItem> cartItemRepository, IMediaService mediaService)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _mediaService = mediaService;
        }

        public async Task AddToCart(long userId, long productId, int quantity)
        {
            var cart = _cartRepository.Query().Include(x => x.Items)
                .FirstOrDefault(x => x.UserId == userId && x.IsActive);

            if (cart is null)
            {
                cart = new Cart
                {
                    UserId = userId
                };
                _cartRepository.Add(cart);
            }

            var cartItem = cart.Items.FirstOrDefault(x => x.ProductId == productId);
            if (cartItem is null)
            {
                cartItem = new CartItem
                {
                    Cart = cart,
                    ProductId = productId,
                    Quantity = quantity,
                    CreatedOn = DateTimeOffset.Now
                };
                cart.Items.Add(cartItem);
            }
            else
            {
                cartItem.Quantity = quantity;
            }

            await _cartRepository.SaveChangesAsync();
        }

        // TODO: separate getting product thumbnail, varation options from here
        public async Task<CartVm> GetCart(long userId)
        {
            var cart = _cartRepository.Query().Include(x => x.Items)
                .FirstOrDefault(x => x.UserId == userId && x.IsActive);
            if (cart is null)
            {
                return new CartVm();
            }

            var cartVm = new CartVm
            {
                Id = cart.Id,
                ShippingAmount = cart.ShippingAmount,
                Items = _cartItemRepository
                    .Query()
                    .Include(x => x.Product).ThenInclude(x => x.ThumbnailImage)
                    .Where(x => x.CartId == cart.Id)
                    .Select(x => new CartItemVm
                    {
                        Id = x.Id,
                        ProductId = x.ProductId,
                        ProductName = x.Product.Name,
                        ProductPrice = x.Product.Price,
                        ProductImage = _mediaService.GetThumbnailUrl(x.Product.ThumbnailImage),
                        Quantity = x.Quantity
                    }).ToList()
            };

            cartVm.SubTotal = cartVm.Items.Sum(x => x.Quantity * x.ProductPrice);

            return cartVm;
        }
    }
}