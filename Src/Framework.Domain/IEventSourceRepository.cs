namespace Framework.Domain
{
    public interface IEventSourceRepository<T, TKey> where T : AggregateRoot<TKey>
    {
        T GetById(TKey id);
        void AppendEvents(T aggregate);
    }
}