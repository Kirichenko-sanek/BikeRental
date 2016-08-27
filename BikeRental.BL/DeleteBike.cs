using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Core;
using BikeRental.Interfases.Manager;

namespace BikeRental.BL
{
    public class DeleteBike
    {
        private readonly IBikeManager<Bike> _bikeManager;
        private readonly IOrderManager<Order> _orderManager;

        public DeleteBike(IBikeManager<Bike> bikeManager, IOrderManager<Order> orderManager)
        {
            _orderManager = orderManager;
            _bikeManager = bikeManager;
        }

        public void DBike(long id)
        {
            var listOrder = new List<Order>();
            var orders = _orderManager.GetOrdersByBike(id);
            foreach (var order in orders)
            {
                listOrder.Add(order);
            }
            foreach (var order in listOrder)
            {
                _orderManager.Delete(order);
            }
            var bike = _bikeManager.GetById(id);
            _bikeManager.Delete(bike);
        }
    }
}
