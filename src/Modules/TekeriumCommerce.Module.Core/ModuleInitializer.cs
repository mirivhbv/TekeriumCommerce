using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TekeriumCommerce.Infrastructure.Modules;
using TekeriumCommerce.Module.Core.Extensions;
using TekeriumCommerce.Module.Core.Models;
using TekeriumCommerce.Module.Core.Services;

namespace TekeriumCommerce.Module.Core
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            // todo: after make all models insert to service in here

            serviceCollection.AddTransient<IMediaService, MediaService>();
            serviceCollection.AddScoped<SignInManager<User>, TekeriumSignInManager<User>>();
            serviceCollection.AddScoped<IWorkContext, WorkContext>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}