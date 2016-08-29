using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.Interfases.Repository;
using BikeRental.Interfases.Validator;
using BikeRental.ViewModel;

namespace BikeRental.BL.Manager
{
    public class OrderManager<T> : Manager<T>, IOrderManager<T> where T : Order
    {
        public OrderManager(IRepository<T> repository, IValidator<T> validator)
            : base(repository, validator)
        {
        }

        public IQueryable<Order> GetOrdersByBike(long id)
        {
            return GetAll().Where(x => (x.IdBike == id && x.Status));
        }

        public List<OrderViewModel> GetOrdersByUser(long id)
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();
            var orderList = GetAll().Where(x => (x.IdUser == id && x.Status)).OrderByDescending(x => x.DateOrder);
            foreach (var order in orderList)
            {
                orders.Add(Mapper.Map<Order, OrderViewModel>(order));
            }
            return orders;
        }

        public void DeleteOrder(long id)
        {
            var order = GetById(id);
            Delete(order);
        }

        public void EditAllOrder()
        {
            var ordersList = GetAll().Where(x => x.Status);
            foreach (var order in ordersList)
            {
                if (order.TimeEnd <= DateTime.Now)
                {
                    order.Status = false;
                    Update(order);
                }
            }
        }       
    }
}
