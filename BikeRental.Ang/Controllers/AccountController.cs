using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using BikeRental.Ang.Providers;
using Microsoft.Owin.Security;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.ViewModel.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace BikeRental.Ang.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IUserManager<User> _userManager;
        

        public AccountController(IUserManager<User> userManager)
        {
            _userManager = userManager;
        }


        [Route("login")]
        [HttpPost]
        public LoginViewModel LogIn(LoginViewModel model)
        {
            var requestParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", model.Email),
                new KeyValuePair<string, string>("password", model.Password)
            };

            /*var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
            var tokenServiceResponse = await testServer.HttpClient.PostAsync(
                Startup.TokenEndpointPath, requestParamsFormUrlEncoded);*/


            var login = _userManager.LogIn(model);

            if (login.Error == "")
            {

                //var provider = new OAuthAuthorizationServerProvider();
                var identity = new ClaimsIdentity();
                identity.AddClaim(new Claim(login.Role, login.Email));

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);


            }

            return login;

        }

        [Route("logoff")]
        [HttpPost]
        public bool LogOff()
        {
            //Membership.ApplicationName = null;
            //Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return true;
        }

        [Route("userInSystem")]
        [HttpPost]
        public long UserInSystem(string userName)
        {
            var user = _userManager.GetUserByEmail(userName);
            if (user == null)
            {
                return 0;
            }
            return user.Id;
        }
    }
}