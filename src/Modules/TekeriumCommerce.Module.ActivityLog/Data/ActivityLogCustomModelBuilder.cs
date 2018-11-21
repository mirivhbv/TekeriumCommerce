using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.ActivityLog.Models;

namespace TekeriumCommerce.Module.ActivityLog.Data
{
    public class ActivityLogCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().HasIndex(x => x.ActivityTypeId);

            modelBuilder.Entity<ActivityType>().HasData(new ActivityType(1) { Name = "EntityView" });
        }
    }
}