using System.ComponentModel.DataAnnotations;

namespace TekeriumCommerce.Module.Orders.Areas.Orders.ViewModels
{
    public class OrderInformationVm
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please insert correct email form")]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [StringLength(450)]
        public string OrderNote { get; set; }
    }
}