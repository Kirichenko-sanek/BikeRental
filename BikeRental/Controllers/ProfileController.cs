using System;
using System.Web.Mvc;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.ViewModel.ViewModel;

namespace BikeRental.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserManager<User> _userManager;
        private readonly ITypeManager<Core.Type> _typeManager;
        private readonly IBikeManager<Bike> _bikeManager;
        private readonly IOrderManager<Order> _orderManager;

        public ProfileController(IUserManager<User> userManager, ITypeManager<Core.Type> typeManager,
            IBikeManager<Bike> bikeManager, IOrderManager<Order> orderManager)
        {
            _userManager = userManager;
            _typeManager = typeManager;
            _bikeManager = bikeManager;
            _orderManager = orderManager;
        }

        [HttpGet]
        public ActionResult TakeBike(TakeBikeViewModel model)
        {
            model.Types = _typeManager.GetAllTypes();
            return View(model);
        }

        [HttpPost]
        public ActionResult TakeBike(TakeBikeViewModel model, long userId)
        {
            var takeBike = _bikeManager.TakeBike(model, userId);
            if (takeBike.Error != null)
            {
                takeBike.Types = _typeManager.GetAllTypes();
                takeBike.AccessTime = _bikeManager.AccessTime(takeBike.PotentialBike);
                return View(takeBike);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UserOrders(UserOrdersPageViewModel model, long id)
        {
            try
            {               
                model.UserOrders = _orderManager.GetOrdersByUser(id);
                return View(model);
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult DeleteOrder(long id)
        {
            _orderManager.DeleteOrder(id);
            return RedirectToRoute("UserOrders");
        }
    }
}