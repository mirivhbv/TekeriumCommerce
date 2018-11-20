using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TekeriumCommerce.Infrastructure.Modules;
using TekeriumCommerce.Module.ActivityLog.Data;
using TekeriumCommerce.Module.ActivityLog.Events;
using TekeriumCommerce.Module.Core.Events;

namespace TekeriumCommerce.Module.ActivityLog
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IActivityTypeRepository, ActivityRepository>();
            serviceCollection.AddTransient<INotificationHandler<EntityViewed>, EntityViewedHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}