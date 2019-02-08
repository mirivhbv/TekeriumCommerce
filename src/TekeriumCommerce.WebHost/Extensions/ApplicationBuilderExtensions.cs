using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using TekeriumCommerce.Infrastructure;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Infrastructure.Localization;
using TekeriumCommerce.Module.Core.Extensions;
using TekeriumCommerce.Module.Localization;

namespace TekeriumCommerce.WebHost.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCutomizedIdentity(this IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseWhen(
                context => context.Request.Path.StartsWithSegments("/api"),
                a => a.Use(async (context, next) =>
                {
                    var principal = new ClaimsPrincipal();
                    // todo: read about that
                    var cookiesAuthResult = await context.AuthenticateAsync("Identity.Application");
                    if (cookiesAuthResult?.Principal != null)
                    {
                        principal.AddIdentities(cookiesAuthResult.Principal.Identities);
                    }

                    var bearerAuthResult = await context.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);
                    if (bearerAuthResult?.Principal != null)
                    {
                        principal.AddIdentities(bearerAuthResult.Principal.Identities);
                    }

                    context.User = principal;
                    await next();
                }));

            return app;
        }

        public static IApplicationBuilder UseCustomizedMvc(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                // done! todo: after adding UrlSlugRoute to Modules.Core, uncomment this
                routes.Routes.Add(new UrlSlugRoute(routes.DefaultHandler));

                routes.MapRoute(name: "areaRoute", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            return app;
        }

        public static IApplicationBuilder UseCustomizedStaticFiles(this IApplicationBuilder app,
            IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    OnPrepareResponse = (context) =>
                    {
                        var headers = context.Context.Response.GetTypedHeaders();
                        headers.CacheControl = new CacheControlHeaderValue
                        {
                            NoCache = true,
                            NoStore = true,
                            MaxAge = TimeSpan.FromDays(-1)
                        };
                    }
                });
            }
            else
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    OnPrepareResponse = (context) =>
                    {
                        var headers = context.Context.Response.GetTypedHeaders();
                        headers.CacheControl = new CacheControlHeaderValue
                        {
                            Public = true,
                            MaxAge = TimeSpan.FromDays(60)
                        };
                    }
                });
            }

            return app;
        }

        public static IApplicationBuilder UseCustomizedRequestLocalization(this IApplicationBuilder app)
        {
            // done! todo: after adding localization module uncomment this

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var cultureRepository =
                    scope.ServiceProvider.GetRequiredService<IRepositoryWithTypedId<Culture, string>>();
                GlobalConfiguration.Cultures = cultureRepository.Query().ToList();
            }

            var supportedCultures = GlobalConfiguration.Cultures.Select(c => c.Id).ToArray();
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures)
                    .SetDefaultCulture(GlobalConfiguration.DefaultCulture)
                    .RequestCultureProviders.Insert(0, new EfRequestCultureProvider());
            });

            return app;
        }
    }
}