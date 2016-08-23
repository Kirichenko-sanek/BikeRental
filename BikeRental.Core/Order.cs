using System;

namespace BikeRental.Core
{
    public class Order : BaseEntity
    {
        public long IdUser { get; set; }
        public long IdBike { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public DateTime DateOrder { get; set; }
        public bool Status { get; set; }

        public virtual User User { get; set; }
        public virtual Bike Bike { get; set; }
    }
}
