using Domain.Commands;
using Domain.Commands.ReportedActions;
using Domain.Files;

namespace Domain.ActionTypes
{
    public class Modify : ActionTypeBase
    {
        public Modify(bool positionNotTransaction) 
            : base(positionNotTransaction)
        {
        }

        public override ReportedActionCommand GetCommand(AbideReport report)
        {
            return new ModifyCommand(report);
        }
    }
}
