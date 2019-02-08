using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;

namespace TekeriumCommerce.Module.Localization.Extensions
{
    public static class LocalizationServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedLocalization(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddOptions();

            AddLocalizationServices(services);

            return services;
        }

        private static void AddLocalizationServices(IServiceCollection services)
        {
            services.TryAddSingleton<IStringLocalizerFactory, EfStringLocalizerFactory>();
            services.TryAddTransient(typeof(IStringLocalizer<>), typeof(EfStringLocalizer<>));
        }
    }
}