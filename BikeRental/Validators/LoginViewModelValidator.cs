using BikeRental.App_GlobalResources;
using BikeRental.ViewModel;
using FluentValidation;

namespace BikeRental.Validators
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