using System;
using System.Linq;
using BikeRental.Core;
using BikeRental.Interfases.Manager;

namespace BikeRental.BL
{
    public class GetBike
    {
        private readonly IBikeManager<Bike> _bikeManager;
        private readonly IOrderManager<Order> _orderManager;

        public GetBike(IBikeManager<Bike> bikeManager, IOrderManager<Order> orderManager)
        {
            _orderManager = orderManager;
            _bikeManager = bikeManager;
        }

        public Bike GetBikeOnDb(DateTime timeStart, DateTime timeEnd, string type, string sex)
        {
            IQueryable<Bike> bikeList;
            IQueryable<Order> orderList;
            Bike oneBike = null;
            if (type == null && sex == null)
            {
                bikeList = _bikeManager.GetAll();
            }
            else
            {
                bikeList = _bikeManager.SerchBikes(type, sex);
            }
            foreach (var bike in bikeList)
            {
                orderList = _orderManager.GetOrdersByBike(bike.Id);
                if(!orderList.Any()) oneBike = bike;
                foreach (var order in orderList)
                {
                    if ((timeStart < order.TimeStart && timeEnd < order.TimeStart) ||
                        (timeStart > order.TimeEnd && timeEnd > order.TimeEnd))
                    {
                        oneBike = bike;
                    }
                }
                if (oneBike != null)
                {
                   
                    break;
                }

            }
            return oneBike;
        }
    }
}
