using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BikeRental.App_Start;
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

        public ProfileController(IUserManager<User> userManager, ITypeManager<Core.Type> typeManager,
            IBikeManager<Bike> bikeManager)
        {
            _userManager = userManager;
            _typeManager = typeManager;
            _bikeManager = bikeManager;
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
            var bike = _bikeManager.SerchBikes(model.SelectType, model.SelectSex);
            var entity = Mapper.Map<TakeBikeViewModel, Order>(model);
            entity.IdBike = bike.Id;
            entity.IdUser = userId;
            return View();
        }


    }
}