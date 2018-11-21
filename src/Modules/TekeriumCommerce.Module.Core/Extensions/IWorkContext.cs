using System.Threading.Tasks;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Core.Extensions
{
    public interface IWorkContext
    {
        Task<User> GetCurrentUser();
    }
}