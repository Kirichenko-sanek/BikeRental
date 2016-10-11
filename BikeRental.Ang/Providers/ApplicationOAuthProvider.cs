using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using Microsoft.Owin.Security.OAuth;

namespace BikeRental.Ang.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserManager<User> _userManager;

        public ApplicationOAuthProvider(IUserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override Task MatchEndpoint(OAuthMatchEndpointContext context)
        {
            if (context.IsTokenEndpoint && context.Request.Method == "OPTIONS")
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "authorization", "Content-Type" });
                context.RequestCompleted();
                return Task.FromResult(0);
            }

            return base.MatchEndpoint(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                bool isValidUser = false;
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                var login = _userManager.LogInApi(context.UserName, context.Password);

                if (login.Error != null)
                {
                    context.SetError("invalid_grant", login.Error);
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", login.Role));
                identity.AddClaim(new Claim("id", Convert.ToString(login.IdUser)));

                context.Validated(identity);
            }
            catch (Exception e)
            {
                var exeption = e;
            }

        }
    }
}