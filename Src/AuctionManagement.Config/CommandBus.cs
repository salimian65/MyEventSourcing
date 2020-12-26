using Autofac;
using Framework.Application;

namespace AuctionManagement.Config
{
    public class CommandBus : ICommandBus
    {

        private readonly ILifetimeScope _scope;

        public CommandBus(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public void Dispatch<T>(T command)
        {
             var handler = _scope.Resolve<ICommandHandler<T>>();
            handler.Handle(command);

        }
    }
}
