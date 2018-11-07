using System.Threading.Tasks;
using TekeriumCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;

namespace TekeriumCommerce.Module.ShoppingCart.Services
{
    public interface ICartService
    {
        Task AddToCart(long userId, long productId, int quantity);

        Task<CartVm> GetCart(long userId);
    }
}
