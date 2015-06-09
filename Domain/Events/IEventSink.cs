
namespace Domain.Events
{
    public interface IEventSink
    {
        void Publish(IEvent @event);
    }
}
