using System.Collections.Generic;

namespace BikeRental.ViewModel
{
    public class EditBikeViewModel
    {
        public List<TypeViewModel> Types { get; set; }
        public BikeViewModel Bike { get; set; }
    }
}