using Domain.Files;

namespace Domain.Commands.ReportedActions
{
    class ModifyCommand : ReportedActionCommand
    {
        public ModifyCommand(AbideReport report)
            : base(report)
        {
        }
    }
}
