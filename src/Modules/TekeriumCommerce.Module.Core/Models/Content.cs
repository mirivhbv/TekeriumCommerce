using System;
using System.ComponentModel.DataAnnotations;
using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Core.Models
{
    public class Content : EntityBase
    {
        private bool isDeleted;

        protected Content()
        {
            CreatedOn = DateTimeOffset.Now;
            UpdatedOn = DateTimeOffset.Now;
        }

        [Required]
        [StringLength(450)]
        public string Name { get; set; }

        [Required]
        [StringLength(450)]
        public string Slug { get; set; }

        public bool IsPublished { get; set; }

        public DateTimeOffset? PublishedOn { get; set; }

        public bool IsDeleted
        {
            get => isDeleted;
            set { isDeleted = value;
                if (value) IsPublished = false;
            }
        }

        public User CreatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }

        public User UpdatedBy { get; set; }
    }
}