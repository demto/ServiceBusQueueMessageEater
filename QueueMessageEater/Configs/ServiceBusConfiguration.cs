using System.Configuration;
using QueueMessageEater.Contracts;

namespace QueueMessageEater.Configs
{
    public class ServiceBusConfiguration : IServiceBusConfiguration
    {
        public string ServiceBusConnectionString => ConfigurationManager.ConnectionStrings["ServiceBusConnection"].ConnectionString;
    }
}
