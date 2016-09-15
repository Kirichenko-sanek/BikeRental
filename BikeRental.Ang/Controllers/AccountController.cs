using System.Net;
using System.Net.Http;
using System.Web.Http;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.ViewModel.ViewModel;

namespace BikeRental.Ang.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : BaseApiController
    {
        private readonly IUserManager<User> _userManager;

        public AccountController(IUserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage LogIn(HttpRequestMessage request, LoginViewModel model)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    var login = _userManager.LogIn(model);

                    if (login.Error != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new {success = false, error = login.Error});
                    }
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = true, error = login.Error });

                }
                return response;
            });


            
        }
    }
}