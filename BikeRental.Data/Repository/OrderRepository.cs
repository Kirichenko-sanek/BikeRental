﻿using System.Linq;
using BikeRental.Core;
using BikeRental.Interfases.Repository;

namespace BikeRental.Data.Repository
{
    public class OrderRepository<T> :Repository<T>,IOrderRepository<T> where T : Order
    {
        public OrderRepository(DataContext context) : base(context)
        {
            
        }

        public IQueryable<Order> GetActivOrders()
        {
            return _context.Orders.Where(x => x.Status);
        }

        public IQueryable<Order> GetOrdersByBike(long id)
        {
            return _context.Orders.Where(x => (x.IdBike == id && x.Status));
        }

        public IQueryable<Order> GetOrdersByUser(long id)
        {
            return _context.Orders.Where(x => (x.IdUser == id && x.Status));
        }
    }
}
