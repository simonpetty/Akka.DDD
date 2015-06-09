using Domain.Files;

namespace Domain.Commands.ReportedActions
{
    class CompressCommand : ReportedActionCommand
    {
        public CompressCommand(AbideReport report)
            : base(report)
        {
        }
    }
}
