using System;
using System.Web;
using System.Web.Mvc;
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
            
            return View(_bikeManager.AddBikeGet(model));
        }

        [HttpPost]
        public ActionResult AddBike(AddBikeViewModel model, HttpPostedFileBase upload)
        {
            try
            {
                _bikeManager.AddBikePost(model, upload, Server.MapPath("/assets/images/Bikes/"));
                return RedirectToAction("AdminPage", "Admin");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult ListBike(ListBikeViewModel model)
        {
            
            model.Bikes = _bikeManager.ListBike();
            return View(model);
        }

        public ActionResult DeleteBike(long id)
        {
            _bikeManager.DeleteBike(id);
            return RedirectToAction("ListBike", "Admin");
        }

        public ActionResult EditStatus(long id)
        {
            _bikeManager.EditStatus(id);
            return RedirectToAction("ListBike", "Admin");
        }

        [HttpGet]
        public ActionResult EditBike(EditBikeViewModel model, long id)
        {
            return View(_bikeManager.EditBikeGet(id));
        }

        [HttpPost]
        public ActionResult EditBike(EditBikeViewModel model, HttpPostedFileBase upload)
        {
            try
            {
                _bikeManager.EditBikePost(model,upload, Server.MapPath("/assets/images/Bikes/"));
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
                _typeManager.AddType(model);
                return RedirectToAction("AdminPage", "Admin");
            }
            catch (Exception)
            {
                return View();
            }          
        }
    }
}