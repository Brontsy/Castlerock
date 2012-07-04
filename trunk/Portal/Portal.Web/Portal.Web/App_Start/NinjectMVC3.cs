[assembly: WebActivator.PreApplicationStartMethod(typeof(Portal.Web.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Portal.Web.App_Start.NinjectMVC3), "Stop")]

namespace Portal.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using Common.Nhibernate;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using NHibernate;
    using Ninject;
    using Ninject.Web.Mvc;
    using Ninject.Web.Mvc.FilterBindingSyntax;
    using Portal.Membership;
    using Portal.Membership.Daos;
    using Portal.Membership.Interfaces;
    using Portal.Web.Areas.Membership.ModelBinders;
    using Portal.Web.Attributes;
    using Portal.Websites;
    using Portal.Websites.Daos;
    using Portal.Websites.Interfaces;
    using Portal.Websites.Models;
    using Ninject.Activation;
    using Castlerock.Properties;
    using Castlerock.Properties.Interfaces;
    using Castlerock.Properties.Models;
    using Common.Exceptions;
    using Portal.Images;
    using Portal.Images.Interfaces;
    using Portal.Images.Storage;
    using Portal.Images.Daos;
    using Portal.FileManager;
    using Portal.FileManager.Interfaces;
    using Portal.Cms;
    using Portal.Cms.Interfaces;
    using Portal.Cms.Persistence;

    public static class NinjectMVC3 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof(HttpApplicationInitializationModule));
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
            //kernel.Bind<IMembershipService>().To<MembershipService>();
            kernel.Bind<IMemberDao>().To<MemberNhibernateDao>();

            kernel.Bind<IWebsiteService>().To<WebsiteService>();
            kernel.Bind<IWebsiteDao>().To<WebsiteNhibernateDao>();

            kernel.Bind<ICmsService>().To<CmsService>();
            kernel.Bind<IPageDao>().To<PageNhibernateDao>();
            kernel.Bind<IControlDao>().To<ControlNhibernateDao>();

            kernel.Bind<IImageService>().To<ImageService>();
            kernel.Bind<IImageStorage>().To<AzureBlobStorage>();
            kernel.Bind<IImageRepository>().To<ImageNhibernateRepository>();

            kernel.Bind<IFileManagerService>().To<FileManagerService>();
            kernel.Bind<IFileStorage>().To<Portal.FileManager.Storage.AzureBlobStorage>();

            kernel.Bind<IExceptionManager>().To<DatabaseExceptionManager>();

            kernel.Bind<IPropertyService>().To<PropertyService>();
            kernel.Bind<IPropertyDao>().To<PropertyNhibernateDao>();

            kernel.Bind<ITransactionManager>().To<NhibernateTransactionManager>();
            kernel.Bind<ISession>().ToMethod(o => NHibernateSessionPerRequest.GetCurrentSession());

            kernel.Bind<MemberModelBinderProvider>().ToSelf();

            kernel.BindFilter<AdministratorFilter>(FilterScope.Controller, 0).WhenControllerHas<AdministratorFilterAttribute>();

            kernel.Bind<IWebsite>().ToMethod(context => new WebsiteProvider(kernel.Get<IWebsiteService>()).Create(context) as IWebsite);
            kernel.Bind<IMembershipService>().To<MembershipService>();//.WithConstructorArgument("website", context => new WebsiteProvider(kernel.Get<IWebsiteService>()).Create(context));

            ModelBinderProviders.BinderProviders.Add(new MemberModelBinderProvider(kernel));
        }        
    }

    public class WebsiteProvider : Provider<IWebsite>
    {
        private IWebsiteService _websiteService = null;
        public WebsiteProvider(IWebsiteService websiteService)
        {
            this._websiteService = websiteService;
        }

        protected override IWebsite CreateInstance(IContext context)
        {
            string host = System.Web.HttpContext.Current.Request.Url.Host;

            if (host.Contains("http://portalmanagement.azurewebsites.net/"))
            {
                host.Replace("portal", string.Empty).Replace(".azurewebsites.net", string.Empty);
            }

            return this._websiteService.GetWebsiteByHostUrl(host.Replace("dev.", string.Empty).Replace("portal.", string.Empty));
        }
    }
}
