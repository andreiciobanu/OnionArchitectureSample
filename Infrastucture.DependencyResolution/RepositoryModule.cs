using Core.Infrastructure;
using Infrastructure.Data;
using Ninject.Modules;

namespace Infrastucture.DependencyResolution
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            // Bind repositories
            Bind<IOrderRepository>().To<OrderRepository>();
        }
    }
}
