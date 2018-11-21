using System.Collections.Generic;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class TyreProfileVm
    {
        public long Id { get; set; }

        public string Size { get; set; }

        public IEnumerable<TyreRimSizeVm> RimSizes { get; set; }
    }
}