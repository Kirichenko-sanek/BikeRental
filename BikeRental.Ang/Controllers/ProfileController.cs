using System.Collections.Generic;
using System.Web.Http;
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
        public string TakeBike(TakeBikeViewModel model, long userId)
        {
            var takeBike = _bikeManager.TakeBike(model, userId);
            return takeBike.Error;
        }

        [Route("getTypes")]
        [HttpGet]
        public List<TypeViewModel> GetTypes()
        {

            var types = _typeManager.GetAllTypes();
            return types;
        }

    }
}
