using Domain.Files;

namespace Domain.Commands.ReportedActions
{
    class ImplicitPositionCommand : ReportedActionCommand
    {
        public ImplicitPositionCommand(AbideReport report)
            : base(report)
        {
        }
    }
}
