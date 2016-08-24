using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.ViewModel;

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

        [HttpGet]
        public ActionResult TakeBike(TakeBikeViewModel model)
        {
            List<TypeViewModel> types = new List<TypeViewModel>();
            var typesList = _typeManager.GetAll();
            foreach (var type in typesList)
            {
                types.Add(Mapper.Map<Core.Type, TypeViewModel>(type));               
            }
            model.Types = types;
            return View(model);
        }

        [HttpPost]
        public ActionResult TakeBike(TakeBikeViewModel model, long userId)
        {
            EditOrder();
            var bike = _bikeManager.SerchBikes(model.SelectType, model.SelectSex);
            var entity = Mapper.Map<TakeBikeViewModel, Order>(model);
            entity.IdBike = bike.Id;
            entity.IdUser = userId;
            entity.TotalPrice = (model.TimeEnd - model.TimeStart).Hours*bike.Price;
            _orderManager.Add(entity);
            return RedirectToAction("Index","Home");
        }

        public void EditOrder()
        {
            var ordersList = _orderManager.GetActivOrders();
            foreach (var order in ordersList)
            {
                if (order.TimeEnd <= DateTime.Now)
                {
                    order.Status = false;
                    _orderManager.Update(order);
                }
                if (order.TimeStart <= DateTime.Now && DateTime.Now <= order.TimeEnd)
                {
                    order.Bike.Status = false;
                    _orderManager.Update(order);
                }
            }
        }




    }
}