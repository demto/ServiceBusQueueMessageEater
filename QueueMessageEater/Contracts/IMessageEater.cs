using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace QueueMessageEater.Contracts
{
    public interface IMessageEater
    {
        void CrunchMessages(Action<BrokeredMessage> callBack);
    }
}
