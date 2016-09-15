using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using BikeRental.Core;
using BikeRental.CW.Installers;
using BikeRental.Data;
using Castle.Windsor;
using FluentValidation.Mvc;

namespace BikeRental.Ang
{
    public class MvcApplication : System.Web.HttpApplication
    {
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
             
            var container = new WindsorContainer().Install(new AdminInstaller());
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

                    if (user != null) roles = user.Roles.Role;//user.Roles;
                }
                //Let us set the Pricipal with our user specific details
                e.User = new System.Security.Principal.GenericPrincipal(
                    new System.Security.Principal.GenericIdentity(email, "Forms"), roles.Split(';'));
            }
            catch (Exception)
            {
                //somehting went wrong
            }
        }
    } 
}
