using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
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
        public void Upload()
        {
            var request = HttpContext.Current.Request;
             
        }

        [Route("addBike")]
        [HttpPost]
        public bool AddBike(AddBikeViewModel model)
        {
            try
            {
                //_bikeManager.AddBikePost(model, upload, HostingEnvironment.MapPath("/assets/images/Bikes/"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
