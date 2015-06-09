using Domain.Commands.ReportedActions;
using Domain.Files;

namespace Domain.ActionTypes
{
    public abstract class ActionTypeBase
    {
        protected ActionTypeBase(bool positionNotTransaction)
        {
            PositionNotTransaction = positionNotTransaction;
        }

        public bool PositionNotTransaction { get; private set; }

        public abstract ReportedActionCommand GetCommand(AbideReport report);
    }
}
