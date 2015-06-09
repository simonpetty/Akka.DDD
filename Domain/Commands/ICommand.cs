using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public interface ICommand
    {
        string AggregateId { get; }
    }
}
