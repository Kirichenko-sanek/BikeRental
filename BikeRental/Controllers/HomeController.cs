using System.Web.Mvc;
using BikeRental.Core;
using BikeRental.Interfases.Manager;

namespace BikeRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserManager<User> _userManager;

        public HomeController(IUserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            /*if (Session["UserId"] != null) return View();
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated) return View();
            var user = _userManager.GetUserByEmail(User.Identity.Name);
            Session["UserId"] = user.Id;*/
            return View();
        }

        
    }
}