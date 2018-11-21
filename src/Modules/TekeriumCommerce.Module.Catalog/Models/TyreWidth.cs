using System.Collections.Generic;
using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Catalog.Models
{
    public class TyreWidth : EntityBase
    {
        public string Size { get; set; }

        public IList<TyreWidthProfileRimSize> TyreWidthProfileRimSizes { get; set; } =
            new List<TyreWidthProfileRimSize>();

        public long? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}