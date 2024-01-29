namespace HotelManagementApp.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; private init; } = Guid.NewGuid();


        protected Entity(Guid id)
        {
            Id = id;
        }

        protected Entity() { }
    }
}
