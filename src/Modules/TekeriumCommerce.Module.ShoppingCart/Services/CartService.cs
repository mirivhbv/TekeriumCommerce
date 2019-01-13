using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Core.Services;
using TekeriumCommerce.Module.Shipping.Models;
using TekeriumCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;
using TekeriumCommerce.Module.ShoppingCart.Models;

namespace TekeriumCommerce.Module.ShoppingCart.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly IMediaService _mediaService;
        private readonly IRepository<City> _cityRepository;

        public CartService(IRepository<Cart> cartRepository, IRepository<CartItem> cartItemRepository, IRepository<City> cityRepository, IMediaService mediaService)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _cityRepository = cityRepository;
            _mediaService = mediaService;
        }

        public async Task AddToCart(long userId, long productId, int quantity)
        {
            var cart = _cartRepository.Query().Include(x => x.Items).Include(x => x.City)
                .FirstOrDefault(x => x.UserId == userId && x.IsActive);

            var city = _cityRepository.Query().FirstOrDefault(x => x.Name.ToLowerInvariant() == "baku");

            if (cart is null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    City = city,
                    ShippingAmount = city?.Cost
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
            var cart = _cartRepository.Query().Include(x => x.Items).Include(x => x.City)
                .FirstOrDefault(x => x.UserId == userId && x.IsActive);

            if (cart is null)
            {
                return new CartVm();
            }

            var cartVm = new CartVm
            {
                Id = cart.Id,
                ShippingAmount = cart.City.Cost,
                City = cart.City,
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

        public async Task ChangeShippingAddress(long userId, long cityId)
        {
            var cart = _cartRepository.Query().Include(x => x.Items).Include(x => x.City)
                .FirstOrDefault(x => x.UserId == userId && x.IsActive);
            if (cart != null)
            {
                cart.CityId = cityId;
            }

            await _cartRepository.SaveChangesAsync();
        }
    }
}