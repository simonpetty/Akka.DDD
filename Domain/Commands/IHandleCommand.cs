using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Events;

namespace Domain.Commands
{
    public interface IHandleCommand<in T> where T : ICommand
    {
        void Handle(T command, IEventSink publisher);
    }
}
