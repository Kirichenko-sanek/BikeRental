using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using BikeRental.Core;
using BikeRental.CW.Installers;
using BikeRental.CW.WebApi;
using BikeRental.Data;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using FluentValidation.Mvc;

namespace BikeRental.Ang
{
    public class MvcApplication : HttpApplication
    {

        private static IWindsorContainer _container;

        protected void Application_Start(object sender, EventArgs e)
        {
            var config = GlobalConfiguration.Configuration;

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(config);
            GlobalConfiguration.Configuration.EnsureInitialized();

            FluentValidationModelValidatorProvider.Configure();
            
           


            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MapperConfig.RegisterMapping();

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
        

        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported != true) return;
            if (Request.Cookies[FormsAuthentication.FormsCookieName] == null) return;
            try
            {
                //let us take out the username now                
                string email = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                string roles = string.Empty;

                using (DataContext entities = new DataContext())
                {
                    User user = entities.Users.SingleOrDefault(u => u.Email == email);

                    if (user != null) roles = user.Roles.Role;
                }
                e.User = new System.Security.Principal.GenericPrincipal(
                    new System.Security.Principal.GenericIdentity(email, "Forms"), roles.Split(';'));
            }
            catch (Exception)
            {

            }
        }
    } 
}
