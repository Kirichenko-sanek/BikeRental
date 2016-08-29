using BikeRental.Resources.App_GlobalResources;
using BikeRental.ViewModel.ViewModel;
using FluentValidation;

namespace BikeRental.ViewModel.Validators
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage(Resource.FieldCannotBeEmpty)
                .EmailAddress()
                .WithMessage(Resource.WrongFormatEmail);
            RuleFor(p => p.Password).NotEmpty().WithMessage(Resource.FieldCannotBeEmpty);
        }
    }
}