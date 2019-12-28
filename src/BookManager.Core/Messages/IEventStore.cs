namespace BookManager.Core.Messages
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
