using System.Collections.Generic;
using TekeriumCommerce.Module.Catalog.Models;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class TyreForm
    {
        public long Id { get; set; }

        public string Size { get; set; }

        public IList<TyreProfileVm> Profiles { get; set; }
    }
}