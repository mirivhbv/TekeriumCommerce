using System.Collections.Generic;
using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Catalog.Models
{
    public class TyreRimSize : EntityBase
    {
        public string Size { get; set; }

        public IList<TyreWidthProfileRimSize> TyreWidthProfileRimSizes { get; set; } =
            new List<TyreWidthProfileRimSize>();
    }
}