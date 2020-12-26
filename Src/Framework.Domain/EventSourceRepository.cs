using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain
{
   public class EventSourceRepository<T, TKey> : IEventSourceRepository<T, TKey> where T : AggregateRoot<TKey>
    {
        private readonly IEventStore eventStore;
        private readonly IAggregateFactory aggregateFactory;

        public EventSourceRepository(IEventStore eventStore, IAggregateFactory aggregateFactory)
        {
            this.eventStore = eventStore;
            this.aggregateFactory = aggregateFactory;
        }

        public T GetById(TKey id)
        {
            var listOfEvents = eventStore.GetEventsOfStream(GetStreamName(id));
            return aggregateFactory.Create<T>(listOfEvents);
        }

        public void AppendEvents(T aggregate)
        {
            var events = aggregate.GetUncommittedEvents();
            eventStore.AppendEvents(GetStreamName(aggregate.Id),events);
        }

        private string GetStreamName(TKey id)
        {
            var type = typeof(T).Name;
            return $"{type}-{id}";
        }
    }
}
 