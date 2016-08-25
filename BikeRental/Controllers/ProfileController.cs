using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BikeRental.BL;
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

        /*public ActionResult UserPage(long? id)
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
        }*/

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
            try
            {

                var b = new GetBike(_bikeManager, _orderManager);
                var o = new EditOrder(_orderManager);
                o.EditAllOrder();
                var bike = b.GetBikeOnDb(model.TimeStart, model.TimeEnd, model.SelectType, model.SelectSex);
                if (bike == null) throw new Exception("К сожалению на выбранное вами время нет свободных велосипедов");
                var entity = Mapper.Map<TakeBikeViewModel, Order>(model);
                entity.IdBike = bike.Id;
                entity.IdUser = userId;

                entity.TotalPrice = Convert.ToDecimal(model.TimeEnd.Subtract(model.TimeStart).TotalHours)*bike.Price;

                _orderManager.Add(entity);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                model.Error = e.Message;
                return View(model);
            }

        }

        public ActionResult UserOrders(UserOrdersPageViewModel model, long id)
        {
            try
            {
                List<OrderViewModel> orders = new List<OrderViewModel>();
                var orderList = _orderManager.GetOrdersByUser(id).OrderByDescending(x => x.DateOrder);
                foreach (var order in orderList)
                {
                    orders.Add(Mapper.Map<Order,OrderViewModel>(order));
                }
                model.UserOrders = orders;
                return View(model);
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult DeleteOrder(long id)
        {
            var order = _orderManager.GetById(id);
            _orderManager.Delete(order);
            return RedirectToRoute("UserOrders");
        }




    }
}