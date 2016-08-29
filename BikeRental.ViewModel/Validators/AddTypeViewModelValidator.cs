using BikeRental.Resources.App_GlobalResources;
using BikeRental.ViewModel.ViewModel;
using FluentValidation;

namespace BikeRental.ViewModel.Validators
{
    public class AddTypeViewModelValidator : AbstractValidator<AddTypeViewModel>
    {
        public AddTypeViewModelValidator()
        {
            RuleFor(p => p.NameType).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty);
        }
    }
}