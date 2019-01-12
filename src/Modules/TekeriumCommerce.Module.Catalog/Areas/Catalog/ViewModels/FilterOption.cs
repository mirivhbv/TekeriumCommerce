using System.Collections.Generic;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class FilterOption
    {
        public IList<FilterBrand> Brands { get; set; } = new List<FilterBrand>();

        public FilterPrice Price { get; set; } = new FilterPrice();
    }
}