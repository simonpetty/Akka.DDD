using System;
using Domain.Commands.ReportedActions;
using Domain.Files;

namespace Domain.ActionTypes
{
    class Unrecognized : ActionTypeBase
    {
        public Unrecognized() 
            : base(false)
        {
        }

        public override ReportedActionCommand GetCommand(AbideReport report)
        {
            return new UnrecognizedCommand(report);
        }
    }
}
