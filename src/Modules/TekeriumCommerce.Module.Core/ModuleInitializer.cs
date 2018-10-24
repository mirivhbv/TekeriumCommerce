using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TekeriumCommerce.Infrastructure.Modules;
using TekeriumCommerce.Module.Core.Services;

namespace TekeriumCommerce.Module.Core
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            // todo: after make all models insert to service in here

            serviceCollection.AddTransient<IMediaService, MediaService>();
            serviceCollection.AddTransient<IStorageService, FakeStorageService>(); // temp
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}