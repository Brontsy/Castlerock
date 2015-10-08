[assembly: WebActivator.PreApplicationStartMethod(typeof(Portal.Web.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Portal.Web.App_Start.NinjectMVC3), "Stop")]

namespace Portal.Web.App_Start
{
    using System.Reflection;
    using System.Collections;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Castlerock.Properties;
    using Castlerock.Properties.Interfaces;
    using Castlerock.Properties.Models;
    using Common.Exceptions;
    using Common.Nhibernate;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using NHibernate;
    using Ninject;
    using Ninject.Activation;
    using Ninject.Web.Mvc;
    using Ninject.Web.Mvc.FilterBindingSyntax;
    using Portal.Cms;
    using Portal.Cms.Controls;
    using Portal.Cms.Interfaces;
    using Portal.Cms.Persistence;
    using Portal.Events;
    using Portal.Events.Interfaces;
    using Portal.FileManager;
    using Portal.FileManager.Controls;
    using Portal.FileManager.Daos;
    using Portal.FileManager.Interfaces;
    using Portal.Interfaces.Cms;
    using Portal.Membership;
    using Portal.Membership.Daos;
    using Portal.Membership.Interfaces;
    using Portal.Messaging;
    using Portal.Messaging.Interfaces;
    using Portal.Messaging.Repository;
    using Portal.Web.Areas.CMS.ModelBinders;
    using Portal.Web.Areas.Membership.ModelBinders;
    using Portal.Web.Attributes;
    using Portal.Websites;
    using Portal.Websites.Daos;
    using Portal.Websites.Interfaces;
    using Portal.Websites.Models;

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
            kernel.Bind<IRoleDao>().To<RoleNhibernateDao>();
            //kernel.Bind<IMemberDao>().To<MemberPetaPocoDao>();

            kernel.Bind<IWebsiteService>().To<WebsiteService>();
            kernel.Bind<IWebsiteDao>().To<WebsiteDao>();

            kernel.Bind<IMessageService>().To<MessageService>();
            kernel.Bind<IMessageRepository>().To<MessageRepository>();

            kernel.Bind<ICmsService>().To<CmsService>().InRequestScope();
            kernel.Bind<IPageDao>().To<PageNhibernateDao>();
            kernel.Bind<IControlDao>().To<ControlNhibernateDao>();
            kernel.Bind<ITemplateDao>().To<TemplateNhibernateDao>();

            kernel.Bind<IFileManagerService>().To<FileManagerService>();
            //kernel.Bind<IStorageItemRepository>().To<StorageItemNhibernateRepository>();
            kernel.Bind<IStorageItemRepository>().To<Portal.FileManager.Storage.AzureBlobStorage>();
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
            ModelBinderProviders.BinderProviders.Add(new ControlModelBinderProvider(kernel));



            kernel.Bind<IEventService>().To<EventService>();
            kernel.Bind<IEventSubscriber>().To<CmsService>();


            EventBroker.Instance.Subscribers = kernel.GetAll<IEventSubscriber>();


            RegisterControls(kernel);
        }

        private static void RegisterControls(IKernel kernel)
        {
            kernel.Bind<IControl>().To<InternalLink>();
            kernel.Bind<IControl>().To<NavigationControl>();
            kernel.Bind<IControl>().To<NavigationItem>();
            kernel.Bind<IControl>().To<Heading>();
            kernel.Bind<IControl>().To<Html>();
            kernel.Bind<IControl>().To<Image>();
            kernel.Bind<IControl>().To<ImageLink>();
            kernel.Bind<IControl>().To<Link>();
            kernel.Bind<IControl>().To<FileBrowser>();
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

            return this._websiteService.GetWebsiteByHostUrl(host.Replace("csdev.", string.Empty).Replace("dev.", string.Empty).Replace("uat.", string.Empty).Replace("portal.", string.Empty));
        }
    }
}
