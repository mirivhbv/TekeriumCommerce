using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TekeriumCommerce.Module.Search.Areas.Search.ViewModels
{
    public class SearchForm
    {
        public string Width { get; set; }

        public IList<SelectListItem> AvailableWidths { get; set; } = new List<SelectListItem>();

        public string Profile { get; set; }

        public IList<SelectListItem> AvailableProfiles { get; set; } = new List<SelectListItem>();

        public string RimSize { get; set; }

        public IList<SelectListItem> AvailableRimSizes { get; set; } = new List<SelectListItem>();

        public string ProductSeason { get; set; }

        // available categories for search tab:
    }
}