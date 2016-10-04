using System.Web.Http;
using BikeRental.Core;
using BikeRental.Interfases.Manager;

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