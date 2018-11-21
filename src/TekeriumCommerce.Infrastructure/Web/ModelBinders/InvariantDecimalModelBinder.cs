using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;

namespace TekeriumCommerce.Infrastructure.Web.ModelBinders
{
    public class InvariantDecimalModelBinder : IModelBinder
    {
        private readonly SimpleTypeModelBinder baseBinder;

        public InvariantDecimalModelBinder(Type modelType, ILoggerFactory loggerFactory)
        {
            baseBinder = new SimpleTypeModelBinder(modelType, loggerFactory);
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext is null) throw new ArgumentNullException(nameof(bindingContext));

            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult != ValueProviderResult.None)
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

                var valueAsString = valueProviderResult.FirstValue;


                if (decimal.TryParse(valueAsString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,
                    out var result))
                {
                    bindingContext.Result = ModelBindingResult.Success(result);
                    return Task.CompletedTask;
                }
            }

            // if we don't handled it, than we'll let the base SimpleTypeModelBinder handle it!
            return baseBinder.BindModelAsync(bindingContext);
        }
    }
}
