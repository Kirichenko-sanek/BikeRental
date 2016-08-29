using System;
using System.Collections.Generic;

namespace BikeRental.ViewModel.ViewModel
{
    public class TakeBikeViewModel
    {
        public List<TypeViewModel> Types { get; set; }
        public long IdUser { get; set; }
        public long IdBike { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public DateTime DateOrder { get; set; }
        public long SelectType { get; set; }
        public string SelectSex { get; set; }
        public string Error { get; set; }
        
    }
}