using Domain.Files;

namespace Domain.Commands.ReportedActions
{
    public class NewCommand : ReportedActionCommand
    {
        public NewCommand(AbideReport report)
            : base(report)
        {
            SomeData = report.OtherStuff;
        }

        public string SomeData { get; private set; }
    }
}
