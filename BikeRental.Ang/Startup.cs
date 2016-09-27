using System;
using BikeRental.Ang.Providers;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(BikeRental.Ang.Startup))]

namespace BikeRental.Ang
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            
        }

        public void ConfigureOAuth(IAppBuilder app)
        {

            OAuthBearerAuthenticationOptions oAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider(MvcApplication._container.Resolve<IUserManager<User>>()),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true         
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(oAuthBearerOptions);
        }

       
    }
}
