using System;
using Akka.Actor;
using Akka.Persistence;
using Domain.Aggregates;
using Domain.Commands;
using Domain.Events;

namespace Service.Actors
{
    public class AggregateActor<T> : PersistentActor, IEventSink where T : Aggregate, new()
    {
        private readonly TimeSpan _timeOut;
        private T _state;

        public AggregateActor(string id, TimeSpan timeOut)
        {
            _timeOut = timeOut;
            _state = new T {Id = id};
        }

        public override string PersistenceId
        {
            get { return string.Format("{0}-{1}", typeof(T).Name, _state.Id).ToLowerInvariant(); }
        }

        public void Publish(IEvent @event)
        {
            Persist(@event, x =>
            {
                _state.ApplyEvent(@event);
                Context.System.EventStream.Publish(@event);
            });
        }

        public void ReplyWith(IEvent @event)
        {
            Persist(@event, x =>
            {
                _state.ApplyEvent(@event);
                Context.Sender.Tell(@event);
            });
        }

        protected override bool ReceiveRecover(object message)
        {
            if (message is RecoveryCompleted)
            {
                Context.SetReceiveTimeout(_timeOut);
                return true;
            }

            if (message is SnapshotOffer)
            {
                var snapshot = ((SnapshotOffer) message).Snapshot as T;
                if (snapshot == null) 
                    return false;
                _state = snapshot;
                return true;
            }

            if (message is IEvent)
            {
                return _state.ApplyEvent((IEvent)message);
            }

            return false;
        }

        protected override bool ReceiveCommand(object message)
        {
            if (message is ReceiveTimeout)
            {
                SaveSnapshot(_state);
                Context.Stop(Self);
                return true;
            }

            Context.SetReceiveTimeout(_timeOut);

            if (message is ICommand)
            {
                return _state.HandleCommand((ICommand) message, this);
            }

            return false;
        }
    }
}
