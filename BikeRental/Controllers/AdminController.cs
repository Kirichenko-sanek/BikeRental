using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BikeRental.BL;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.ViewModel;

namespace BikeRental.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBikeManager<Bike> _bikeManager;
        private readonly ITypeManager<Core.Type> _typeManager;

        public AdminController(IBikeManager<Bike> bikeManager, ITypeManager<Core.Type> typeManager)
        {
            _bikeManager = bikeManager;
            _typeManager = typeManager;
        }


        public ActionResult AdminPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddBike(AddBikeViewModel model)
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
        public ActionResult AddBike(AddBikeViewModel model, HttpPostedFileBase upload
            )
        {
            try
            {
                var entity = Mapper.Map<AddBikeViewModel, Bike>(model);
                entity.Photo = new Photo
                {
                    Url = AddPhotos.AddImage(upload, Server.MapPath("/assets/images/Bikes/"), "/assets/images/Bikes/")
                };
                _bikeManager.Add(entity);
                return RedirectToAction("AdminPage","Admin");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}