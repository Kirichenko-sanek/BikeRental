using System;
using System.Web.Mvc;
using System.Web.Security;
using BikeRental.App_GlobalResources;
using BikeRental.BL;
using BikeRental.Core;
using BikeRental.Filters;
using BikeRental.Interfases;
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
            var user = _userManager.GetUserByEmail(model.Email);
            if(user == null) throw new Exception(Resource.EmailNotRegistered);
            var pass = PasswordHashing.HashPassword(model.Password, user.PasswordSalt);
            if(user.Password != pass) throw new Exception(Resource.WrongPassword);
            if(!user.IsActivated) throw  new Exception();
            FormsAuthentication.SetAuthCookie(user.Email,false);
            return RedirectToAction("UserPage", "Profile", user.Id);
        }
    }
}