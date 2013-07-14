using Infrastructure.Services;
using Ninject.Modules;
using Services;

namespace Infrastucture.DependencyResolution
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            // Bind repositories
            Bind<IOrderService>().To<OrderService>();
        }
    }
}
