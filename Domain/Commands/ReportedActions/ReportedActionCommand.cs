
using Domain.Files;

namespace Domain.Commands.ReportedActions
{
    public abstract class ReportedActionCommand : ICommand
    {
        protected ReportedActionCommand(AbideReport report)
        {
            AggregateId = report.TradeId;
        }

        public string AggregateId { get; private set; }
    }
}
