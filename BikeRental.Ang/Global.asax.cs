using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using BikeRental.CW.Installers;
using BikeRental.CW.WebApi;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using FluentValidation.Mvc;

namespace BikeRental.Ang
{
    public class MvcApplication : HttpApplication
    {
        public static IWindsorContainer _container;

        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(config);
            GlobalConfiguration.Configuration.EnsureInitialized();

            FluentValidationModelValidatorProvider.Configure();




            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MapperConfig.RegisterMapping();

            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            ConfigureWindsor(GlobalConfiguration.Configuration);
        }


        public static void ConfigureWindsor(HttpConfiguration configuration)
        {
            _container = new WindsorContainer();
            _container.Install(new AdminInstallerApi());
            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(_container);
            configuration.DependencyResolver = dependencyResolver;
        }
    } 
}
