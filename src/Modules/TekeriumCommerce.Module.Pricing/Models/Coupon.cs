using System;
using System.ComponentModel.DataAnnotations;
using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Pricing.Models
{
    public class Coupon : EntityBase
    {
        public Coupon()
        {
            CreatedOn = DateTimeOffset.Now;
        }


        [Required]
        [StringLength(450)]
        public string Code { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}