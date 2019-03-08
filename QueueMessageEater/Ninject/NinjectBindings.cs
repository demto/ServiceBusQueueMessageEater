using Ninject.Extensions.Factory;
using Ninject.Modules;
using QueueMessageEater.Configs;
using QueueMessageEater.Contracts;

namespace QueueMessageEater.Ninject
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IMessageEater>().To<MessageEater>().InTransientScope();
            Bind<IServiceBusConfiguration>().To<ServiceBusConfiguration>().InSingletonScope();

            Bind<IMessageEaterFactory>().ToFactory();
        }
    }
}
