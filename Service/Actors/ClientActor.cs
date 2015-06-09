using Akka.Actor;
using Domain.ActionTypes;

namespace Service.Actors
{
    class ClientActor : ReceiveActor, IWithUnboundedStash
    {
        private readonly ActionTypeFactory _actionTypeFactory;
        private IActorRef _clientInputReader;
        private IActorRef _tradesActor;
        private IActorRef _positionsActor;

        public IStash Stash { get; set; }

        public ClientActor(ActionTypeFactory actionTypeFactory)
        {
            _actionTypeFactory = actionTypeFactory;
            WaitingForInput();
        }

        protected override void PreStart()
        {
            base.PreStart();
            _clientInputReader = Context.ActorOf(Props.Create(() => new ClientInputActor()), "fileReader");
            _tradesActor = Context.ActorOf(Props.Create(() => new TradesActor()), "trades");
            _positionsActor = Context.ActorOf(Props.Create(() => new PositionsActor()), "positions");
        }

        public void WaitingForInput()
        {
            Receive<ClientInputActor.FileUploaded>(x =>
            {
                _clientInputReader.Tell(x);
                Become(ReadingInput);
            });
        }

        public void ReadingInput()
        {
            Receive<ClientInputActor.FileUploaded>(x =>
            {
                Stash.Stash();
            });

            Receive<ClientInputActor.NewAbideReport>(x =>
            {
                ProcessNewRow(x);
            });

            Receive<ClientInputActor.EndOfFile>(x =>
            {
                Become(WaitingForInput);
                Stash.Unstash();
            });
        }

        public void ProcessNewRow(ClientInputActor.NewAbideReport message)
        {
            if (string.IsNullOrEmpty(message.Report.TradeId))
                return;

            var actionType = _actionTypeFactory.GetActionType(message.Report.ActionType);
            var newMessage = actionType.GetCommand(message.Report);

            if (actionType.PositionNotTransaction)
            {
                _positionsActor.Tell(newMessage);
            }
            else
            {
                _tradesActor.Tell(newMessage);
            }
        }
    }
}
