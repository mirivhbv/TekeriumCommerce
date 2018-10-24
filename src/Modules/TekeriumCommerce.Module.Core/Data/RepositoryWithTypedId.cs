using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Core.Data
{
    public class RepositoryWithTypedId<T, TId> : IRepositoryWithTypedId<T, TId> where T : class, IEntityWithTypedId<TId>
    {
        protected DbContext Context { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public RepositoryWithTypedId(TekerDbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public IQueryable<T> Query()
        {
            return DbSet;
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}