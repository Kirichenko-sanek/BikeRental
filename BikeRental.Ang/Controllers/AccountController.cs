using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
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
        public string UserInSystem()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var role = identity.Claims.Where(c => c.Type == "role").Select(c => c.Value).SingleOrDefault();
            return role;
        }
    }
}