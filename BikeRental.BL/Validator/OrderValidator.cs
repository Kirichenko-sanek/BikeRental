using BikeRental.Core;
using BikeRental.Interfases.Repository;
using BikeRental.Interfases.Validator;

namespace BikeRental.BL.Validator
{
    public class OrderValidator : IValidator<Order>
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderValidator(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public bool IsExists(long id)
        {
            return _orderRepository.GetByID(id) != null;
        }

        public bool IsValid(Order entity)
        {
            return true;
        }
    }
}
