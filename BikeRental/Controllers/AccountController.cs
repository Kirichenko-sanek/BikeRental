using System.Web.Mvc;
using System.Web.Security;
using BikeRental.Core;
using BikeRental.Filters;
using BikeRental.Interfases.Manager;
using BikeRental.ViewModel;

namespace BikeRental.Controllers
{
    [Culture]
    public class AccountController : Controller
    {
        private readonly IUserManager<User> _userManager;

        public AccountController(IUserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LoginViewModel model)
        {
            var login = _userManager.LogIn(model);

            if (login.Error != null)
            {
                return View(login);
            }
            Session["UserId"] = login.IdUser;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}