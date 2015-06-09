using System;
using Domain.Events;
using Domain.Commands;
using Domain.Commands.ReportedActions;
using Domain.Events.Trades;

namespace Domain.Aggregates
{
    public class Trade : Aggregate, 
        IHandleCommand<NewCommand>, 
        IApplyEvent<NewTradeCreated>
    {
        public bool HasBeenCreated { get; set; }
        public string SomeOtherValue { get; set; }

        public void Handle(NewCommand command, IEventSink eventPublisher)
        {
            if (HasBeenCreated)
            {
                eventPublisher.Publish(new CouldNotProcessNewAsTradeAlreadyExists(Id));
            }
            else
            {
                eventPublisher.Publish(new NewTradeCreated(Id, command.SomeData));
            }
        }

        public void Apply(NewTradeCreated @event)
        {
            SomeOtherValue = @event.SomeValue;
            HasBeenCreated = true;
        }
    }
}
