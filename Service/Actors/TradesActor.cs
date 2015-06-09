using System;
using Akka.Actor;
using Domain.Aggregates;
using Domain.Commands;

namespace Service.Actors
{
    public class TradesActor : ReceiveActor
    {
        public TradesActor()
        {
            Receive<ICommand>(x => ForwardCommandToTradeActor(x));
        }

        private void ForwardCommandToTradeActor(ICommand command)
        {
            var tradeActor = Context.Child(command.AggregateId);
            if (tradeActor.Equals(ActorRefs.Nobody))
            {
                tradeActor =
                    Context.ActorOf(Props.Create(() =>
                        new AggregateActor<Trade>(command.AggregateId, TimeSpan.FromSeconds(10))),
                        command.AggregateId);
            }

            tradeActor.Tell(command);
        }
    }
}
