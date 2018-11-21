using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Infrastructure.Data
{
    public interface IRepository<T> : IRepositoryWithTypedId<T, long> where T : IEntityWithTypedId<long>
    {
    }
}