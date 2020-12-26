using System;
using AuctionManagement.Application;
using AuctionManagement.Domain;
using AuctionManagement.Persistance.ES;
using Autofac;
using Framework.Application;
using Framework.Domain;
using Framework.Domain.Testing;

namespace AuctionManagement.Config
{
    public class AuctionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryEventStore>().As<IEventStore>().SingleInstance();
            builder.RegisterType<CommandBus>().As<ICommandBus>().SingleInstance();
            builder.RegisterType<AggregateFactory>().As<IAggregateFactory>().SingleInstance();
            builder.RegisterGeneric(typeof(EventSourceRepository<,>))
                .As(typeof(IEventSourceRepository<,>)).SingleInstance();

            builder.RegisterType<AuctionRepository>().As<IAuctionRepository>().SingleInstance();

            builder.RegisterAssemblyTypes(typeof(AuctionCommandHandlers).Assembly).As(type => type.GetInterfaces())
                .Where(interfacetype => interfacetype.IsClosedTypeOf(typeof(ICommandHandler<>)))
                .InstancePerLifetimeScope();
        }
    }
}
