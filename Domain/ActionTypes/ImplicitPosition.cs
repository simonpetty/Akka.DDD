using Domain.Commands;
using Domain.Commands.ReportedActions;
using Domain.Files;

namespace Domain.ActionTypes
{
    public class ImplicitPosition : ActionTypeBase
    {
        public ImplicitPosition()
            : base(true)
        {
        }

        public override ReportedActionCommand GetCommand(AbideReport report)
        {
            return new ImplicitPositionCommand(report);
        }
    }
}
