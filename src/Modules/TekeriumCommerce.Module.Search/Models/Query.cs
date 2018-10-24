using System;
using System.ComponentModel.DataAnnotations;
using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Search.Models
{
    public class Query : EntityBase
    {
        [Required]
        [StringLength(500)]
        public string QueryText { get; set; }

        public int ResultCount { get; set; }

        public DateTimeOffset CreateOn { get; set; }
    }
}