﻿using System.Linq;
using BikeRental.Core;

namespace BikeRental.Interfases.Repository
{
    public interface IOrderRepository<T> : IRepository<T> where T : Order
    {
        IQueryable<Order> GetActivOrders();
        IQueryable<Order> GetOrdersByBike(long id);
        IQueryable<Order> GetOrdersByUser(long id);
    }
}
