using BikeRental.App_GlobalResources;
using BikeRental.ViewModel;
using FluentValidation;

namespace BikeRental.Validators
{
    public class AddTypeViewModelValidator : AbstractValidator<AddTypeViewModel>
    {
        public AddTypeViewModelValidator()
        {
            RuleFor(p => p.NameType).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty);
        }
    }
}