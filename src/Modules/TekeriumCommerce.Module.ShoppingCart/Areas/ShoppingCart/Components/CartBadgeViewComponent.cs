using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TekeriumCommerce.Infrastructure.Web;
using TekeriumCommerce.Module.Core.Extensions;
using TekeriumCommerce.Module.ShoppingCart.Services;

namespace TekeriumCommerce.Module.ShoppingCart.Areas.ShoppingCart.Components
{
    public class CartBadgeViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly IWorkContext _workContext;

        public CartBadgeViewComponent(ICartService cartService, IWorkContext workContext)
        {
            _cartService = cartService;
            _workContext = workContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetCart(currentUser.Id);

            return View(this.GetViewPath(), cart.Items.Count);
        }
    }
}