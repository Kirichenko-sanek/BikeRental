using System;
using BikeRental.Core;
using BikeRental.Interfases.Manager;

namespace BikeRental.BL
{
    public class EditOrder
    {
        private readonly IOrderManager<Order> _orderManager;

        public EditOrder(IOrderManager<Order> orderManager)
        {
            _orderManager = orderManager;
        }

        public void EditAllOrder()
        {
            var ordersList = _orderManager.GetActivOrders();
            foreach (var order in ordersList)
            {
                if (order.TimeEnd <= DateTime.Now)
                {
                    order.Status = false;
                    _orderManager.Update(order);
                }
            }
        }
    }
}
