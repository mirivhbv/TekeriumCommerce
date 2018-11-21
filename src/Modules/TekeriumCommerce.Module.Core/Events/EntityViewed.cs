using MediatR;

namespace TekeriumCommerce.Module.Core.Events
{
    public class EntityViewed : INotification
    {
        public long EntityId { get; set; }

        public string EntityTypeId { get; set; }
    }
}