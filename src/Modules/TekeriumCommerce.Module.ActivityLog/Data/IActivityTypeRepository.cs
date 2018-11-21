using System.Linq;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.ActivityLog.Models;

namespace TekeriumCommerce.Module.ActivityLog.Data
{
    public interface IActivityTypeRepository : IRepository<Activity>
    {
        IQueryable<MostViewEntityDto> List();
    }
}