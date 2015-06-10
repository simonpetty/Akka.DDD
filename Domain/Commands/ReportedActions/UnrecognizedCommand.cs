using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Files;

namespace Domain.Commands.ReportedActions
{
    class UnrecognizedCommand : ReportedActionCommand
    {
        public UnrecognizedCommand(AbideReport report) : base(report)
        {
        }
    }
}
