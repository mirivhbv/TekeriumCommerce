using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TekeriumCommerce.Infrastructure.Web
{
    public class ThemeableViewLocationExpander : IViewLocationExpander
    {
        private const string THEME_KEY = "theme";

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            var controllerName = context.ActionContext.ActionDescriptor.DisplayName;
            if (controllerName is null) return;

            context.ActionContext.HttpContext.Request.Cookies.TryGetValue("theme", out var previewvingTheme);
            if (!string.IsNullOrWhiteSpace(previewvingTheme))
                context.Values[THEME_KEY] = previewvingTheme;
            else
            {
                var config = context.ActionContext.HttpContext.RequestServices.GetService<IConfiguration>();
                // default theme from appsettings.json
                context.Values[THEME_KEY] = config["Theme"];
            }
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            context.Values.TryGetValue(THEME_KEY, out var theme);
            if (!string.IsNullOrWhiteSpace(theme) &&
                !string.Equals(theme, "Generic", System.StringComparison.InvariantCultureIgnoreCase))
            {
                var moduleViewLocations = new[]
                {
                    $"/Themes/{theme}/Areas/{{2}}/Views/{{1}}/{{0}}.cshtml",
                    $"/Themes/{theme}/Areas/{{2}}/Views/Shared/{{0}}.cshtml",
                    $"/Themes/{theme}/Views/{{1}}/{{0}}.cshtml",
                    $"/Themes/{theme}/Views/Shared/{{0}}.cshtml"
                };

                viewLocations = moduleViewLocations.Concat(viewLocations);
            }

            return viewLocations;
        }
    }
}