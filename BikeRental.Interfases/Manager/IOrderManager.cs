using System;
using System.Collections.Generic;
using System.Linq;
using BikeRental.Core;
using BikeRental.ViewModel.ViewModel;

namespace BikeRental.Interfases.Manager
{
    public interface IOrderManager<T> : IManager<T> where T : Order
    {
        IQueryable<Order> GetOrdersByBike(long id);
        List<OrderViewModel> GetOrdersByUser(long id);
        void DeleteOrder(long id);
        void EditAllOrder();        
    }
}
