using System.Collections.Generic;

namespace BikeRental.Core
{
    public class Bike : BaseEntity
    {
        public string Sex { get; set; }
        public decimal Price { get; set; }
        public long IdPhoto { get; set; }
        public long IdType { get; set; }

        public virtual Type Type { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual List<Order> Order { get; set; }

        public Bike()
        {
            Order = new List<Order>();
        }
    }
}
