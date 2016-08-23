using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.ViewModel;

namespace BikeRental.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserManager<User> _userManager;

        public ProfileController(IUserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public ActionResult UserPage(long? id)
        {
            if (id != null) return UserPage(new UserPageViewModel(), id);
            var user = _userManager.GetUserByEmail(User.Identity.Name);
            Session["UserId"] = user.Id;
            return UserPage(new UserPageViewModel(), user.Id);
        }

        [HttpPost]
        public ActionResult UserPage(UserPageViewModel model, long? id)
        {
            return View();
        }
    }
}