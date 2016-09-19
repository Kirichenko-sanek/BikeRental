using System.Web.Http;
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


        /*public AccountController()
        {
           
        }*/

        public AccountController(IUserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Route("authenticate")]
        [HttpPost]
        public LoginViewModel LogIn(LoginViewModel model)
        {

            var login = _userManager.LogIn(model);
            return login;

        }
    }
}