using System.ComponentModel.DataAnnotations;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class RemoveSelectedProfile
    {
        [Required]
        public long WidthId { get; set; }
        [Required]
        public long ProfileId { get; set; }
    }
}