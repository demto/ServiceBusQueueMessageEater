using System;
using Microsoft.ServiceBus.Messaging;
using QueueMessageEater.Contracts;

namespace QueueMessageEater
{
    public class MessageEater : IMessageEater
    {
        private readonly IServiceBusConfiguration _configuration;
        private QueueClient _queueClient;

        public MessageEater(IServiceBusConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void CrunchMessages(Action<BrokeredMessage> callBack)
        {
            _queueClient = QueueClient.CreateFromConnectionString(_configuration.ServiceBusConnectionString, "TransferValueStatusUpdates", ReceiveMode.ReceiveAndDelete);
            Process(callBack);
        }

        public void Process(Action<BrokeredMessage> callBack)
        {
            try
            {
                Console.WriteLine("Processing Messages....");
                _queueClient.OnMessage(callBack.Invoke);
                Console.WriteLine("Connected to service bus");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}\n\n{exception.StackTrace}");
                Process(callBack);
            }

        }
    }
}
