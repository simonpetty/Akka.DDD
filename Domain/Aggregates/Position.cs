using System;
using Domain.Events;
using Domain.Commands;

namespace Domain.Aggregates
{
    public class Position : Aggregate
    {
        public IEventSink Events { get; set; }
    }
}
