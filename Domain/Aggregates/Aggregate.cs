using Domain.Events;
using Domain.Commands;

namespace Domain.Aggregates
{
    public abstract class Aggregate
    {
        public string Id { get; set; }

        public bool ApplyEvent(IEvent message)
        {
            var method = GetType().GetMethod("Apply", new[] {message.GetType()});
            if (method == null)
                return false;
            method.Invoke(this, new object[] {message});
            return true;
        }

        public bool HandleCommand(ICommand message, IEventSink eventPublisher)
        {
            var method = GetType().GetMethod("Handle", new[] { message.GetType(), typeof(IEventSink) });
            if (method == null)
                return false;
            method.Invoke(this, new object[] { message, eventPublisher });
            return true;
        }
    }
}
