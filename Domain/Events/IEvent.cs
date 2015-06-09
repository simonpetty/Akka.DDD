using System;

namespace Domain.Events
{
    public interface IEvent
    {
        string AggregateId { get; }
        DateTime UtcDate { get; }
    }

    public abstract class Event : IEvent
    {
        protected Event(string aggregateId)
        {
            AggregateId = aggregateId;
            UtcDate = DateTime.UtcNow;
        }

        public string AggregateId { get; private set; }

        public DateTime UtcDate { get; private set; }
    }
}
