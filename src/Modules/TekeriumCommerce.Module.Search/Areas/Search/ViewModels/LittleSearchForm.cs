using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TekeriumCommerce.Module.Search.Areas.Search.ViewModels
{
    public class LittleSearchForm
    {
        public IList<SelectListItem> AvailableWidths { get; set; } = new List<SelectListItem>();
    }
}