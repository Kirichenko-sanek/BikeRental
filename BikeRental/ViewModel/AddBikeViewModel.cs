using System.Collections.Generic;
using BikeRental.Validators;
using FluentValidation.Attributes;


namespace BikeRental.ViewModel
{
    public class AddBikeViewModel
    {
        public List<TypeViewModel> Types { get; set; }
        public BikeViewModel Bike { get; set; }
        
    }
}