namespace TekeriumCommerce.Infrastructure.Models
{
    public class EntityBaseWithTypedId<TId> : ValidatableObject, IEntityWithTypedId<TId>
    {
        public TId Id { get; protected set; }
    }
}
