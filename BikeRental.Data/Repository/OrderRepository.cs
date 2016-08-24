using BikeRental.Core;
using BikeRental.Interfases.Repository;

namespace BikeRental.Data.Repository
{
    public class OrderRepository<T> :Repository<T>,IOrderRepository<T> where T : Order
    {
        public OrderRepository(DataContext context) : base(context)
        {
            
        }
    }
}
