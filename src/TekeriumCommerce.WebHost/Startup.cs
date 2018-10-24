using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TekeriumCommerce.Infrastructure;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Infrastructure.Modules;
using TekeriumCommerce.Infrastructure.Web;
using TekeriumCommerce.Module.Core.Data;
using TekeriumCommerce.WebHost.Extensions;

namespace TekeriumCommerce.WebHost
{
    public class Startup
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;

        public Startup(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // done! todo: global config setup
            GlobalConfiguration.WebRootPath = hostingEnvironment.WebRootPath;
            GlobalConfiguration.ContentRootPath = hostingEnvironment.ContentRootPath;

            // done! todo: adding all modules (from modules dir of src)
            services.AddModules(hostingEnvironment.ContentRootPath);

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // done! todo: add customized data store (for db)
            services.AddCustomizedDataStore(configuration);

            // done! todo: add customized identity
            services.AddCustomizedIdentity(configuration);

            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-2.1
            services.AddHttpClient();

            // done! todo: add IRepository as Transient
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            // done! todo: add IRepositoryWithTypeId as Transient
            services.AddTransient(typeof(IRepositoryWithTypedId<,>), typeof(RepositoryWithTypedId<,>));

            // done! todo: add MediatR and IMediator as Scoped
            services.AddMediatR();
            services.AddScoped<IMediator, SequentialMediator>();

            // todo: add customized location
            // it would be inside of module.localization

            // done! todo: add customized mvc
            services.AddCustomizedMvc(GlobalConfiguration.Modules);

            // done! todo: its for expand razor view engine for .cshtml files (theme specific .cshtml)
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new ThemeableViewLocationExpander());
            });

            // todo: Add Language Direction Tag Helper as Scoped (note: in our situation it is not necessary)
            // for this need to add localization module

            // done! todo: Add Razor View Renderer as Transient
            services.AddTransient<IRazorViewRenderer, RazorViewRenderer>();

            // done! todo: Add cloudscribe.web.pagination to infrastructure project in further
            // todo: read about this
            services.AddCloudscribePagination();

            // build all that services and send to all modules for configuration
            var sp = services.BuildServiceProvider();

            var moduleInitializers = sp.GetServices<IModuleInitializer>();
            foreach (var moduleInitializer in moduleInitializers)
            {
                moduleInitializer.ConfigureServices(services);
            }
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseWhen(
                    context => !context.Request.Path.StartsWithSegments("/api"),
                    a => a.UseExceptionHandler("/Home/Error")
                );
            }

            app.UseWhen(
                context => !context.Request.Path.StartsWithSegments("/api"),
                a => a.UseStatusCodePagesWithReExecute("/Home/ErrorWithCode/{0}") // its for error pages
            );

            // done! todo: use customized static files
            app.UseCustomizedStaticFiles(env);
            app.UseCookiePolicy();
            // done! todo: use customized identity
            app.UseCutomizedIdentity();
            // todo: use customized request location
            // ps. method created but not functioning cos need to add module localization
            app.UseCustomizedRequestLocalization();
            // done! todo: use customized mvc
            app.UseCustomizedMvc();

            // sending app and env to each module in solution
            var moduleInitializers = app.ApplicationServices.GetServices<IModuleInitializer>();
            foreach (var moduleInitializer in moduleInitializers)
            {
                moduleInitializer.Configure(app, env);
            }
        }
    }
}