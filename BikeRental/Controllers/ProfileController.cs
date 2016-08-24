using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                EditOrder();


                IQueryable<Bike> bikeList;
                IQueryable<Order> orderList;
                Order entity = null;
                if (model.SelectType == null && model.SelectSex == null)
                {
                    bikeList = _bikeManager.GetAll();
                }
                else
                {
                    bikeList = _bikeManager.SerchBikes(model.SelectType, model.SelectSex);
                }
                foreach (var bike in bikeList)
                {                    
                    orderList = _orderManager.GetOrdersOfBike(bike.Id);
                    foreach (var order in orderList)
                    {
                        if ((model.TimeStart < order.TimeStart && model.TimeEnd < order.TimeStart) ||
                            (model.TimeStart > order.TimeEnd && model.TimeEnd > order.TimeEnd))
                        {
                            entity.IdBike = bike.Id;
                        }
                    }
                    if (entity.Bike != null)
                    {
                        entity = Mapper.Map<TakeBikeViewModel, Order>(model);
                        entity.IdBike = bike.Id;
                        entity.IdUser = userId;
                        entity.TotalPrice = (model.TimeEnd - model.TimeStart).Hours * bike.Price;
                        break;
                    }
                    
                }
                if(entity == null) throw new Exception("К сожалению на выбранное вами время нет свободных велосипедов");
                _orderManager.Add(entity);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                model.Error = e.Message;
                return View(model);
            }
            
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
            }
        }




    }
}