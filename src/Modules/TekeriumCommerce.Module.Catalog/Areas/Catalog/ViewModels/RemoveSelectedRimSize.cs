using System.ComponentModel.DataAnnotations;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class RemoveSelectedRimSize
    {
        [Required] public long WidthId { get; set; }
        [Required] public long ProfileId { get; set; }
        [Required] public long RimSizeId { get; set; }
    }
}