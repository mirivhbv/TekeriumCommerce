using System.Linq;
using TekeriumCommerce.Module.ActivityLog.Models;
using TekeriumCommerce.Module.Core.Data;

namespace TekeriumCommerce.Module.ActivityLog.Data
{
    public class ActivityRepository : Repository<Activity>, IActivityTypeRepository
    {
        private const int MostViewActivityTypeId = 1;

        public ActivityRepository(TekerDbContext context) : base(context)
        {
        }

        public IQueryable<MostViewEntityDto> List()
        {
            // todo: get (join)
        }
    }
}