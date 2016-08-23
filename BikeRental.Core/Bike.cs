using System.Collections.Generic;

namespace BikeRental.Core
{
    public class Bike : BaseEntity
    {
        public string Model { get; set; }
        public string Sex { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }

        public virtual List<BikesTypes> Type { get; set; }
        public virtual Order Order { get; set; }
        public virtual Photo Photo { get; set; }

        public Bike()
        {
            Type = new List<BikesTypes>();
            Photo = new Photo();
        }
    }
}
