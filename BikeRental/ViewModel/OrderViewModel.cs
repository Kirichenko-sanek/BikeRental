using System;

namespace BikeRental.ViewModel
{
    public class OrderViewModel
    {
        public long IdOrder { get; set; }
        public long IdUser { get; set; }
        public long IdBike { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public DateTime DateOrder { get; set; }
        public bool Status { get; set; }
        public TimeSpan BeforeStart { get; set; }
        public TimeSpan BeforeEnd { get; set; }
        public string Photo { get; set; }
    }
}