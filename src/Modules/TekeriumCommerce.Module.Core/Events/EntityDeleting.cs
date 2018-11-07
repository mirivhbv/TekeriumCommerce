using MediatR;

namespace TekeriumCommerce.Module.Core.Events
{
    public class EntityDeleting : INotification
    {
        public long EntityId { get; set; }
    }
}