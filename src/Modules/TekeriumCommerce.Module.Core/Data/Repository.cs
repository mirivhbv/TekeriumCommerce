using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Core.Data
{
    public class Repository<T> : RepositoryWithTypedId<T, long>,  IRepository<T> where T : class, IEntityWithTypedId<long>
    {
        public Repository(TekerDbContext context) : base(context)
        {
        }
    }
}