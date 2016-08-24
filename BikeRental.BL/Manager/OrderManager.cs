using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.Interfases.Repository;
using BikeRental.Interfases.Validator;

namespace BikeRental.BL.Manager
{
    public class OrderManager<T> : Manager<T>, IOrderManager<T> where T : Order
    {
        private readonly IOrderRepository<Order> _orderRepository;

        public OrderManager(IOrderRepository<Order> orderRepository, IRepository<T> repository, IValidator<T> validator)
            : base(repository, validator)
        {
            _orderRepository = orderRepository;
        }
    }
}
