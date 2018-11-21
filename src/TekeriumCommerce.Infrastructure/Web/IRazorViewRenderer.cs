using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TekeriumCommerce.Infrastructure.Web
{
    public interface IRazorViewRenderer
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
