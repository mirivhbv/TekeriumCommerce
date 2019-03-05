using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using TekeriumCommerce.Infrastructure;
using TekeriumCommerce.Infrastructure.Models;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Core.Extensions
{
    public static class LocalizationExtensions
    {
        public static string GetLocalized<T>(this T entity, string propertyName, IWorkContext workContext) where T : ILocalizedEntity
        {
            var currentLanguageId = workContext.GetCurrentUser().Result.Culture;
            var en = entity.Locales.FirstOrDefault(x => x.LanguageId == currentLanguageId && x.LocaleKey == propertyName);
            if (en != null)
            {
                return en.LocaleValue;
            }

            var type = entity.GetType();

            return (string)type.GetProperty(propertyName).GetValue(entity);
        }
    }
}
