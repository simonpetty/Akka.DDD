using System;
using Akka.Actor;
using Domain.Aggregates;
using Domain.Commands;

namespace Service.Actors
{
    public class PositionsActor : ReceiveActor
    {
        public PositionsActor()
        {
            Receive<ICommand>(x => ForwardCommandToPositionActor(x));
        }

        private void ForwardCommandToPositionActor(ICommand command)
        {
            var positionActor = Context.Child(command.AggregateId);
            if (positionActor.Equals(ActorRefs.Nobody))
            {
                positionActor =
                    Context.ActorOf(Props.Create(() => 
                        new AggregateActor<Position>(command.AggregateId, TimeSpan.FromSeconds(10))),
                        command.AggregateId);
            }

            positionActor.Tell(command);
        }
    }
}
