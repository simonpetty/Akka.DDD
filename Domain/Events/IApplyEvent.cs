using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    interface IApplyEvent<in T> where T : IEvent
    {
        void Apply(T @event);
    }
}
