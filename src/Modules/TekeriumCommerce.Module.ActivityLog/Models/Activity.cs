using System;
using System.ComponentModel.DataAnnotations;

namespace TekeriumCommerce.Module.ActivityLog.Models
{
    public class Activity
    {
        public long ActivityTypeId { get; set; }

        public ActivityType ActivityType { get; set; }

        public long UserId { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public long EntityId { get; set; }

        [Required]
        [StringLength(450)]
        public string EntityTypeId { get; set; }
    }
}