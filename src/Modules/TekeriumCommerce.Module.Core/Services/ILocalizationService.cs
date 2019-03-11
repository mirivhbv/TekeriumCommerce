using System;
using System.Linq.Expressions;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Core.Services
{
    public interface ILocalizationService
    {
        string GetLocalized<TEntity, TPropType>(TEntity entity, Expression<Func<TEntity, TPropType>> keySelector,
            string languageId) where TEntity : ILocalizedEntity;
    }
}