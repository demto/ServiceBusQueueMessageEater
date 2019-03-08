using System;
using Microsoft.ServiceBus.Messaging;
using Ninject;
using QueueMessageEater.Ninject;

namespace QueueMessageEater
{
    public class Program
    {
        private static MessageEater _messageEaterService;

        private static void Main(string[] args)
        {
            _messageEaterService = new StandardKernel(new NinjectBindings()).Get<MessageEater>();
            _messageEaterService.CrunchMessages(OnMessageCallBack);
            Console.ReadLine();
        }

        private static void OnMessageCallBack(BrokeredMessage message)
        {
            var messageJson = message.GetBody<string>();
            Console.WriteLine($"Eating now: {messageJson}");
        }
    }
}