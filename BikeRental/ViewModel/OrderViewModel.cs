using System;

namespace BikeRental.ViewModel
{
    public class OrderViewModel
    {
        public long IdUser { get; set; }
        public long IdBike { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public DateTime DateOrder { get; set; }
        public bool Status { get; set; }
    }
}