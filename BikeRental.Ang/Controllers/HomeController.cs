using System.Web.Mvc;

namespace BikeRental.Ang.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}