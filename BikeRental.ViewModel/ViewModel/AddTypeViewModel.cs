using BikeRental.ViewModel.Validators;
using FluentValidation.Attributes;

namespace BikeRental.ViewModel.ViewModel
{
    [Validator(typeof(AddTypeViewModelValidator))]
    public class AddTypeViewModel
    {
        public string NameType { get; set; }
    }
}