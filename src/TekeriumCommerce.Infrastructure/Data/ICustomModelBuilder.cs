using Microsoft.EntityFrameworkCore;

namespace TekeriumCommerce.Infrastructure.Data
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}