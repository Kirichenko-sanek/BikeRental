using System;

namespace BikeRental.ViewModel.ViewModel
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
        public string BeforeStart { get; set; }
        public string BeforeEnd { get; set; }
        public string Photo { get; set; }
        public decimal PriceOrder { get; set; }
        public string Type { get; set; }
        public string Sex { get; set; }
    }
}