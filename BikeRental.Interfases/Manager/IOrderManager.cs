using System.Linq;
using BikeRental.Core;

namespace BikeRental.Interfases.Manager
{
    public interface IOrderManager<T> : IManager<T> where T : Order
    {
        IQueryable<Order> GetActivOrders();
        IQueryable<Order> GetOrdersByBike(long id);
        IQueryable<Order> GetOrdersByUser(long id);
    }
}
