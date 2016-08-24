using BikeRental.Core;

namespace BikeRental.Interfases.Repository
{
    public interface IOrderRepository<T> : IRepository<T> where T : Order
    {
    }
}
