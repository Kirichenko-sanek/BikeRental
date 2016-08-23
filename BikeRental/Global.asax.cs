using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using BikeRental.Core;
using BikeRental.CW.Installers;
using BikeRental.Data;
using Castle.Windsor;

namespace BikeRental
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
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

                    roles = user.Roles.Role;//user.Roles;
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
