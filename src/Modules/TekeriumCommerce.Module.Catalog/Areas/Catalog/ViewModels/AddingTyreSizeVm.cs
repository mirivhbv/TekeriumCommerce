using System.ComponentModel.DataAnnotations;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class AddingTyreSizeVm
    {
        [Required]
        public long CategoryId { get; set; }

        [Required]
        public string Size { get; set; }
    }
}