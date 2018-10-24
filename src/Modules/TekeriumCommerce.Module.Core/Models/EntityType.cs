using System.ComponentModel.DataAnnotations;
using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Core.Models
{
    public class EntityType : EntityBaseWithTypedId<string>
    {
        public EntityType()
        {
        }

        public EntityType(string id)
        {
            Id = id;
        }

        [Required]
        [StringLength(450)]
        public string Name => Id;

        // in my situation it is no need
        public bool IsMenuable { get; set; }

        [StringLength(450)] public string AreaName { get; set; }

        [StringLength(450)] public string RoutingController { get; set; }

        [StringLength(450)] public string RoutingAction { get; set; }
    }
}