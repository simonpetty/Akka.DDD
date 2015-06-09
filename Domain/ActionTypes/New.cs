using Domain.Commands;
using Domain.Commands.ReportedActions;
using Domain.Files;

namespace Domain.ActionTypes
{
    public class New : ActionTypeBase
    {
        public New(bool positionNotTransaction) 
            : base(positionNotTransaction)
        {
        }

        public override ReportedActionCommand GetCommand(AbideReport report)
        {
            return new NewCommand(report);
        }
    }
}
