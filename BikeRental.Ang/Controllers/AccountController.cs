using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;

namespace BikeRental.Ang.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
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