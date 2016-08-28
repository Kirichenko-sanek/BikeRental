using BikeRental.Validators;
using FluentValidation.Attributes;

namespace BikeRental.ViewModel
{
    [Validator(typeof(AddTypeViewModelValidator))]
    public class AddTypeViewModel
    {
        public string NameType { get; set; }
    }
}