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
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IBikeManager<Bike> _bikeManager;
        private readonly ITypeManager<Core.Type> _typeManager;
        private readonly IOrderManager<Order> _orderManager;

        public AdminController(IBikeManager<Bike> bikeManager, ITypeManager<Core.Type> typeManager,
            IOrderManager<Order> orderManager)
        {
            _bikeManager = bikeManager;
            _typeManager = typeManager;
            _orderManager = orderManager;
        }


        public ActionResult AdminPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddBike(AddBikeViewModel model)
        {
            var types = new List<TypeViewModel>();
            var typesList = _typeManager.GetAll();
            foreach (var type in typesList)
            {
                types.Add(Mapper.Map<Core.Type, TypeViewModel>(type));
            }
            model.Types = types;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddBike(AddBikeViewModel model, HttpPostedFileBase upload)
        {
            try
            {
                var entity = Mapper.Map<AddBikeViewModel, Bike>(model);
                entity.Photo = new Photo
                {
                    Url = AddPhotos.AddImage(upload, Server.MapPath("/assets/images/Bikes/"), "/assets/images/Bikes/")
                };
                _bikeManager.Add(entity);
                return RedirectToAction("AdminPage", "Admin");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult ListBike(ListBikeViewModel model)
        {
            var bikes = _bikeManager.GetAll();
            List<BikeViewModel> listBikes = new List<BikeViewModel>();
            foreach (var bike in bikes)
            {
                listBikes.Add(Mapper.Map<Bike, BikeViewModel>(bike));
            }
            model.Bikes = listBikes;
            return View(model);
        }

        public ActionResult DeleteBike(long id)
        {

            var delete = new DeleteBike(_bikeManager, _orderManager);
            delete.DBike(id);
            return RedirectToAction("ListBike", "Admin");
        }

        public ActionResult EditStatus(long id)
        {
            var bike = _bikeManager.GetById(id);
            bike.Status = bike.Status != true;

            _bikeManager.Update(bike);
            return RedirectToAction("ListBike", "Admin");
        }

        [HttpGet]
        public ActionResult EditBike(EditBikeViewModel model, long id)
        {

            var types = new List<TypeViewModel>();
            var typesList = _typeManager.GetAll();
            foreach (var type in typesList)
            {
                types.Add(Mapper.Map<Core.Type, TypeViewModel>(type));
            }
            model.Types = types;
            var bike = _bikeManager.GetById(id);
            model.Bike = Mapper.Map<Bike, BikeViewModel>(bike);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditBike(EditBikeViewModel model, HttpPostedFileBase upload)
        {
            try
            {
                var bike = _bikeManager.GetById(model.Bike.IdBike);
                bike = Mapper.Map<EditBikeViewModel, Bike>(model, bike);
                bike.Photo = new Photo
                {
                    Url = AddPhotos.AddImage(upload, Server.MapPath("/assets/images/Bikes/"), "/assets/images/Bikes/")
                };
                _bikeManager.Update(bike);
                return RedirectToAction("ListBike", "Admin");
            }
            catch (Exception)
            {

                return RedirectToAction("ListBike", "Admin");
            }
        }

        public ActionResult AddType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddType(AddTypeViewModel model)
        {
            try
            {
                var entity = Mapper.Map<AddTypeViewModel, Core.Type>(model);
                _typeManager.Add(entity);
                return RedirectToAction("AdminPage", "Admin");
            }
            catch (Exception)
            {
                return View();
            }          
        }
    }
}