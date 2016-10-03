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
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IUserManager<User> _userManager;
        

        public AccountController(IUserManager<User> userManager)
        {
            _userManager = userManager;
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