using System.ComponentModel.DataAnnotations;
using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.ActivityLog.Models
{
    public class ActivityType : EntityBase
    {
        public ActivityType(long id)
        {
            Id = id;
        }

        [Required]
        [StringLength(450)]
        public string Name { get; set; }
    }
}