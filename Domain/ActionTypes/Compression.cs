using Domain.Commands;
using Domain.Commands.ReportedActions;
using Domain.Files;

namespace Domain.ActionTypes
{
    public class Compression : ActionTypeBase
    {
        public Compression(bool positionNotTransaction)
            : base(positionNotTransaction)
        {
        }

        public override ReportedActionCommand GetCommand(AbideReport report)
        {
            return new CompressCommand(report);
        }
    }
}
