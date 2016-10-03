using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using BikeRental.BL;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.ViewModel.ViewModel;

namespace BikeRental.Ang.Controllers
{
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
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


        [Route("upload")]
        [HttpPost]
        public string Upload()
        {
            var request = HttpContext.Current.Request.Files;
            var a = request["Files"];
            HttpPostedFileBase filebase = new HttpPostedFileWrapper(a);
            var url = AddPhotos.AddImage(filebase, HostingEnvironment.MapPath("/assets/images/Bikes/"), "/assets/images/Bikes/");
            return url;
        }

        [Route("addBike")]
        [HttpPost]
        public bool AddBike(BikeViewModel model)
        {

                _bikeManager.AddBikeApi(model);

                return true;

        }

        [Route("getBikes")]
        [HttpGet]
        public List<BikeViewModel> ListBike()
        {
            return _bikeManager.ListBike();
        }

        [Route("deleteBike/{id}")]
        [HttpPost]
        public void DeleteBike(long id)
        {
            _bikeManager.DeleteBike(id);
        }

        [Route("editStatus/{id}")]
        [HttpPost]
        public void EditStatus(long id)
        {
            _bikeManager.EditStatus(id);
        }

        [Route("getBike/{id}")]
        [HttpGet]
        public EditBikeViewModel GetBike(long id)
        {
            return _bikeManager.EditBikeGet(id);
        }

    }
}
