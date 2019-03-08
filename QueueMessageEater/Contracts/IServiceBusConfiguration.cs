using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueMessageEater.Contracts
{
    public interface IServiceBusConfiguration
    {
        string ServiceBusConnectionString { get; }
    }
}
