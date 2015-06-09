using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.Trades
{
    class CouldNotProcessNewAsTradeAlreadyExists : Event
    {
        public CouldNotProcessNewAsTradeAlreadyExists(string aggregateId)
            : base(aggregateId)
        {
        }
    }
}
