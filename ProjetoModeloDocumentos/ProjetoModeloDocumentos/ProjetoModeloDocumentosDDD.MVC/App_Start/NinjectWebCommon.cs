using ProjetoModeloDocumentosDDD.Application;
using ProjetoModeloDocumentosDDD.Application.Interface;
using ProjetoModeloDocumentosDDD.Domain.Interfaces;
using ProjetoModeloDocumentosDDD.Domain.Interfaces.Services;
using ProjetoModeloDocumentosDDD.Domain.Services;
using ProjetoModeloDocumentosDDD.Infra.Data.Repositories;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProjetoModeloDocumentosDDD.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProjetoModeloDocumentosDDD.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ProjetoModeloDocumentosDDD.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
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
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //AppServices -----------------------
            kernel.Bind(typeof (IAppServiceBase<>)).To(typeof (AppServiceBase<>));
            kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();
            kernel.Bind<IUsuarioSystemAppService>().To<UsuarioSystemAppService>();
            kernel.Bind<IRgAppService>().To<RgAppService>();
            kernel.Bind<ICpfAppService>().To<CpfAppService>();
            kernel.Bind<ICnhAppService>().To<CnhAppService>();

            //Services ---------------------
            kernel.Bind(typeof(IServicesBase<>)).To(typeof(ServicesBase<>));
            kernel.Bind<IUsuarioServices>().To<UsuarioServices>();
            kernel.Bind<IUsuarioSystemServices>().To<UsuarioSystemServices>();
            kernel.Bind<IRgServices>().To<RgServices>();
            kernel.Bind<ICpfServices>().To<CpfServices>();
            kernel.Bind<ICnhServices>().To<CnhServices>();

            //Repository ------------------------------
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();
            kernel.Bind<IUsuarioSystemRepository>().To<UsuarioSystemRepository>();
            kernel.Bind<IRgRepository>().To<RgRepository>();
            kernel.Bind<ICpfRepository>().To<CpfRepository>();
            kernel.Bind<ICnhRepository>().To<CnhRepository>();

        }        
    }
}
