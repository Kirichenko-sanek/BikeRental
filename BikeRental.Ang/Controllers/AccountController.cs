using System;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using BikeRental.BL.Manager;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.ViewModel.ViewModel;

namespace BikeRental.Ang.Controllers
{
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
            var login = _userManager.LogIn(model);
            return login;

        }

        [Route("logoff")]
        [HttpPost]
        public bool LogOf()
        {
            FormsAuthentication.SignOut();
            return true;
        }

        [Route("userInSystem")]
        [HttpGet]
        public long UserInSystem()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return 0;
            }
            var user = _userManager.GetUserByEmail(User.Identity.Name);
            return user.Id;
        }
    }
}