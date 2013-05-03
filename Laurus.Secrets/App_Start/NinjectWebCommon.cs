//[assembly: WebActivator.PreApplicationStartMethod(typeof(Laurus.Secrets.App_Start.NinjectWebCommon), "Start")]
//[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Laurus.Secrets.App_Start.NinjectWebCommon), "Stop")]

//namespace Laurus.Secrets.App_Start
//{
//    using System;
//    using System.Web;

//    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

//    using Ninject;
//    using Ninject.Web.Common;
//    using System.Reflection;
//    using System.Web.Http;

//    public static class NinjectWebCommon 
//    {
//        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

//        /// <summary>
//        /// Starts the application
//        /// </summary>
//        public static void Start() 
//        {
//            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
//            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
//            bootstrapper.Initialize(CreateKernel);
//        }
        
//        /// <summary>
//        /// Stops the application.
//        /// </summary>
//        public static void Stop()
//        {
//            bootstrapper.ShutDown();
//        }
        
//        /// <summary>
//        /// Creates the kernel that will manage your application.
//        /// </summary>
//        /// <returns>The created kernel.</returns>
//        private static IKernel CreateKernel()
//        {
//            var kernel = new StandardKernel();
//            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
//            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
//            RegisterServices(kernel);
//            return kernel;
//        }

//        /// <summary>
//        /// Load your modules or register your services here!
//        /// </summary>
//        /// <param name="kernel">The kernel.</param>
//        private static void RegisterServices(IKernel kernel)
//        {
//            kernel.Load(Assembly.GetExecutingAssembly());
//            //kernel.Bind<IMessageService>().To<MessageService>();
//            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>().InSingletonScope();
//            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
//            kernel.Bind<IUow>().To<Uow>();
//            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
//        }        
//    }
//}
