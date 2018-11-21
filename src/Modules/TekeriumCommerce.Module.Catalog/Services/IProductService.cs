using System.Threading.Tasks;
using TekeriumCommerce.Module.Catalog.Models;

namespace TekeriumCommerce.Module.Catalog.Services
{
    public interface IProductService
    {
        void Create(Product product);

        void Update(Product product);

        Task Delete(Product product);
    }
}