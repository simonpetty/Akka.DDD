using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.Trades
{
    public class NewTradeCreated : Event
    {
        public NewTradeCreated(string aggregateId, string someValue)
            : base(aggregateId)
        {
            SomeValue = someValue;
        }

        public string SomeValue { get; private set; }
    }
}
