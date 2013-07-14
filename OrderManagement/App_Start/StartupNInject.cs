[assembly: WebActivator.PreApplicationStartMethod(typeof(AppArch.Web.Ui.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(AppArch.Web.Ui.App_Start.NinjectMVC3), "Stop")]
namespace AppArch.Web.Ui.App_Start
{
    using Infrastucture.DependencyResolution;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common;
    using System.Collections.Generic;

    public static class NinjectMVC3
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            RegisterServices(kernel);

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Add data and infrastructure modules
            var modules = new List<INinjectModule>
                {
                    new RepositoryModule(),
                    new ServicesModule(),
                };

            kernel.Load(modules);
        }
    }
}
