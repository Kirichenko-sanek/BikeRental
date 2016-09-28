using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.ViewModel.ViewModel;

namespace BikeRental.Ang.Controllers
{
    [RoutePrefix("api/Profile")]
    public class ProfileController : ApiController
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

        [Route("takeBike/{userId}")]
        [HttpPost]
        public TakeBikeViewModel TakeBike(TakeBikeViewModel model, long userId)
        {
            var takeBike = _bikeManager.TakeBike(model, userId);
            if (takeBike.Error != null)
            {
                takeBike.AccessTime = _bikeManager.AccessTime(takeBike.PotentialBike);
            }     
            return takeBike;
        }

        [Route("getTypes")]
        [HttpGet]
        public List<TypeViewModel> GetTypes()
        {

            var types = _typeManager.GetAllTypes();
            return types;
        }

        [Route("getOrders/{userId}")]
        [HttpGet]
        public List<OrderViewModel> GetOrders(long userId)
        {
            var userOrders = _orderManager.GetOrdersByUser(userId);
            return userOrders;
        }

        [Route("deleteOrder/{id}")]
        [HttpPost]
        public void DeleteOrder(long id)
        {
            _orderManager.DeleteOrder(id);
        }




        [Route("go")]
        [HttpGet]
        public string Go()
        {

            return "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        }
    }
}
