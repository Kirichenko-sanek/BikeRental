using BikeRental.Validators;
using FluentValidation.Attributes;

namespace BikeRental.ViewModel
{
    //[Validator(typeof(BikeViewModelValidator))]
    public class BikeViewModel
    {
        public long IdBike { get; set; }
        public string Sex { get; set; }
        public decimal Price { get; set; }
        public long IdPhoto { get; set; }
        public long IdType { get; set; }
        public bool Status { get; set; }
        public string Photo { get; set; }
        public string Type { get; set; }
    }
}