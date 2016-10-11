using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.ViewModel.ViewModel;

namespace BikeRental.Ang.Controllers
{
    [Authorize]
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

        [Route("takeBike")]
        [HttpPost]
        public TakeBikeViewModel TakeBike(TakeBikeViewModel model)
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var id = Convert.ToInt64(identity.Claims.Where(c => c.Type == "id").Select(c => c.Value).SingleOrDefault());
            var takeBike = _bikeManager.TakeBike(model, id);    
            return takeBike;
        }

        [Route("getTypes")]
        [HttpGet]
        public List<TypeViewModel> GetTypes()
        {

            var types = _typeManager.GetAllTypes();
            return types;
        }

        [Route("getOrders")]
        [HttpGet]
        public List<OrderViewModel> GetOrders()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var id = Convert.ToInt64(identity.Claims.Where(c => c.Type == "id").Select(c => c.Value).SingleOrDefault());
            var userOrders = _orderManager.GetOrdersByUser(id);
            return userOrders;
        }

        [Route("deleteOrder/{id}")]
        [HttpPost]
        public void DeleteOrder(long id)
        {
            _orderManager.DeleteOrder(id);
        }
    }
}
