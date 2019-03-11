using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Core.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IRepository<LocalizedProperty> _localizedPropertyRepository;

        public LocalizationService(IRepository<LocalizedProperty> localizedPropertyRepository)
        {
            _localizedPropertyRepository = localizedPropertyRepository;
        }

        public string GetLocalized<TEntity, TPropType>(TEntity entity, Expression<Func<TEntity, TPropType>> keySelector, string languageId) where TEntity : ILocalizedEntity
        {
            var prop = ((keySelector.Body as MemberExpression)?.Member as PropertyInfo)?.Name;

            var result = entity.Locales.FirstOrDefault(x => x.LanguageId == languageId && x.LocaleKey == prop)?.LocaleValue;

            return result;
        }
    }
}