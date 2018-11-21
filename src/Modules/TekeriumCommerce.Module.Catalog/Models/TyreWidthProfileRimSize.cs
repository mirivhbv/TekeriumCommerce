using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Catalog.Models
{
    public class TyreWidthProfileRimSize : EntityBase
    {
        public long TyreWidthId { get; set; }
        public TyreWidth TyreWidth { get; set; }

        public long TyreProfileId { get; set; }
        public TyreProfile TyreProfile { get; set; }

        public long TyreRimSizeId { get; set; }
        public TyreRimSize TyreRimSize { get; set; }
    }
}