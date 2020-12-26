using System.Collections.Generic;

namespace Framework.Domain
{
    public abstract class AggregateRoot<T> : Entity<T>, IAggregateRoot
    {
        private readonly List<DomainEvent> _uncommittedEvents;
        protected AggregateRoot()
        {
            this._uncommittedEvents = new List<DomainEvent>();    
        }
        public IReadOnlyList<DomainEvent> GetUncommittedEvents() => _uncommittedEvents.AsReadOnly();

        public void Causes(DomainEvent @event)
        {
            _uncommittedEvents.Add(@event);
            Apply(@event);
        }

        public void ApplyAndPublish(DomainEvent @event)
        {
            _uncommittedEvents.Add(@event);
            Apply(@event);
        }

        public  void Apply(DomainEvent @event)
        {
            When(@event);
        }

        protected abstract void When(DomainEvent @event);
    }
}